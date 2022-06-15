using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Queries
{
    public class GetPublishRecTabListQueryHandler : IRequestHandler<GetPublishRecTabListQuery, ICollection<PublishRecTabDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPublishRecTabListQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<PublishRecTabDto>> Handle(GetPublishRecTabListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.RegabiturPublishrectabs
                .ProjectTo<PublishRecTabDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}