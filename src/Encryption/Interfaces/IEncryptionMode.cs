using System;

namespace Vysn.Voice.Encryption.Interfaces {
    /// <summary>
    /// 
    /// </summary>
    public interface IEncryptionMode {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opus"></param>
        /// <param name="target"></param>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        bool TryBox(Span<byte> opus, Span<byte> target, Span<byte> secretKey);
    }
}