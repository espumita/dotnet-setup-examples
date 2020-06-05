using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication.Controllers {

    
    [Route("MyController")]
    public class MyController : Controller {
        private readonly RandomStringGenerator randomStringGenerator;


        public MyController(RandomStringGenerator randomStringGenerator) {
            this.randomStringGenerator = randomStringGenerator;
        }

        [HttpGet]
        public ActionResult Endpoint() {
            var randomString = randomStringGenerator.Generate();
            return Ok(randomString);
        }
        
    }
}