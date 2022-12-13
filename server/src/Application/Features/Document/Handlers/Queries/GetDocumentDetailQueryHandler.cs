using Application.Common.Exceptions;
using Application.DTO.Document;
using Application.Features.Document.Requests.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Document.Handlers.Queries
{
    public class GetDocumentDetailQueryHandler : IRequestHandler<GetDocumentDetailQuery, DocumentDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetDocumentDetailQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DocumentDto> Handle(GetDocumentDetailQuery request, CancellationToken cancellationToken)
        {
            var document = await _dbContext.RegabiturDocumentusers
                .Where(x => x.Id == request.Id)
                .ProjectTo<DocumentDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (document == null)
            {
                throw new NotFoundException("Document", request.Id);
            }

            return document;
        }
    }
}