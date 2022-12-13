using Application.Common.Exceptions;
using Application.Contracts.Infrastructure;
using Application.Features.Document.Requests.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Document.Handlers.Commands
{
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFTPUserDocsService _fTPDocsService;
        public DeleteDocumentCommandHandler(ApplicationDbContext dbContext, IFTPUserDocsService fTPDocsService)
        {
            _dbContext = dbContext;
            _fTPDocsService = fTPDocsService;
        }
        public async Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _dbContext.RegabiturDocumentusers
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (document == null)
            {
                throw new NotFoundException($"Cannot find Document with id '{request.Id}'");
            }

            _fTPDocsService.DeleteUserDocs(new List<string> { document.Doc });

            _dbContext.Remove(document);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to delete a document");
            }

            return Unit.Value;
        }
    }
}