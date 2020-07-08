using System.Text.Json.Serialization;
using Vysn.Voice.Gateway.Enums;

namespace Vysn.Voice.Gateway.Payloads {
    internal struct SpeakingPayload {
        [JsonPropertyName("speaking")]
        public SpeakingFlags Speaking { get; set; }
        
        [JsonPropertyName("delay")]
        public long Delay { get; set; }
        
        [JsonPropertyName("ssrc")]
        public int SSRC { get; set; }
    }
}