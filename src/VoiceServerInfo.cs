namespace Vysn.Voice {
	/// <summary>
	/// Information required to connect to ws server.
	/// </summary>
	public struct VoiceServerInfo {
		/// <summary>
		/// Voice channel session id.
		/// </summary>
		public string SessionId { get; private set; }
		
		/// <summary>
		/// Endpoint of voice channel's voice server.
		/// </summary>
		public string Endpoint { get; private set; }
		
		/// <summary>
		/// Voice channel's connection token.
		/// </summary>
		public string Token { get; private set; }
	}
}