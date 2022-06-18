using Application.Common.Exceptions;
using Application.DTO.PublishTab;
using Application.Features.PublishTab.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishTab.Handlers.Queries
{
    public class GetPublishTabDetailQueryHandler : IRequestHandler<GetPublishTabDetailQuery, PublishTabDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPublishTabDetailQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PublishTabDto> Handle(GetPublishTabDetailQuery request, CancellationToken cancellationToken)
        {
            var publishTab = await _dbContext.RegabiturPublishtabs
                .Where(x => x.User.Id == request.UserId)
                .ProjectTo<PublishTabDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (publishTab == null)
            {
                throw new NotFoundException("PublishTab for AuthUser with Id", request.UserId);
            }

            return publishTab;
        }
    }
}