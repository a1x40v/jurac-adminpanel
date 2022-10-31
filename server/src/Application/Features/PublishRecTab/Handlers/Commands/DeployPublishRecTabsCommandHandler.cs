using System.Linq.Expressions;
using Application.Contracts.Application;
using Application.Contracts.Infrastructure;
using Application.DTO.FTP;
using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.Constants;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.PublishRecTab.Handlers.Commands
{
    public class DeployPublishRecTabsCommandHandler : IRequestHandler<DeployPublishRecTabsCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPdfExporterService _exporterService;
        private readonly IFTPService _fTPService;
        private readonly IPublishRecTabService _publishRecTabService;
        public DeployPublishRecTabsCommandHandler(ApplicationDbContext dbContext, IMapper mapper,
            IPdfExporterService exporterService, IFTPService fTPService, IPublishRecTabService publishRecTabService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _fTPService = fTPService;
            _exporterService = exporterService;
            _publishRecTabService = publishRecTabService;
        }
        public async Task<Unit> Handle(DeployPublishRecTabsCommand request, CancellationToken cancellationToken)
        {

            var recTabs = await _dbContext.RegabiturPublishrectabs
                .Where(x => x.IsPublished)
                .ProjectTo<PublishRecTabDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var deployedTabs = _publishRecTabService.GetDeployedTabs(recTabs);

            var filesToUpload = new List<FTPUploadDto>();

            foreach (var key in deployedTabs.Keys)
            {
                var depTabs = deployedTabs[key];
                var pdfFile = _exporterService.GeneratePdfExport(depTabs, EduProfilesConstants.Titles[key]);
                string fileName = $"{Enum.GetName(typeof(EduProfileType), key)}.pdf";
                filesToUpload.Add(new FTPUploadDto { FileName = fileName, Data = pdfFile });
            }

            _fTPService.UploadFiles(filesToUpload);

            _dbContext.AdminpanelRectabmodifications.RemoveRange(_dbContext.AdminpanelRectabmodifications);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }

    public class PublishRecTabDeployingOpt
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public Expression<Func<RegabiturPublishrectab, bool>> Selector { get; set; }
    }
}