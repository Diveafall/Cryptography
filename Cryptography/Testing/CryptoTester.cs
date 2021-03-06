﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Test
{
    public class CryptoTester<C> : Tester where C: Crypter, new()
    {
        FileCrypter<C> _fileCrypter = new FileCrypter<C>();

        public void Test()
        {
            _fileCrypter.Encrypt();
            _fileCrypter.Decrypt();
        }

        public static long TimedTest<T>(T tester) where T : Tester
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            tester.Test();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
