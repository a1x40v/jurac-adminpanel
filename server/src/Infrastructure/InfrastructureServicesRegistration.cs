using Application.Contracts.Infrastructure;
using DinkToPdf;
using DinkToPdf.Contracts;
using Infrastructure.Features.PublishRecTab.PdfExport;
using Infrastructure.Features.Users;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUserExporter, UserExporter>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IPdfExporterService, PdfExporterService>();

            return services;
        }
    }
}