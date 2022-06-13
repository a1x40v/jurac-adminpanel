#nullable disable

namespace Domain
{
    public partial class RegabiturCustomuser
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string SendingStatus { get; set; }
        public bool CompleteFlag { get; set; }
        public bool AgreementFlag { get; set; }
        public int UserId { get; set; }
        public bool WorkFlag { get; set; }
        public bool SuccessFlag { get; set; }
        public string Address { get; set; }
        public string CommentAdmin { get; set; }
        public string DateOfDoc { get; set; }
        public string NameUz { get; set; }
        public string Passport { get; set; }
        public string Snils { get; set; }
        public string Message { get; set; }

        public virtual AuthUser User { get; set; }
    }
}
