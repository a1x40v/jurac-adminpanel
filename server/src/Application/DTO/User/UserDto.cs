using Application.DTO.Documentuser;

namespace Application.DTO.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string SendingStatus { get; set; }
        public bool CompleteFlag { get; set; }
        public bool AgreementFlag { get; set; }
        public bool WorkFlag { get; set; }
        public bool SuccessFlag { get; set; }
        public string Address { get; set; }
        public string CommentAdmin { get; set; }
        public string DateOfDoc { get; set; }
        public string NameUz { get; set; }
        public string Passport { get; set; }
        public string Snils { get; set; }
        public string Message { get; set; }
        public ICollection<DocumentuserDto> Documents { get; set; }
    }
}