using Application.Common.Exceptions;
using Application.Features.PublishRecTab.Requests.Commands;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Commands
{
    public class CreatePublishRecTabCommandHandler : IRequestHandler<CreatePublishRecTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreatePublishRecTabCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePublishRecTabCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.AuthUsers
                .Include(x => x.RegabiturPublishrectab)
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"Cannot find AuthUser with id '{request.UserId}'");
            }

            if (user.RegabiturPublishrectab != null)
            {
                throw new NotFoundException($"User with id '{request.UserId}' already has publish tab");
            }

            var publishRecTab = new RegabiturPublishrectab();

            _mapper.Map(request, publishRecTab);

            user.RegabiturPublishrectab = publishRecTab;

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to create a PublishRecTab");
            }

            return Unit.Value;
        }
    }
}