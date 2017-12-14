using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cryptography.Write
{
    public interface Writer
    {
        void Write(Stream source, Stream destination);
    }
}
