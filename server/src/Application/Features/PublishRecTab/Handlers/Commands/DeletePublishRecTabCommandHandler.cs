using Application.Common.Exceptions;
using Application.Features.PublishRecTab.Requests.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Commands
{
    public class DeletePublishRecTabCommandHandler : IRequestHandler<DeletePublishRecTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeletePublishRecTabCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeletePublishRecTabCommand request, CancellationToken cancellationToken)
        {
            var publishRecTab = await _dbContext.RegabiturPublishrectabs.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (publishRecTab == null)
            {
                throw new NotFoundException("PublishRecTab", request.Id);
            }

            _dbContext.Remove(publishRecTab);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to remove a PublishRecTab");
            }

            return Unit.Value;
        }
    }
}