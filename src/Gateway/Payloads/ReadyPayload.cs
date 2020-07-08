namespace Vysn.Voice.Gateway.Payloads {
    internal struct ReadyPayload {
        public int SSRC { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string[] Modes { get; set; }
        public int Interval { get; set; }
    }
}