using Application.Common.Exceptions;
using Application.Contracts.Identity;
using Application.Features.PublishRecTab.Requests.Commands;
using Domain;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Commands
{
    public class DeletePublishRecTabCommandHandler : IRequestHandler<DeletePublishRecTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        public DeletePublishRecTabCommandHandler(ApplicationDbContext dbContext, IUserAccessor userAccessor)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(DeletePublishRecTabCommand request, CancellationToken cancellationToken)
        {
            var publishRecTab = await _dbContext.RegabiturPublishrectabs
                .Include(x => x.User)
                .Include(x => x.AdminpanelRectabmodification)
                .FirstOrDefaultAsync(x => x.User.Id == request.UserId);

            if (publishRecTab == null)
            {
                throw new NotFoundException("PublishRecTab with AuthUser with Id", request.UserId);
            }

            int userId = _userAccessor.GetUserId();
            var user = await _dbContext.AuthUsers.FindAsync(userId);

            if (publishRecTab.AdminpanelRectabmodification == null)
            {
                _dbContext.Add(new AdminpanelRectabmodification
                {
                    Type = (ushort)RecTabModificationType.Deleted,
                    CreatedAt = DateTime.UtcNow,
                    Author = user.Username,
                    Rectab = publishRecTab,
                    Abiturient = publishRecTab.User,
                });
            }
            else
            {
                if (publishRecTab.AdminpanelRectabmodification.Type == (ushort)RecTabModificationType.Created)
                {
                    _dbContext.Remove(publishRecTab.AdminpanelRectabmodification);
                }
                else
                {
                    publishRecTab.AdminpanelRectabmodification.Type = (ushort)RecTabModificationType.Deleted;
                    publishRecTab.AdminpanelRectabmodification.CreatedAt = DateTime.UtcNow;
                    publishRecTab.AdminpanelRectabmodification.Author = user.Username;
                }
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