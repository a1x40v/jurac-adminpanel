using Application.Common.Exceptions;
using Application.Contracts.Identity;
using Application.Features.PublishRecTab.Requests.Commands;
using AutoMapper;
using Domain;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Commands
{
    public class UpdatePublishRecTabCommandHandler : IRequestHandler<UpdatePublishRecTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        public UpdatePublishRecTabCommandHandler(ApplicationDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(UpdatePublishRecTabCommand request, CancellationToken cancellationToken)
        {
            var publishRecTab = await _dbContext.RegabiturPublishrectabs
                .Include(x => x.AdminpanelRectabmodification)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.User.Id == request.UserId);

            if (publishRecTab == null)
            {
                throw new NotFoundException("PublishRecTab for AuthUser with Id", request.UserId);
            }

            int userId = _userAccessor.GetUserId();
            var user = await _dbContext.AuthUsers.FindAsync(userId);

            bool isPublished = request.IsPublished;
            bool prevIsPublished = publishRecTab.IsPublished;
            bool modsAlreadyExists = publishRecTab.AdminpanelRectabmodification != null;

            if (prevIsPublished == true && isPublished == true)
            {
                if (modsAlreadyExists)
                {
                    publishRecTab.AdminpanelRectabmodification.Type = (ushort)RecTabModificationType.Updated;
                    publishRecTab.AdminpanelRectabmodification.CreatedAt = DateTime.UtcNow;
                    publishRecTab.AdminpanelRectabmodification.Author = user.Username;
                }
                else
                {
                    _dbContext.Add(new AdminpanelRectabmodification
                    {
                        Type = (ushort)RecTabModificationType.Updated,
                        CreatedAt = DateTime.UtcNow,
                        Author = user.Username,
                        Rectab = publishRecTab,
                        Abiturient = publishRecTab.User
                    });
                }
            }

            if (prevIsPublished == false && isPublished == true)
            {
                if (modsAlreadyExists)
                {
                    publishRecTab.AdminpanelRectabmodification.Type = (ushort)RecTabModificationType.Showed;
                    publishRecTab.AdminpanelRectabmodification.CreatedAt = DateTime.UtcNow;
                    publishRecTab.AdminpanelRectabmodification.Author = user.Username;
                }
                else
                {
                    _dbContext.Add(new AdminpanelRectabmodification
                    {
                        Type = (ushort)RecTabModificationType.Showed,
                        CreatedAt = DateTime.UtcNow,
                        Author = user.Username,
                        Rectab = publishRecTab,
                        Abiturient = publishRecTab.User
                    });
                }
            }

            if (prevIsPublished == true && isPublished == false)
            {
                if (modsAlreadyExists)
                {
                    _dbContext.Remove(publishRecTab.AdminpanelRectabmodification);
                }
                else
                {
                    _dbContext.Add(new AdminpanelRectabmodification
                    {
                        Type = (ushort)RecTabModificationType.Hidden,
                        CreatedAt = DateTime.UtcNow,
                        Author = user.Username,
                        Rectab = publishRecTab,
                        Abiturient = publishRecTab.User
                    });
                }
            }

            _mapper.Map(request, publishRecTab);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to update a PublishRecTab");
            }

            return Unit.Value;
        }
    }
}