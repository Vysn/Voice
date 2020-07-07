namespace Vysn.Voice.Gateway.Enums {
    internal enum CloseEventCode {
        /// <summary>
        ///     Invalid opcode was sent.
        /// </summary>
        UnknownOpCode = 4001,

        /// <summary>
        ///     Sent a payload before identifying with the Gateway.
        /// </summary>
        NotAuthenticated = 4003,

        /// <summary>
        ///     The token you sent in your identify payload is incorrect.
        /// </summary>
        AuthenticationFailed = 4004,

        /// <summary>
        ///     Sent more than one identify payload. Stahp.
        /// </summary>
        AlreadyAuthenticated = 4005,

        /// <summary>
        ///     Your session is no longer valid.
        /// </summary>
        InvalidSession = 4006,

        /// <summary>
        ///     Your session has timed out.
        /// </summary>
        SessionTimeout = 4009,

        /// <summary>
        ///     We can't find the server you're trying to connect to.
        /// </summary>
        ServerNotFound = 4011,

        /// <summary>
        ///     Sent protocol was not recognized.
        /// </summary>
        UnknownProtocol = 4012,

        /// <summary>
        ///     Either the channel was deleted or you were kicked. Should not reconnect.
        /// </summary>
        Disconnected = 4014,

        /// <summary>
        ///     Voice server crashed.
        /// </summary>
        ServerCrashed = 4015,

        /// <summary>
        ///     We didn't recognize your encryption.
        /// </summary>
        UnknownEncryptionMode = 4016
    }
}