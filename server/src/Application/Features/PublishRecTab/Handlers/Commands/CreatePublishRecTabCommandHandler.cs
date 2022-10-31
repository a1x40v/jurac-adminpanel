using Application.Common.Exceptions;
using Application.Contracts.Identity;
using Application.Features.PublishRecTab.Requests.Commands;
using AutoMapper;
using Domain;
using Domain.Enums;
using Domain.Factories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Commands
{
    public class CreatePublishRecTabCommandHandler : IRequestHandler<CreatePublishRecTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        public CreatePublishRecTabCommandHandler(ApplicationDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(CreatePublishRecTabCommand request, CancellationToken cancellationToken)
        {
            // get the user for RecTab
            var user = await _dbContext.AuthUsers
                .Include(x => x.RegabiturPublishrectab)
                .Include(x => x.RegabiturCustomuser)
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"Cannot find AuthUser with id '{request.UserId}'");
            }

            if (user.RegabiturPublishrectab != null)
            {
                throw new NotFoundException($"User with id '{request.UserId}' already has publish tab");
            }

            if (user.RegabiturCustomuser == null)
            {
                user.RegabiturCustomuser = RegabiturCustomuserFactory.CreateEmpty();
            }

            // remove DeleteMod if exists 
            var deleteMod = await _dbContext.AdminpanelRectabmodifications
                .Where(x => x.Type == (ushort)RecTabModificationType.Deleted && x.AbiturientId == user.Id)
                .FirstOrDefaultAsync();

            if (deleteMod != null)
            {
                _dbContext.Remove(deleteMod);
                await _dbContext.SaveChangesAsync();
            }

            // create RecTab
            var publishRecTab = new RegabiturPublishrectab();

            _mapper.Map(request, publishRecTab);

            user.RegabiturPublishrectab = publishRecTab;

            // create RecTabModification
            if (publishRecTab.IsPublished == true)
            {
                int staffId = _userAccessor.GetUserId();
                var staff = await _dbContext.AuthUsers.FindAsync(staffId);

                var rectabMod = new AdminpanelRectabmodification
                {
                    Author = staff.Username,
                    CreatedAt = DateTime.UtcNow,
                    Type = (ushort)RecTabModificationType.Created,
                    Rectab = publishRecTab,
                    Abiturient = user
                };

                _dbContext.Add(rectabMod);
            }

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to create a PublishRecTab");
            }

            return Unit.Value;
        }
    }
}