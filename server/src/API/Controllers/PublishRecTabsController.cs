using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Commands;
using Application.Features.PublishRecTab.Requests.Queries;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PublishRecTabsController : BaseApiController
    {
        private readonly IPdfExporterService _exporterService;
        public PublishRecTabsController(IPdfExporterService exporterService)
        {
            _exporterService = exporterService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<PublishRecTabDto>>> GetAllPublishRecTabs()
        {
            return Ok(await Mediator.Send(new GetPublishRecTabListQuery()));
        }

        [HttpPost]
        public async Task<ActionResult> CreatePublishRecTabs(CreatePublishRecTabCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("users/{userId}")]
        public async Task<ActionResult> UpdatePublishRecTab(int userId, UpdatePublishRecTabCommand command)
        {
            if (userId != command.UserId) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("users/{userId}")]
        public async Task<ActionResult> DeletePublishRecTab(int userId)
        {
            await Mediator.Send(new DeletePublishRecTabCommand { UserId = userId });

            return NoContent();
        }

        [HttpPost("export")]
        public async Task<ActionResult> ExportPublishRecTabs()
        {
            var pdfFile = _exporterService.GeneratePdfExport(new List<PublishRecTabExportDto> {
                new PublishRecTabExportDto { UserId=900, Snils="124-061-007 94", TestType="ВИ", SumPoints=270,
                    ObshPoint=70, RusPoint = 60, ChosenPoint = 80, IndividPoint = 5, SostType="Рекомендован",
                    Sogl = "Подано", Advantage = "Нет"},
                new PublishRecTabExportDto { UserId=900, Snils="124-061-007 94", TestType="ВИ", SumPoints=270,
                    ObshPoint=70, RusPoint = 60, ChosenPoint = 80, IndividPoint = 5, SostType="Рекомендован",
                    Sogl = "Подано", Advantage = "Нет"}
            });
            return File(pdfFile,
            "application/octet-stream", "SimplePdf.pdf");
        }
    }
}