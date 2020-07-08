using System.Text.Json.Serialization;

namespace Vysn.Voice.Gateway.Payloads {
    internal struct SessionDescriptionPayload {
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("secret_key")]
        public byte[] SecretKey { get; set; }
    }
}