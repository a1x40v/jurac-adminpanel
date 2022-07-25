using Application.DTO.FTP;

namespace Application.Contracts.Infrastructure
{
    public interface IFTPService
    {
        void DeployPublishRecTabs(ICollection<FTPUploadDto> fileOpts);
        void CreateUserDocs(ICollection<FTPUploadDto> fileOpts, string userFolderPath);
        void DeleteUserDocs(ICollection<string> docPaths);
    }
}