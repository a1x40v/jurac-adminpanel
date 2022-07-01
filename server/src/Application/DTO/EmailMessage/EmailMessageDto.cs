
namespace Application.DTO.EmailMessage
{
    public class EmailMessageDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string SenderUsername { get; set; }
        public string RecipientUsername { get; set; }
        public DateTime SentAt { get; set; }
        public string RecipientEmail { get; set; }
    }
}