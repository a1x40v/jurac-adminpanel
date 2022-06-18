using Application.Common.Exceptions;
using Application.Features.PublishTab.Requests.Commands;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishTab.Handlers.Commands
{
    public class CreatePublishTabCommandHandler : IRequestHandler<CreatePublishTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreatePublishTabCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreatePublishTabCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.AuthUsers
                .Include(x => x.RegabiturPublishtab)
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"Cannot find AuthUser with id '{request.UserId}'");
            }

            if (user.RegabiturPublishtab != null)
            {
                throw new NotFoundException($"User with id '{request.UserId}' already has publish tab");
            }

            var publishRecTab = new RegabiturPublishtab();

            publishRecTab.DatePub = DateTime.UtcNow;

            _mapper.Map(request, publishRecTab);

            user.RegabiturPublishtab = publishRecTab;

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to create a PublishTab");
            }

            return Unit.Value;
        }
    }
}