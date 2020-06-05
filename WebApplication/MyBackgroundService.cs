using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Services;

namespace WebApplication {
    public class MyBackgroundService : BackgroundService {
        private readonly RandomStringGenerator randomStringGenerator;
        private Timer timer;

        public MyBackgroundService(RandomStringGenerator randomStringGenerator) {
            this.randomStringGenerator = randomStringGenerator;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) {
            timer = new Timer(DoWork, null, TimeSpan.Zero,TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void DoWork(object state) {
            var randomString = randomStringGenerator.Generate();
            Console.WriteLine(randomString);
        }

        public override Task StopAsync(CancellationToken cancellationToken) {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }


        public override void Dispose() {
            timer?.Dispose();
        }
    }
}