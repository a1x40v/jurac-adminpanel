using Application.DTO.FTP;

namespace Application.Contracts.Infrastructure
{
    public interface IFTPService
    {
        void UploadFiles(ICollection<FTPUploadDto> fileOpts, string uploadPath);
        void DeployPublishRecTabs(ICollection<FTPUploadDto> fileOpts);
    }
}