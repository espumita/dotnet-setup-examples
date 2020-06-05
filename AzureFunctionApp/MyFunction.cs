using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Services;

namespace MyAzureFunction {

    public class MyFunction {
        
        private readonly RandomStringGenerator randomStringGenerator;

        public MyFunction(RandomStringGenerator randomStringGenerator) {
            this.randomStringGenerator = randomStringGenerator;
        }

        [FunctionName("MyFunction")]
        public async Task<IActionResult> Get([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest request) {
            var randomString = randomStringGenerator.Generate();
            return new OkObjectResult(randomString);
        }
        
    }
}