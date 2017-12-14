using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Test;
using Cryptography.AES;

namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestEngine.TimedCryptoTest<AESCrypter>());
        }
    }
}
