using ProtoBuf;
using Sodium;
using Cryptography.Array;

namespace Cryptography
{
    [ProtoContract]
    public class Chunk
    {
        #region Fields
        private readonly byte[] _checksumPrefix = { 0x01 };
        private int _length;
        private bool _isLast;
        private byte[] _checksum;
        private byte[] _data;
        #endregion  

        #region Properties
        [ProtoMember(1)]
        public int Length
        {
            get
            {
                return _length;
            }
        }

        public byte[] Checksum
        {
            get
            {
                return _checksum;
            }
        }

        [ProtoMember(3)]
        public byte[] Data
        {
            get
            {
                return _data;
            }
        }
        #endregion

        #region Methods
        public void setChecksum(byte[] ephemeralKey, int checksumLength)
        {
            string message = ArrayEx.ConcatArrays();
            byte[] key;
            _checksum = GenericHash.Hash(message, key, checksumLength);
        }
        #endregion
    }
}
