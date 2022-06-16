using Application.Common.Exceptions;
using Application.Features.Users.Requests.Commands;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Features.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        public UpdateUserCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var authUser = await _dbContext.AuthUsers
                .Include(x => x.RegabiturCustomuser)
                .Include(x => x.RegabiturAdditionalinfo)
                .ThenInclude(x => x.RegabiturAdditionalinfoEducationProfiles)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (authUser == null)
            {
                throw new NotFoundException("AuthUser", request.Id);
            }

            _mapper.Map(request, authUser);

            if (authUser.RegabiturCustomuser != null)
            {
                _mapper.Map(request, authUser.RegabiturCustomuser);
            }

            if (authUser.RegabiturAdditionalinfo == null)
            {
                authUser.RegabiturAdditionalinfo = new RegabiturAdditionalinfo();
                await _dbContext.SaveChangesAsync();
            }

            var currentProfiles = await _dbContext.RegabiturAdditionalinfoEducationProfiles
                .Where(x => x.AdditionalinfoId == authUser.RegabiturAdditionalinfo.Id)
                .Select(x => x.Choicesprofile.Description)
                .ToListAsync();

            if (currentProfiles.Count() != request.ChoicesProfiles.Count()
                || !request.ChoicesProfiles.All(x => currentProfiles.Contains(x)))
            {
                _dbContext.RegabiturAdditionalinfoEducationProfiles.RemoveRange(
                    authUser.RegabiturAdditionalinfo.RegabiturAdditionalinfoEducationProfiles);

                var newProfiles = await _dbContext.RegabiturChoicesprofiles
                    .Where(x => request.ChoicesProfiles.Contains(x.Description))
                    .ToListAsync();

                foreach (var newPr in newProfiles)
                {
                    authUser.RegabiturAdditionalinfo.RegabiturAdditionalinfoEducationProfiles.Add(
                        new RegabiturAdditionalinfoEducationProfile
                        {
                            Choicesprofile = newPr
                        }
                    );
                }
            }

            if (!_dbContext.ChangeTracker.HasChanges())
            {
                return Unit.Value;
            }

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to update an user");
            }

            return Unit.Value;
        }
    }
}