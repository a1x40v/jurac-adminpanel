using Application.DTO.RectabModification;
using Application.Features.RectabModification.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.RectabModification.Handlers.Queries
{
    public class GetRectabModificationListQueryHandler : IRequestHandler<GetRectabModificationListQuery, ICollection<RectabModificationDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetRectabModificationListQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<RectabModificationDto>> Handle(GetRectabModificationListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.AdminpanelRectabmodifications
                .Include(x => x.Abiturient)
                .OrderByDescending(x => x.CreatedAt)
                .ProjectTo<RectabModificationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}