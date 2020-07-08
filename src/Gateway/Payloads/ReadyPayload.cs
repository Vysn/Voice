using System.Text.Json.Serialization;

namespace Vysn.Voice.Gateway.Payloads {
    internal struct ReadyPayload {
        [JsonPropertyName("ssrc")]
        public int SSRC { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("port")]
        public int Port { get; set; }

        [JsonPropertyName("modes")]
        public string[] Modes { get; set; }

        [JsonPropertyName("heartbeat_interval")]
        public int Interval { get; set; }
    }
}