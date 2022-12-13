using Application.DTO.FTP;

namespace Application.Contracts.Infrastructure
{
    public interface IFTPService
    {
        void DeployPublishRecTabs(ICollection<FTPUploadDto> fileOpts);
    }
}