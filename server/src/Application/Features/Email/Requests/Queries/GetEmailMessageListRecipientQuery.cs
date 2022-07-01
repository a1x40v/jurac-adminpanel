using Application.DTO.EmailMessage;
using MediatR;

namespace Application.Features.Email.Requests.Queries
{
    public class GetEmailMessageListRecipientQuery : IRequest<ICollection<EmailMessageDto>>
    {
        public int RecipientId { get; set; }
    }
}