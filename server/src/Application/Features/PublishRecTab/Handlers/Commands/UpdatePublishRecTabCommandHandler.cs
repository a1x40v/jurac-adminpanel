using Application.Common.Exceptions;
using Application.Features.PublishRecTab.Requests.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Commands
{
    public class UpdatePublishRecTabCommandHandler : IRequestHandler<UpdatePublishRecTabCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdatePublishRecTabCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePublishRecTabCommand request, CancellationToken cancellationToken)
        {
            var publishRecTab = await _dbContext.RegabiturPublishrectabs.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (publishRecTab == null)
            {
                throw new NotFoundException("PublishRecTab", request.Id);
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