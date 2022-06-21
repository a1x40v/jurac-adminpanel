using Application.Contracts.Infrastructure;
using Application.DTO.PublishRecTab;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace Infrastructure.Features.PublishRecTab.PdfExport
{
    public class PdfExporterService : IPdfExporterService
    {
        private readonly IConverter _converter;
        public PdfExporterService(IConverter converter)
        {
            _converter = converter;
        }
        public byte[] GeneratePdfExport(ICollection<PublishRecTabDeployDto> recTabs, string title)
        {
            var html = HtmlTemplateGenerator.GetHTMLString(recTabs, title);

            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Landscape;
            globalSettings.PaperSize = PaperKind.A4;
            globalSettings.Margins = new MarginSettings { Top = 28, Bottom = 25 };

            ObjectSettings objectSettings = new ObjectSettings();
            objectSettings.PagesCount = true;
            objectSettings.HtmlContent = html;

            WebSettings webSettings = new WebSettings();
            webSettings.DefaultEncoding = "utf-8";

            webSettings.UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "../Infrastructure/Features/PublishRecTab/PdfExport/Assets", "rectab-styles.css");

            HeaderSettings headerSettings = new HeaderSettings();
            headerSettings.FontSize = 15;
            headerSettings.FontName = "Ariel";
            headerSettings.Right = "Страница [page] из [toPage]";
            headerSettings.Spacing = 2.5;

            objectSettings.HeaderSettings = headerSettings;
            objectSettings.WebSettings = webSettings;

            HtmlToPdfDocument htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };

            return _converter.Convert(htmlToPdfDocument);
        }
    }
}