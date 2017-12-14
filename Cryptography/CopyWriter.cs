using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Write
{
    public class CopyWriter : Writer
    {
        public void Write(Stream source, Stream destination)
        {
            source.CopyTo(destination);
        }
    }
}
