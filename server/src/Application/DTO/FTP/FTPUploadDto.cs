namespace Application.DTO.FTP
{
    public class FTPUploadDto
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}