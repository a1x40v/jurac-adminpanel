using Application.Common.Exceptions;
using Application.Contracts.Infrastructure;
using Application.DTO.FTP;
using Application.Features.Document.Requests.Commands;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Document.Handlers.Commands
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFTPUserDocsService _fTPDocsService;
        public CreateDocumentCommandHandler(ApplicationDbContext dbContext, IFTPUserDocsService fTPDocsService)
        {
            _dbContext = dbContext;
            _fTPDocsService = fTPDocsService;

        }
        public async Task<Unit> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.AuthUsers
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"Cannot find AuthUser with id '{request.UserId}'");
            }

            string userFolder = $"{user.Id}_{user.FirstName} {user.LastName}";
            string fullPath = Path.Combine(userFolder, request.FileName);

            var existedDoc = await _dbContext.RegabiturDocumentusers.FirstOrDefaultAsync(x => x.NameDoc == fullPath);

            Console.WriteLine(fullPath);
            Console.WriteLine(existedDoc);

            if (existedDoc != null)
            {
                throw new DatabaseException($"File ${fullPath} already exists");
            }

            // create a file on the server
            var docUploadDtos = new List<FTPUploadDto>
            {
                new FTPUploadDto { FileName = request.FileName, Data = request.FileBytes }
            };

            _fTPDocsService.CreateUserDocs(docUploadDtos, userFolder);

            // create a record in the DB
            var newDoc = new RegabiturDocumentuser
            {
                DatePub = DateTime.UtcNow.AddHours(3),
                NameDoc = request.DocType,
                Doc = fullPath,
                User = user
            };

            _dbContext.Add(newDoc);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to create a document");
            }

            return Unit.Value;
        }
    }
}