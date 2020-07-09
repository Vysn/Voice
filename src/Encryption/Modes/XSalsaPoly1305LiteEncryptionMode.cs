using System;
using Vysn.Voice.Encryption.Interfaces;

namespace Vysn.Voice.Encryption.Modes {
    /// <inheritdoc />
    public class XSalsaPoly1305LiteEncryptionMode : IEncryptionMode {
        /// <inheritdoc />
        public bool IsSupported
            => false;

        /// <inheritdoc />
        public bool TryBox(Span<byte> opus, Span<byte> target, Span<byte> secretKey) {
            throw new NotImplementedException();
        }
    }
}