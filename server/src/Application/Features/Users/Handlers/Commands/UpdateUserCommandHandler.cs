using Application.Common.Exceptions;
using Application.Features.Users.Requests.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var authUser = await _dbContext.AuthUsers
                .Include(x => x.RegabiturCustomuser)
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

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to update an user");
            }

            return Unit.Value;
        }
    }
}