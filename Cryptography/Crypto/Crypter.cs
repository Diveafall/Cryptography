using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cryptography
{
    public interface Encrypter
    {
        void Encrypt(Stream source, Stream destination);
    }

    public interface Decrypter
    {
        void Decrypt(Stream source, Stream destination);
    }

    public interface Crypter: Encrypter, Decrypter
    {
        string Name { get; }
        int KeySize { get; }
    }
}
