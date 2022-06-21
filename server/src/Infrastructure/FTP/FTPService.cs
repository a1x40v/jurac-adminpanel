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
        public FTPService(IOptions<FTPConfig> config)
        {
            _config = config;
        }
        public void UploadFiles(ICollection<FTPUploadDto> fileOpts)
        {
            var conf = _config.Value;

            using (var client = new SftpClient(conf.Host, conf.Port, conf.Username, conf.Password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    Debug.WriteLine("I'm connected to the client");

                    foreach (var fileOpt in fileOpts)
                    {
                        using (var fileStream = new MemoryStream())
                        {
                            for (int i = 0; i < fileOpt.Data.Length; i++)
                            {
                                fileStream.WriteByte(fileOpt.Data[i]);
                            }
                            fileStream.Seek(0, SeekOrigin.Begin);
                            client.BufferSize = 4 * 1024;
                            client.UploadFile(fileStream, Path.Combine(conf.RecTabsDeployPath, fileOpt.FileName));
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("I couldn't connect");
                    throw new ExternalResourceException("Couldn't connect to the FTP server");
                }

                client.Disconnect();
            }
        }
    }
}