using Application.Contracts.Infrastructure;
using Application.DTO.FTP;
using Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace Infrastructure.FTP
{
    public class FTPUserDocsService : FTPService, IFTPUserDocsService
    {
        public FTPUserDocsService(IOptions<FTPConfig> config)
            : base(config)
        {
        }

        public bool CheckIfDocExists(string userFolder, string fileName)
        {
            string path = Path.Combine(Config.UserDocumentsPath, userFolder, fileName);

            return CheckIfFileExists(path);
        }

        public void CreateUserDocs(ICollection<FTPUploadDto> fileOpts, string userFolder)
        {
            string path = Path.Combine(Config.UserDocumentsPath, userFolder);

            CreateClient();

            CreateDirectory(path);

            UploadFiles(fileOpts, path);

            CloseClient();
        }

        public void UpdateUserDoc(FTPUploadDto fileOpt, string updatingFile)
        {
            string userFolder = Path.GetDirectoryName(updatingFile);
            string updatingPath = Path.Combine(Config.UserDocumentsPath, updatingFile);

            CreateClient();

            DeleteFiles(new List<string> { updatingPath });
            string path = Path.Combine(Config.UserDocumentsPath, userFolder);
            UploadFiles(new List<FTPUploadDto> { fileOpt }, path);

            CloseClient();
        }

        public void RenameDoc(string oldDoc, string newDoc)
        {
            CreateClient();

            string oldPath = Path.Combine(Config.UserDocumentsPath, oldDoc);
            string newPath = Path.Combine(Config.UserDocumentsPath, newDoc);
            RenameFile(oldPath, newPath);

            CloseClient();
        }

        public void DeleteUserDocs(ICollection<string> docPaths)
        {
            var paths = docPaths.Select(x => Path.Combine(Config.UserDocumentsPath, x)).ToList();

            CreateClient();

            DeleteFiles(paths);

            CloseClient();
        }

        public MemoryStream GetUserDocContent(string docPath)
        {
            string path = Path.Combine(Config.UserDocumentsPath, docPath);

            CreateClient();

            MemoryStream content = GetFileContent(path);

            CloseClient();

            return content;
        }
    }
}