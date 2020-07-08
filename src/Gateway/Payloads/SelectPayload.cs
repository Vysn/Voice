using System.Text.Json.Serialization;

namespace Vysn.Voice.Gateway.Payloads {
    internal struct SelectPayload {
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}