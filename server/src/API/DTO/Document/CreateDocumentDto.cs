namespace API.DTO.Document
{
    public class CreateDocumentDto
    {
        public int UserId { get; set; }
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string DocType { get; set; }
    }
}