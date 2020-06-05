using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Services {

    public class SHARandomStringGenerator : RandomStringGenerator {
        private readonly SHA512Managed  sha512Managed;

        public SHARandomStringGenerator(SHA512Managed   sha512Managed) {
            this.sha512Managed = sha512Managed;
        }


        public string Generate() {
            var hashedBytes = sha512Managed.ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
            var builder = new StringBuilder();
            hashedBytes.ToList().ForEach(x=> builder.Append(x.ToString("x2")));
            return builder.ToString();
        }
    }
}