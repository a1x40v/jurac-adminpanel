#nullable disable

namespace Domain
{
    public partial class RegabiturDocumentuser
    {
        public int Id { get; set; }
        public DateTime DatePub { get; set; }
        public string NameDoc { get; set; }
        public string Doc { get; set; }
        public int UserId { get; set; }

        public virtual AuthUser User { get; set; }
    }
}
