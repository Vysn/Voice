using System;
using System.Collections.Generic;

namespace Vysn.Voice.Encryption {
    /// <summary>
    /// 
    /// </summary>
    public readonly struct EncryptionMode {
        private static readonly IDictionary<string, Type> EncryptionModes
            = new Dictionary<string, Type>() {
                {"xsalsa20_poly1305_lite", default},
                {"xsalsa20_poly1305_suffix", default},
                {"xsalsa20_poly1305", default},
                {"plain", default}
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

                return encryptionMode;
            }

            throw new Exception($"A suitable encryption mode couldn't be found.");
        }
    }
}