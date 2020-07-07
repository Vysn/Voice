using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vysn.Commons.WebSocket;
using Vysn.Commons.WebSocket.EventArgs;

namespace Vysn.Voice.Gateway {
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseVoiceGateway {
        private readonly ILogger _logger;
        private readonly WebSocketClient _socketClient;
        /// <summary>
        /// 
        /// </summary>
        public abstract int Version { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="websocketAddress"></param>
        protected BaseVoiceGateway(ILogger logger, Uri websocketAddress) {
            _logger = logger;
            _socketClient = new WebSocketClient(websocketAddress);

            _socketClient.OnCloseAsync += OnCloseAsync;
            _socketClient.OnErrorAsync += OnErrorAsync;
            _socketClient.OnOpenAsync += OnOpenAsync;
            _socketClient.OnMessageAsync += OnMessageAsync;
        }

        private async Task OnOpenAsync(OpenEventArgs openEventArgs) { }
        private async Task OnCloseAsync(CloseEventArgs closeEventArgs) { }
        private async Task OnErrorAsync(ErrorEventArgs errorEventArgs) { }
        private async Task OnMessageAsync(MessageEventArgs messageEventArgs) { }
    }
}