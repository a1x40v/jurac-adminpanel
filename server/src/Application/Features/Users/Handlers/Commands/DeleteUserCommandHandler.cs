using Application.Common.Exceptions;
using Application.Features.Users.Requests.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Users.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteUserCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var authUser = await _dbContext.AuthUsers
                .Include(x => x.RegabiturCustomuser)
                .Include(x => x.RegabiturPublishtab)
                .Include(x => x.RegabiturPublishrectab)
                .Include(x => x.RegabiturDocumentusers)
                .Include(x => x.RegabiturAdditionalinfo)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (authUser == null)
            {
                throw new NotFoundException("AuthUser", request.Id);
            }

            // Delete custom info
            if (authUser.RegabiturCustomuser != null)
            {
                _dbContext.Remove(authUser.RegabiturCustomuser);
            }

            // Delete publishes
            if (authUser.RegabiturPublishtab != null)
            {
                _dbContext.Remove(authUser.RegabiturPublishtab);
            }
            if (authUser.RegabiturPublishrectab != null)
            {
                _dbContext.Remove(authUser.RegabiturPublishrectab);
            }

            // Delete user documents
            foreach (var doc in authUser.RegabiturDocumentusers)
            {
                _dbContext.Remove(doc);
            }

            // Delete education profiles
            if (authUser.RegabiturAdditionalinfo != null)
            {
                var eduProfiles = _dbContext.RegabiturAdditionalinfoEducationProfiles
                    .Where(x => x.AdditionalinfoId == authUser.RegabiturAdditionalinfo.Id);

                foreach (var ep in eduProfiles)
                {
                    _dbContext.Remove(ep);
                }

                _dbContext.Remove(authUser.RegabiturAdditionalinfo);
            }


            _dbContext.Remove(authUser);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to delete an user");
            }

            return Unit.Value;
        }
    }
}