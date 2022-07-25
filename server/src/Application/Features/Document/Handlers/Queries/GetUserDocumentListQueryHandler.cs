using Application.DTO.Documentuser;
using Application.Features.Document.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Document.Handlers.Queries
{
    public class GetUserDocumentListQueryHandler : IRequestHandler<GetUserDocumentListQuery, ICollection<DocumentDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserDocumentListQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<DocumentDto>> Handle(GetUserDocumentListQuery request, CancellationToken cancellationToken)
        {
            var documents = await _dbContext.RegabiturDocumentusers
                .Where(x => x.UserId == request.UserId)
                .ProjectTo<DocumentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return documents;
        }
    }
}