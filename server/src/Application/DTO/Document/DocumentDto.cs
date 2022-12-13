namespace Application.DTO.Document
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DatePub { get; set; }
        public string NameDoc { get; set; }
        public string Doc { get; set; }
    }
}