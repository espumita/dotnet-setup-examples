using System;
using Microsoft.Azure.WebJobs;
using Services;

namespace AzureWebJobsApp {

    public class MyJobs {
        private readonly RandomStringGenerator randomStringGenerator;

        public MyJobs(RandomStringGenerator randomStringGenerator) {
            this.randomStringGenerator = randomStringGenerator;
        }


        public void DoWork([TimerTrigger("0 */1 * * * *", RunOnStartup = true)]TimerInfo timerInfo) {
            var randomString = randomStringGenerator.Generate();
            Console.WriteLine(randomString);
        }
        
    }
}