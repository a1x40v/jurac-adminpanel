namespace API.DTO.Document
{
    public class UpdateDocumentDto
    {
        public int DocId { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
        public string DocType { get; set; }
    }
}