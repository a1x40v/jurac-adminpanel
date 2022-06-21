namespace Application.Contracts.Infrastructure
{
    public interface IFTPUploadOption
    {
        string FileName { get; set; }
        byte[] Data { get; set; }
    }
}