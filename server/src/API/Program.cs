using API;
using Persistence;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();

            await Seed.SeedData(context);
        }

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();

                var port = Environment.GetEnvironmentVariable("PORT");
                if (!String.IsNullOrWhiteSpace(port))
                {
                    webBuilder.UseUrls("http://*:" + port);
                }
            });
}