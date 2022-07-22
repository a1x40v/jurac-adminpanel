using System.Diagnostics;
using Application.Common.Exceptions;
using Application.Contracts.Infrastructure;
using Application.DTO.FTP;
using Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Renci.SshNet;

namespace Infrastructure.FTP
{
    public class FTPService : IFTPService
    {
        private readonly IOptions<FTPConfig> _config;
        private SftpClient _sftpClient;
        public FTPService(IOptions<FTPConfig> config)
        {
            _config = config;
        }
        private void CreateClient()
        {
            var conf = _config.Value;
            var client = new SftpClient(conf.Host, conf.Port, conf.Username, conf.Password);
            client.Connect();
            if (client.IsConnected)
            {
                Debug.WriteLine("Connected to the SFTP server");
                _sftpClient = client;
            }
            else
            {
                Debug.WriteLine("Couldn't connect to the SFTP server");
                throw new ExternalResourceException("Couldn't connect to the SFTP server");
            }
        }
        private void CloseClient()
        {
            if (_sftpClient != null)
            {
                _sftpClient.Disconnect();
                _sftpClient.Dispose();
            }
        }
        private void UploadFiles(ICollection<FTPUploadDto> fileOpts, string path)
        {
            foreach (var fileOpt in fileOpts)
            {
                using (var fileStream = new MemoryStream())
                {
                    for (int i = 0; i < fileOpt.Data.Length; i++)
                    {
                        fileStream.WriteByte(fileOpt.Data[i]);
                    }
                    fileStream.Seek(0, SeekOrigin.Begin);
                    _sftpClient.BufferSize = 4 * 1024;
                    _sftpClient.UploadFile(fileStream, Path.Combine(path, fileOpt.FileName));
                }
            }
        }
        private void DeleteFiles(ICollection<string> fileNames, string path)
        {
            foreach (var fileName in fileNames)
            {
                string filePath = Path.Combine(path, fileName);
                if (_sftpClient.Exists(filePath))
                {
                    _sftpClient.DeleteFile(filePath);
                }
                else
                {
                    Debug.WriteLine($"Couldn't find the file to delete: {fileName}");
                }

            }
        }

        public void DeployPublishRecTabs(ICollection<FTPUploadDto> fileOpts)
        {
            var conf = _config.Value;

            CreateClient();

            UploadFiles(fileOpts, conf.RecTabsDeployPath);

            CloseClient();
        }

        public void CreateUserDocs(ICollection<FTPUploadDto> fileOpts, string userFolder)
        {
            var conf = _config.Value;
            string path = Path.Combine(conf.UserDocumentsPath, userFolder);

            CreateClient();

            UploadFiles(fileOpts, path);

            CloseClient();
        }
    }
}