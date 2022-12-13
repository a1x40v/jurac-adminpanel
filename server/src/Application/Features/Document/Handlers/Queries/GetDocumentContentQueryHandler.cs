using Application.Common.Exceptions;
using Application.Contracts.Infrastructure;
using Application.Features.Document.Requests.Queries;
using MediatR;
using Persistence;

namespace Application.Features.Document.Handlers.Queries
{
    public class GetDocumentContentQueryHandler : IRequestHandler<GetDocumentContentQuery, MemoryStream>
    {
        private readonly IFTPUserDocsService _fTPDocsService;
        private readonly ApplicationDbContext _dbContext;
        public GetDocumentContentQueryHandler(ApplicationDbContext dbContext, IFTPUserDocsService fTPDocsService)
        {
            _dbContext = dbContext;
            _fTPDocsService = fTPDocsService;
        }
        public async Task<MemoryStream> Handle(GetDocumentContentQuery request, CancellationToken cancellationToken)
        {
            var document = await _dbContext.RegabiturDocumentusers.FindAsync(request.Id);

            if (document == null)
            {
                throw new NotFoundException($"Cannot find the document with id {request.Id}");
            }

            return _fTPDocsService.GetUserDocContent(document.Doc);
        }
    }
}