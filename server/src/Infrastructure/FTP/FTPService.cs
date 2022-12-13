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
        private SftpClient _sftpClient;
        protected readonly FTPConfig Config;
        public FTPService(IOptions<FTPConfig> config)
        {
            Config = config.Value;
        }
        protected void CreateClient()
        {
            var client = new SftpClient(Config.Host, Config.Port, Config.Username, Config.Password);
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
        protected void CloseClient()
        {
            if (_sftpClient != null)
            {
                _sftpClient.Disconnect();
                _sftpClient.Dispose();
            }
        }

        protected bool CheckIfFileExists(string path)
        {
            return _sftpClient.Exists(path);
        }

        protected void CreateDirectory(string path)
        {
            if (!_sftpClient.Exists(path))
            {
                _sftpClient.CreateDirectory(path);
            }
        }
        protected void UploadFiles(ICollection<FTPUploadDto> fileOpts, string path)
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

        protected void RenameFile(string oldPath, string newPath)
        {
            _sftpClient.RenameFile(oldPath, newPath);
        }

        protected void DeleteFiles(ICollection<string> paths)
        {
            foreach (var path in paths)
            {
                if (_sftpClient.Exists(path))
                {
                    _sftpClient.DeleteFile(path);
                }
                else
                {
                    Debug.WriteLine($"Couldn't find the file to delete: {path}");
                }
            }
        }

        protected MemoryStream GetFileContent(string path)
        {
            MemoryStream stream = new MemoryStream();

            if (_sftpClient.Exists(path))
            {
                _sftpClient.DownloadFile(path, stream);
            }

            return stream;
        }

        public void DeployPublishRecTabs(ICollection<FTPUploadDto> fileOpts)
        {
            CreateClient();

            UploadFiles(fileOpts, Config.RecTabsDeployPath);

            CloseClient();
        }
    }
}