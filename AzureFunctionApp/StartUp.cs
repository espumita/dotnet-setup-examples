
using System.Security.Cryptography;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Services;

[assembly: FunctionsStartup(typeof(MyAzureFunction.StartUp))]

namespace MyAzureFunction {

    public class StartUp : FunctionsStartup {
        
        public override void Configure(IFunctionsHostBuilder builder) {
            RegisterServices(builder.Services);
        }
        
        private static void RegisterServices(IServiceCollection services) {
            var sha512Managed = new SHA512Managed();
            services.AddSingleton<RandomStringGenerator>(new SHARandomStringGenerator(sha512Managed));
        }
    }
}