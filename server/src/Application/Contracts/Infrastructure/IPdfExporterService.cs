using Application.DTO.PublishRecTab;

namespace Application.Contracts.Infrastructure
{
    public interface IPdfExporterService
    {
        public byte[] GeneratePdfExport(ICollection<PublishRecTabDeployDto> recTabs, string title);
    }
}