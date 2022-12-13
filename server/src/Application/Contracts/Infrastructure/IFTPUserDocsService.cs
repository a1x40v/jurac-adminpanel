using Application.DTO.FTP;

namespace Application.Contracts.Infrastructure
{
    public interface IFTPUserDocsService
    {
        bool CheckIfDocExists(string userFolder, string fileName);
        void CreateUserDocs(ICollection<FTPUploadDto> fileOpts, string userFolderPath);
        void UpdateUserDoc(FTPUploadDto fileOpt, string updatingFile);
        void RenameDoc(string oldPath, string newPath);
        void DeleteUserDocs(ICollection<string> docPaths);
        MemoryStream GetUserDocContent(string docPath);
    }
}