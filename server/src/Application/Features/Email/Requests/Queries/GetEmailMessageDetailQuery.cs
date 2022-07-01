using Application.DTO.EmailMessage;
using MediatR;

namespace Application.Features.Email.Requests.Queries
{
    public class GetEmailMessageDetailQuery : IRequest<EmailMessageDto>
    {
        public int Id { get; set; }
    }
}