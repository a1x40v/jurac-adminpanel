using Application.Common.Exceptions;
using Application.Features.PublishTab.Requests.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishTab.Handlers.Commands
{
    public class DeletePublishTabCommandHandler : IRequestHandler<DeletePublishTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeletePublishTabCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeletePublishTabCommand request, CancellationToken cancellationToken)
        {
            var publishTab = await _dbContext.RegabiturPublishtabs.FirstOrDefaultAsync(x => x.User.Id == request.UserId);

            if (publishTab == null)
            {
                throw new NotFoundException("PublishRecTab for AuthUther with Id", request.UserId);
            }

            _dbContext.Remove(publishTab);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to remove a PublishTab");
            }

            return Unit.Value;
        }
    }
}