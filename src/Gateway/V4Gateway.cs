using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vysn.Commons.WebSocket.EventArgs;
using Vysn.Voice.Gateway.Enums;
using Vysn.Voice.Gateway.Payloads;

namespace Vysn.Voice.Gateway {
    /// <summary>
    /// 
    /// </summary>
    public sealed class V4Gateway : BaseVoiceGateway {
        /// <inheritdoc />
        public V4Gateway(VoiceServerInfo voiceServerInfo, ILogger logger)
            : base(logger, voiceServerInfo, 4) { }

        private protected override async Task OnMessageAsync(MessageEventArgs messageEventArgs) {
            if (messageEventArgs.Data.Length <= 0) {
                Logger.LogWarning("Gateway sent empty data.");
                return;
            }

            var gatewayPayload = new GatewayPayload(messageEventArgs.Data);
            switch (gatewayPayload.OpCode) {
                case OpCode.Hello:
                    break;

                case OpCode.Ready when gatewayPayload.OpData is ReadyPayload readyPayload:
                    
                    break;

                case OpCode.SessionDescription:
                    break;
            }
        }
    }
}