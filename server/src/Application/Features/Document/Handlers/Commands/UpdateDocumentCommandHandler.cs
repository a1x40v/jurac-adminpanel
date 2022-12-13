
using Application.Common.Exceptions;
using Application.Contracts.Infrastructure;
using Application.DTO.FTP;
using Application.Features.Document.Requests.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Document.Handlers.Commands
{
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFTPUserDocsService _fTPDocsService;
        public UpdateDocumentCommandHandler(ApplicationDbContext dbContext, IFTPUserDocsService fTPDocsService)
        {
            _dbContext = dbContext;
            _fTPDocsService = fTPDocsService;
        }
        public async Task<Unit> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _dbContext.RegabiturDocumentusers
                .FirstOrDefaultAsync(x => x.Id == request.DocId);

            if (document == null)
            {
                throw new NotFoundException($"Cannot find Document with id '{request.DocId}'");
            }

            string userFolder = Path.GetDirectoryName(document.Doc);
            string updatingDoc = Path.Combine(userFolder, request.FileName);
            bool isFileChanged = request.FileBytes.Count() != 0;

            if (isFileChanged)
            {
                var docUploadDto = new FTPUploadDto { FileName = request.FileName, Data = request.FileBytes };
                _fTPDocsService.UpdateUserDoc(docUploadDto, document.Doc);
            }

            if (updatingDoc != document.Doc)
            {
                if (!isFileChanged)
                {
                    _fTPDocsService.RenameDoc(document.Doc, updatingDoc);
                }

                document.Doc = updatingDoc;
                document.NameDoc = request.DocType;

                var result = await _dbContext.SaveChangesAsync() > 0;

                if (!result)
                {
                    throw new DatabaseException("Failed to update a document");
                }
            }

            return Unit.Value;
        }
    }
}