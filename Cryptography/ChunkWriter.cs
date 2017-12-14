using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Write;

namespace Cryptography
{
    class ChunkWriter : Writer
    {
        const int CHUNK_SIZE = 64;

        public void Write(Stream source, Stream destination)
        {
            int read;
            byte[] buffer = new byte[CHUNK_SIZE];
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                destination.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
