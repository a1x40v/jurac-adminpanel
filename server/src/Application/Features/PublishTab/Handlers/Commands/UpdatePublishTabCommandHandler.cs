using Application.Common.Exceptions;
using Application.Features.PublishTab.Requests.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishTab.Handlers.Commands
{
    public class UpdatePublishTabCommandHandler : IRequestHandler<UpdatePublishTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdatePublishTabCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePublishTabCommand request, CancellationToken cancellationToken)
        {
            var publishTab = await _dbContext.RegabiturPublishtabs.FirstOrDefaultAsync(x => x.User.Id == request.UserId);

            if (publishTab == null)
            {
                throw new NotFoundException("PublishRecTab for AuthUser with Id", request.UserId);
            }

            _mapper.Map(request, publishTab);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to update a PublishTab");
            }

            return Unit.Value;
        }
    }
}