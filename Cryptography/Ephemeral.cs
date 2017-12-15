using Cryptography.Array;

namespace Cryptography
{
    public static class Ephemeral
    {
        private const int KEY_SIZE = 64;

        public static byte[] GetEncryptionKey(byte[] ephemeralKey)
        {
            if (ephemeralKey == null || ephemeralKey.Length != KEY_SIZE)
                throw new System.ArgumentOutOfRangeException("Ephemeral Key", ephemeralKey == null ? 0 : ephemeralKey.Length, string.Format("Ephemeral Key must be {0} bytes in length.", KEY_SIZE));
            return ArrayEx.SubArray(ephemeralKey, 0, 32);
        }

        public static byte[] GetHashKey(byte[] ephemeralKey)
        {
            if (ephemeralKey == null || ephemeralKey.Length != KEY_SIZE)
                throw new System.ArgumentOutOfRangeException("Ephemeral Key", ephemeralKey == null ? 0 : ephemeralKey.Length, string.Format("Ephemeral Key must be {0} bytes in length.", KEY_SIZE));
            return ArrayEx.SubArray(ephemeralKey, 32);
        }
    }
}
