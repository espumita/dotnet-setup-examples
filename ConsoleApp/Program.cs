using System.Security.Cryptography;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {
            var services = new ServiceCollection();
            RegisterServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var serviceScope = serviceProvider.CreateScope();
            var application = serviceScope.ServiceProvider.GetService<MyConsoleApplication>();
            application.Start();
            DisposeServices(serviceProvider);
        }

        private static void RegisterServices(IServiceCollection services) {
            var sha512Managed = new SHA512Managed();
            services.AddSingleton<RandomStringGenerator>(new SHARandomStringGenerator(sha512Managed));
            services.AddSingleton<MyConsoleApplication>();
        }

        private static void DisposeServices(ServiceProvider serviceProvider) {
            serviceProvider?.Dispose();
        }
    }
}