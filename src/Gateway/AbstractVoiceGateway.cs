using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vysn.Commons.WebSocket;
using Vysn.Commons.WebSocket.EventArgs;
using Vysn.Voice.Gateway.Enums;
using Vysn.Voice.Gateway.Payloads;

namespace Vysn.Voice.Gateway {
    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractVoiceGateway : IAsyncDisposable {
        private protected ILogger Logger { get; }
        private protected WebSocketClient SocketClient { get; }
        private protected VoiceServerInfo ServerInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Version { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpen
            => Volatile.Read(ref _isOpen);

        private protected bool _isOpen;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="voiceServerInfo"></param>
        /// <param name="version"></param>
        protected AbstractVoiceGateway(ILogger logger, VoiceServerInfo voiceServerInfo, int version) {
            Logger = logger;
            ServerInfo = voiceServerInfo;
            Version = version;
            SocketClient = new WebSocketClient(new Uri($"wss://{voiceServerInfo.Endpoint[..^3]}:443?v={version}"));

            SocketClient.OnCloseAsync += OnCloseAsync;
            SocketClient.OnErrorAsync += OnErrorAsync;
            SocketClient.OnOpenAsync += OnOpenAsync;
            SocketClient.OnMessageAsync += OnMessageAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task StartAsync() {
            if (Volatile.Read(ref _isOpen)) {
                throw new InvalidOperationException("A gateway connection is already established.");
            }

            Logger.LogDebug($"Connecting to {SocketClient.Host}");
            await SocketClient.ConnectAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task StopAsync() {
            if (!Volatile.Read(ref _isOpen)) {
                throw new InvalidOperationException("No open gateway connections.");
            }

            await SocketClient.DisconnectAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Task UpdateSpeakingAsync(SpeakingFlags speakingFlags);

        /// <inheritdoc />
        public virtual ValueTask DisposeAsync() {
            Volatile.Write(ref _isOpen, false);
            return SocketClient.DisposeAsync();
        }

        private async Task OnOpenAsync(OpenEventArgs openEventArgs) {
            Logger.LogInformation("Connection to voice gateway established.");
            Volatile.Write(ref _isOpen, true);

            var identifyPayload = new GatewayPayload(OpCode.Identify,
                new IdentifyPayload {
                    GuildId = ServerInfo.GuildId,
                    SessionId = ServerInfo.SessionId,
                    Token = ServerInfo.Token,
                    UserId = ServerInfo.UserId
                });

            await SocketClient.SendAsync(identifyPayload);
        }

        private Task OnCloseAsync(CloseEventArgs closeEventArgs) {
            Logger.LogWarning("Gateway connection has been closed.");
            return Task.CompletedTask;
        }

        private Task OnErrorAsync(ErrorEventArgs errorEventArgs) {
            Logger.LogError(errorEventArgs.Message, errorEventArgs.Exception);
            return Task.CompletedTask;
        }

        private protected abstract Task OnMessageAsync(MessageEventArgs messageEventArgs);
    }
}