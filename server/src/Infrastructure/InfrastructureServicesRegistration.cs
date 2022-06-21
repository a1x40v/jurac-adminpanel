using Application.Contracts.Infrastructure;
using DinkToPdf;
using DinkToPdf.Contracts;
using Infrastructure.Configurations;
using Infrastructure.Features.PublishRecTab.PdfExport;
using Infrastructure.Features.Users;
using Infrastructure.FTP;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUserExporter, UserExporter>();
            services.AddScoped<IFTPService, FTPService>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IPdfExporterService, PdfExporterService>();

            services.Configure<FTPConfig>(config.GetSection("FTP"));

            return services;
        }
    }
}