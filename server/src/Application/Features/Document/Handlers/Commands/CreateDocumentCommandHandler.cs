using Application.Common.Exceptions;
using Application.Contracts.Infrastructure;
using Application.DTO.FTP;
using Application.Features.Document.Requests.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Document.Handlers.Commands
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFTPService _fTPService;
        public CreateDocumentCommandHandler(ApplicationDbContext dbContext, IFTPService fTPService)
        {
            _dbContext = dbContext;
            _fTPService = fTPService;

        }
        public async Task<Unit> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.AuthUsers
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"Cannot find AuthUser with id '{request.UserId}'");
            }

            var docUploadDtos = new List<FTPUploadDto> {
                new FTPUploadDto { FileName = request.FileName, Data = request.File }
            };

            string userFolder = $"{user.Id}_{user.FirstName} {user.LastName}";

            _fTPService.CreateUserDocs(docUploadDtos, userFolder);

            return Unit.Value;
        }
    }
}