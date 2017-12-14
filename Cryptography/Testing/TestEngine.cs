using Cryptography.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Test
{
    class TestEngine
    {
        Tester[] testers;

        public static long TimedTest<T>(T tester) where T : Tester
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            tester.Test();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public static long TimedCryptoTest<C>() where C: Crypter, new()
        {
            return TimedTest(new CryptoTester<C>());
        }
    }
}
