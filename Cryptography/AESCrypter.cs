using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Cryptography.AES
{
    struct AESConfig
    {
        #region Fields
        private int _keySize;
        private PaddingMode _padding;
        private CipherMode _mode;
        #endregion

        #region Constructors
        private AESConfig(int keySize, PaddingMode padding, CipherMode cypherMode) : this()
        {
            this._keySize = keySize;
            this._padding = padding;
            this._mode = cypherMode;
        }
        #endregion

        #region Properties
        public int KeySize
        {
            get
            {
                return _keySize;
            }
        }

        public PaddingMode Padding
        {
            get
            {
                return _padding;
            }
        }

        public CipherMode Mode
        {
            get
            {
                return _mode;
            }
        }
        #endregion

        #region Configuration Sets
        public static readonly AESConfig Low = new AESConfig(128, PaddingMode.PKCS7, CipherMode.CBC);
        public static readonly AESConfig Medium = new AESConfig(192, PaddingMode.PKCS7, CipherMode.CBC);
        public static readonly AESConfig High = new AESConfig(256, PaddingMode.PKCS7, CipherMode.CBC);
        #endregion
    }

    class AESCrypter: Crypter
    {
        #region Fields
        private Aes _aes;
        #endregion

        #region Properties
        public int KeySize
        {
            get
            {
                return _aes.KeySize;
            }
        }
        public string Name
        {
            get
            {
                return "AES";
            }
        }
        #endregion

        #region Constructors
        public AESCrypter(AESConfig config)
        {
            _aes = Aes.Create();

            _aes.KeySize = config.KeySize;
            _aes.Mode = config.Mode;
            _aes.Padding = config.Padding;

            _aes.GenerateKey();
            _aes.GenerateIV();
        }
        #endregion

        #region Crypter
        public void Encrypt(Stream source, Stream destination)
        {
            ICryptoTransform encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);
            using (CryptoStream cryptoStream = new CryptoStream(destination, encryptor, CryptoStreamMode.Write))
            {
                source.CopyTo(cryptoStream);
                // TODO: Handle Errors
            }
        }

        public void Decrypt(Stream source, Stream destination)
        {
            ICryptoTransform decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);
            using (CryptoStream cryptoStream = new CryptoStream(destination, decryptor, CryptoStreamMode.Write))
            {
                source.CopyTo(cryptoStream);
                // TODO: Handle Errors
            }
        }
        #endregion
    }
}
