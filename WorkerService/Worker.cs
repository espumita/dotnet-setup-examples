using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Services;

namespace WorkerService {
    public class Worker : BackgroundService {
        private readonly RandomStringGenerator randomStringGenerator;

        public Worker(RandomStringGenerator randomStringGenerator) {
            this.randomStringGenerator = randomStringGenerator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            var randomString = randomStringGenerator.Generate();
            Console.WriteLine(randomString);
        }
    }
}