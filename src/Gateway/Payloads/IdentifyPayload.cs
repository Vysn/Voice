using System.Text.Json.Serialization;
using Vysn.Commons;

namespace Vysn.Voice.Gateway.Payloads {
    internal struct IdentifyPayload {
        [JsonPropertyName("guild_Id")]
        public Snowflake GuildId { get; set; }

        [JsonPropertyName("user_id")]
        public Snowflake UserId { get; set; }

        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}