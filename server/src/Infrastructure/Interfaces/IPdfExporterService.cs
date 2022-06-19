using Application.DTO.PublishRecTab;

namespace Infrastructure.Interfaces
{
    public interface IPdfExporterService
    {
        public byte[] GeneratePdfExport(ICollection<PublishRecTabExportDto> recTabs);
    }
}