using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Queries
{
    public class GetPublishRecTabDetailQueryHandler : IRequestHandler<GetPublishRecTabDetailQuery, PublishRecTabDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPublishRecTabDetailQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<PublishRecTabDto> Handle(GetPublishRecTabDetailQuery request, CancellationToken cancellationToken)
        {
            var publishTab = await _dbContext.RegabiturPublishrectabs
                .Where(x => x.User.Id == request.UserId)
                .ProjectTo<PublishRecTabDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return publishTab;
        }
    }
}