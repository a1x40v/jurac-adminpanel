using API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        await host.RunAsync();
    }

    public static void AddAppConfiguration(HostBuilderContext hostingContext, IConfigurationBuilder config)
    {
        config.AddKeyPerFile(directoryPath: "/run/secrets", optional: true);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(AddAppConfiguration)
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