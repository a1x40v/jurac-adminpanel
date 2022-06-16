#nullable disable

namespace Domain
{
    public partial class AuthUser
    {
        public AuthUser()
        {
            RegabiturDocumentusers = new HashSet<RegabiturDocumentuser>();
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsSuperuser { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsStaff { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateJoined { get; set; }

        public virtual RegabiturAdditionalinfo RegabiturAdditionalinfo { get; set; }
        public virtual RegabiturCustomuser RegabiturCustomuser { get; set; }
        public virtual RegabiturPublishrectab RegabiturPublishrectab { get; set; }
        public virtual RegabiturPublishtab RegabiturPublishtab { get; set; }
        public virtual ICollection<RegabiturDocumentuser> RegabiturDocumentusers { get; set; }
    }
}
