namespace Domain
{
    public class AdminpanelEmailmessage
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int RecipientId { get; set; }
        public string RecipientEmail { get; set; }
        public int SenderId { get; set; }
        public DateTime SentAt { get; set; }

        public virtual AuthUser Recipient { get; set; }
        public virtual AuthUser Sender { get; set; }
    }
}