using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Write;
using System.Threading;

namespace Cryptography
{
    class ChunkWriter : Writer
    {
        const int CHUNK_SIZE = 64;



        public async void Write(Stream source, Stream destination)
        {
            int bytesRead;
            do
            {
                byte[] unencryptedChunk = new byte[CHUNK_SIZE];
                bytesRead = await source.ReadAsync(unencryptedChunk, 0, CHUNK_SIZE, new CancellationToken(false)).ConfigureAwait(false);
                // check if there is still some work
                if (bytesRead != 0)
                {
                    // prepare the chunk
                    FileChunk chunk = new FileChunk();
                    byte[] readBytes = new byte[bytesRead];
                    // cut unreaded bytes
                    Array.Copy(unencryptedChunk, readBytes, bytesRead);
                    // check if the file is smaller or equal to the CHUNK_SIZE
                    if ()
                }
            } while (bytesRead != 0);
        }
    }
}
