using System.Security.Cryptography;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace WpfApp {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private readonly IServiceScope serviceScope;
        private readonly ServiceProvider serviceProvider;
        
        public App() {
            var services = new ServiceCollection();
            RegisterServices(services);
            serviceProvider = services.BuildServiceProvider();
            serviceScope = serviceProvider.CreateScope();
        }

        private static void RegisterServices(IServiceCollection services) {
            var sha512Managed = new SHA512Managed();
            services.AddSingleton<RandomStringGenerator>(new SHARandomStringGenerator(sha512Managed));
            services.AddSingleton<MainWindow>();
        }


        protected override void OnStartup(StartupEventArgs args) {
            var application = serviceScope.ServiceProvider.GetService<MainWindow>();
            application.Show();
        }
        
        
        
        

        protected override void OnExit(ExitEventArgs e) {
            DisposeServices(serviceProvider);
        }

        private static void DisposeServices(ServiceProvider serviceProvider) {
            serviceProvider?.Dispose();
        }
    }
}