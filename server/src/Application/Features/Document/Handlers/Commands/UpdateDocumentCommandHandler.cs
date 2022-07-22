
using Application.Common.Exceptions;
using Application.Contracts.Infrastructure;
using Application.Features.Document.Requests.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Document.Handlers.Commands
{
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFTPService _fTPService;
        public UpdateDocumentCommandHandler(ApplicationDbContext dbContext, IFTPService fTPService)
        {
            _dbContext = dbContext;
            _fTPService = fTPService;
        }
        public async Task<Unit> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = await _dbContext.RegabiturDocumentusers
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (document == null)
            {
                throw new NotFoundException($"Cannot find Document with id '{request.Id}'");
            }

            string path = Path.GetDirectoryName(document.Doc);

            return Unit.Value;
        }
    }
}