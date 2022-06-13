using Application.Contracts.Infrastructure;
using Application.Features.Users.Requests.Queries;
using MediatR;

namespace Application.Features.Users.Handlers.Queries
{
    public class ExportUsersQueryHandler : IRequestHandler<ExportUsersQuery, MemoryStream>
    {
        private readonly IUserExporter _userExporter;
        public ExportUsersQueryHandler(IUserExporter userExporter)
        {
            _userExporter = userExporter;
        }

        public Task<MemoryStream> Handle(ExportUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userExporter.ExportUsers(request.Users));
        }
    }
}