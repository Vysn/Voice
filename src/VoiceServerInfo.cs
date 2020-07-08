using Vysn.Commons;

namespace Vysn.Voice {
    /// <summary>
    /// Information required to connect to ws server.
    /// </summary>
    public readonly struct VoiceServerInfo {
        /// <summary>
        /// Voice channel session id.
        /// </summary>
        public string SessionId { get; }

        /// <summary>
        /// Endpoint of voice channel's voice server.
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        /// Voice channel's connection token.
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// 
        /// </summary>
        public Snowflake UserId { get; }

        /// <summary>
        /// 
        /// </summary>
        public Snowflake GuildId { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="endpoint"></param>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <param name="guildId"></param>
        public VoiceServerInfo(string sessionId, string endpoint, string token,
                               ulong userId, ulong guildId) {
            Guard.NotNull(nameof(sessionId), sessionId);
            Guard.NotNull(nameof(endpoint), endpoint);
            Guard.NotNull(nameof(token), token);

            SessionId = sessionId;
            Endpoint = endpoint;
            Token = token;
            UserId = new Snowflake(userId);
            GuildId = new Snowflake(guildId);
        }
    }
}