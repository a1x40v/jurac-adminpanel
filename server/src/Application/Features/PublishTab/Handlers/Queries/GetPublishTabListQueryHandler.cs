using Application.DTO.PublishTab;
using Application.Features.PublishTab.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishTab.Handlers.Queries
{
    public class GetPublishTabListQueryHandler : IRequestHandler<GetPublishTabListQuery, ICollection<PublishTabDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPublishTabListQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<PublishTabDto>> Handle(GetPublishTabListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.RegabiturPublishtabs
                .OrderByDescending(x => x.DatePub)
                .ProjectTo<PublishTabDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}