using System;
using System.Collections.Generic;
using Vysn.Voice.Encryption.Interfaces;
using Vysn.Voice.Encryption.Modes;

namespace Vysn.Voice.Encryption {
    /// <summary>
    /// 
    /// </summary>
    public readonly struct EncryptionMode {
        private static readonly IDictionary<string, IEncryptionMode> EncryptionModes
            = new Dictionary<string, IEncryptionMode>() {
                {"xsalsa20_poly1305_lite", new XSalsaPoly1305LiteEncryptionMode()},
                {"xsalsa20_poly1305_suffix", new XSalsaPoly1305SuffixEncryptionMode()},
                {"xsalsa20_poly1305", new XSalsaPoly1305EncryptionMode()},
                {"plain", new PlainEncryptionMode()}
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptionModes"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string Select(IEnumerable<string> encryptionModes) {
            foreach (var encryptionMode in encryptionModes) {
                if (!EncryptionModes.TryGetValue(encryptionMode, out var implementation)) {
                    continue;
                }

                if (implementation == null) {
                    continue;
                }

                if (!implementation.IsSupported) {
                    continue;
                }

                return encryptionMode;
            }

            throw new Exception($"A suitable encryption mode couldn't be found.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static IEncryptionMode Get(string mode) {
            return EncryptionModes.TryGetValue(mode, out var encryptionMode)
                ? encryptionMode
                : default;
        }
    }
}