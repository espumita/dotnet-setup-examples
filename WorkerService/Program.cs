using System.Security.Cryptography;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace WorkerService {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) => {
                    RegisterServices(services);
                    services.AddHostedService<Worker>();
                });
        
        private static void RegisterServices(IServiceCollection services) {
            var sha512Managed = new SHA512Managed();
            services.AddSingleton<RandomStringGenerator>(new SHARandomStringGenerator(sha512Managed));
        }
    }
}