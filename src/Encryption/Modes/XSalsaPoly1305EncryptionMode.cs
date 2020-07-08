using System;
using Vysn.Voice.Encryption.Interfaces;

namespace Vysn.Voice.Encryption.Modes {
    /// <inheritdoc />
    public class XSalsaPoly1305EncryptionMode : IEncryptionMode {
        /// <inheritdoc />
        public bool TryBox(Span<byte> opus, Span<byte> target, Span<byte> secretKey) {
            throw new NotImplementedException();
        }
    }
}