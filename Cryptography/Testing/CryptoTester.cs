using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Test
{
    public class CryptoTester<C, F> : Tester where C: Crypter, new() where F : FileCrypter<C>, new()
    {
        F _fileCrypter;

        public void Test()
        {
        }
    }
}
