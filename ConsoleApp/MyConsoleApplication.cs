using System;
using Services;

namespace ConsoleApp {
    public class MyConsoleApplication {
        private readonly RandomStringGenerator randomStringGenerator;


        public MyConsoleApplication(RandomStringGenerator randomStringGenerator) {
            this.randomStringGenerator = randomStringGenerator;
        }

        public void Start() {
            var randomString = randomStringGenerator.Generate();
            Console.WriteLine(randomString);
        }
    }
}