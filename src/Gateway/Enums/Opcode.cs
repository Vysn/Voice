namespace Vysn.Voice.Gateway.Enums {
    /// <summary>
    /// 
    /// </summary>
    public enum Opcode {
        /// <summary>
        /// 
        /// </summary>
        Identify = 0,
        /// <summary>
        /// 
        /// </summary>
        SelectProtocol = 1,
        /// <summary>
        /// 
        /// </summary>
        Ready = 2,
        /// <summary>
        /// 
        /// </summary>
        Heartbeat = 3,
        /// <summary>
        /// 
        /// </summary>
        SessionDescription = 4,
        /// <summary>
        /// 
        /// </summary>
        Speaking = 5,
        /// <summary>
        /// 
        /// </summary>
        HeartbeatAcknowledge = 6,
        /// <summary>
        /// 
        /// </summary>
        Resume = 7,
        /// <summary>
        /// 
        /// </summary>
        Hello = 8,
        /// <summary>
        /// 
        /// </summary>
        Resumed = 9,
        /// <summary>
        /// 
        /// </summary>
        ClientDisconnect = 13
    }
}