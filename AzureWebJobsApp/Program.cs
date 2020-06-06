using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace AzureWebJobsApp {
    class Program {

        public static async Task Main(string[] args) {
            var host = CreateHostBuilder().Build();
            using (host) {
                await host.RunAsync();
            }
        }

        private static IHostBuilder CreateHostBuilder() =>
            new HostBuilder()
                .ConfigureWebJobs(builder => {
                    builder.AddAzureStorageCoreServices()
                           .AddAzureStorage()
                           .AddTimers();
                })
                .ConfigureServices(services => {
                    RegisterServices(services);
                });
        
        private static void RegisterServices(IServiceCollection services) {
            var sha512Managed = new SHA512Managed();
            services.AddSingleton<RandomStringGenerator>(new SHARandomStringGenerator(sha512Managed));
        }
    }

}