using System;
using System.Runtime.InteropServices;

namespace Vysn.Voice.Interop {
    /// <summary>
    /// 
    /// </summary>
    public readonly struct SodiumInterop {
        private const string NAME = "libsodium";

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void randombytes_buf(byte[] buffer, int size);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern UIntPtr crypto_secretbox_keybytes();

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern UIntPtr crypto_secretbox_noncebytes();

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern UIntPtr crypto_secretbox_macbytes();

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int crypto_secretbox_easy(byte[] buffer, byte[] message, long messageLength,
                                                         byte[] nonce, byte[] key);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int crypto_secretbox_open_easy(byte[] buffer, byte[] cipherText, long cipherTextLength,
                                                              byte[] nonce, byte[] key);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int crypto_secretbox_detached(byte[] cipher, byte[] mac, byte[] message,
                                                             long messageLength, byte[] nonce, byte[] key);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int crypto_secretbox_open_detached(byte[] buffer, byte[] cipherText, byte[] mac,
                                                                  long cipherTextLength, byte[] nonce, byte[] key);
    }
}