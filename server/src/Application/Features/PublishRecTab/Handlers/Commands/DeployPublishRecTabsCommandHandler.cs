using System.Linq.Expressions;
using Application.Contracts.Infrastructure;
using Application.DTO.FTP;
using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Commands;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
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
        private readonly IFTPService _ftpService;
        public DeployPublishRecTabsCommandHandler(ApplicationDbContext dbContext, IMapper mapper,
            IPdfExporterService exporterService, IFTPService ftpService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _ftpService = ftpService;
            _exporterService = exporterService;
        }
        public async Task<Unit> Handle(DeployPublishRecTabsCommand request, CancellationToken cancellationToken)
        {
            var deplOpts = new List<PublishRecTabDeployingOpt>
            {
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.BakOfoUp, FileName = "bakOfoUp.pdf", Title = "Бакалавриат ОФО Уголовно-правовой профиль"  },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.BakZfoUp,  FileName = "bakZfoUp.pdf", Title = "Бакалавриат ЗФО Уголовно-правовой профиль" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.BakOzfoUp,  FileName = "bakOzfoUp.pdf", Title = "Бакалавриат ОЗФО Уголовно-правовой профиль" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.BakOfoGp,  FileName = "bakOfoGp.pdf", Title = "Бакалавриат ОФО Гражданско-правовой профиль" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.BakZfoGp,  FileName = "bakZfoGp.pdf", Title = "Бакалавриат ЗФО Гражданско-правовой профиль" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.BakOzfoGp,  FileName = "bakOzfoGp.pdf", Title = "Бакалавриат ОЗФО Гражданско-правовой профиль" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.SpecOfoSd,  FileName = "specOfoSd.pdf", Title = "Специалитет ОФО Судебная деятельность" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.MagOfoPo,  FileName = "magOfoPo.pdf", Title = "Магистратура ОФО Правовое обеспечение гражданского оборота и предпринимательства" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.MagZfoPo,  FileName = "magZfoPo.pdf", Title = "Магистратура ЗФО Правовое обеспечение гражданского оборота и предпринимательства" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.MagOfoTp,  FileName = "magOfoTp.pdf", Title = "Магистратура ОФО Теория и практика применения законодательства в уголовно-правовой сфере" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.MagZfoTp,  FileName = "magZfoTp.pdf", Title = "Магистратура ЗФО Теория и практика применения законодательства в уголовно-правовой сфере" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.AspOfoGp,  FileName = "aspOfoGp.pdf", Title = "Аспирантура ОФО Теоретико-исторические правовые науки" },
                new PublishRecTabDeployingOpt { Selector = (recTab) => recTab.AspOfoUgp,  FileName = "aspOfoUgp.pdf", Title = "Аспирантура ОФО Уголовно-правовые науки" },
            };

            var filesToUpload = new List<FTPUploadDto>();

            foreach (var deplOpt in deplOpts)
            {
                var deployDtos = await _dbContext.RegabiturPublishrectabs
                    .Where(deplOpt.Selector)
                    .ProjectTo<PublishRecTabDeployDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var pdfFile = _exporterService.GeneratePdfExport(deployDtos, deplOpt.Title);

                filesToUpload.Add(new FTPUploadDto { FileName = deplOpt.FileName, Data = pdfFile });
            }

            _ftpService.DeployPublishRecTabs(filesToUpload);

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