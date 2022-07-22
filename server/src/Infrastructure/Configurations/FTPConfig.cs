namespace Infrastructure.Configurations
{
    public class FTPConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RecTabsDeployPath { get; set; }
        public string UserDocumentsPath { get; set; }
    }
}