using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
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
