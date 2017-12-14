using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class FileCrypter<C> where C : Crypter, new()
    {
        C _crypter;

        #region Constructors
        public FileCrypter()
        {
            _crypter = new C();
        }
        public FileCrypter(C encrypter)
        {
            _crypter = encrypter == null ? new C() : encrypter;
        }
        #endregion

        public void Encrypt(string sourceFilePath = @"C:\Users\david.isayan\Desktop\rc.jpg", string destinationFilePath = @"C:\Users\david.isayan\Desktop\encrypted.dat")
        {
            var source = sourceFileStream(sourceFilePath);
            var destination = destinationFileStream(destinationFilePath);
            _crypter.Encrypt(source, destination);
        }

        public void Decrypt(string sourceFilePath = @"C:\Users\david.isayan\Desktop\encrypted.dat", string destinationFilePath = @"C:\Users\david.isayan\Desktop\decrypted.jpg")
        {
            var source = sourceFileStream(sourceFilePath);
            var destination = destinationFileStream(destinationFilePath);
            _crypter.Decrypt(source, destination);
        }

        #region Generators
        public static FileStream sourceFileStream(string path)
        {
            return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public static FileStream destinationFileStream(string path)
        {
            return new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        }
        #endregion
    }
}
