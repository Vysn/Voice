﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Vysn.Commons.WebSocket.EventArgs;
using Vysn.Voice.Gateway.Enums;
using Vysn.Voice.Gateway.Payloads;

namespace Vysn.Voice.Gateway {
    /// <summary>
    /// 
    /// </summary>
    public sealed class V4VoiceGateway : AbstractVoiceGateway {
        private int _ssrc;
        private Task _heartBeatTask;

        /// <inheritdoc />
        public V4VoiceGateway(VoiceServerInfo voiceServerInfo, ILogger logger)
            : base(logger, voiceServerInfo, 4) { }

        /// <inheritdoc />
        public override async Task UpdateSpeakingAsync(SpeakingFlags speakingFlags) {
            if (!Volatile.Read(ref _isOpen)) {
                throw new InvalidOperationException();
            }

            var speakingPayload = new GatewayPayload(OpCode.Speaking,
                new SpeakingPayload {
                    Speaking = speakingFlags,
                    Delay = 0,
                    SSRC = _ssrc
                });

            await SocketClient.SendAsync(speakingPayload);
        }

        /// <inheritdoc />
        public override ValueTask DisposeAsync() {
            _heartBeatTask.Dispose();
            return base.DisposeAsync();
        }

        private protected override async Task OnMessageAsync(MessageEventArgs messageEventArgs) {
            if (messageEventArgs.Data.Length <= 0) {
                Logger.LogWarning("Gateway sent empty payload data.");
                return;
            }

            var gatewayPayload = new GatewayPayload(messageEventArgs.Data);
            Logger.LogDebug($"Received {Enum.GetName(typeof(OpCode), gatewayPayload.OpCode)}.");

            switch (gatewayPayload.OpCode) {
                case OpCode.Hello when gatewayPayload.OpData is HelloPayload helloPayload:
                    _heartBeatTask = SetupHeartbeatAsync(helloPayload.Interval);
                    break;

                case OpCode.Ready when gatewayPayload.OpData is ReadyPayload readyPayload:

                    break;

                case OpCode.SessionDescription
                    when gatewayPayload.OpData is SessionDescriptionPayload descriptionPayload:
                    break;
                
                case OpCode.HeartbeatAcknowledge when gatewayPayload.OpData is int nonce:
                    Logger.LogDebug($"Heartbeat ACK {nonce}");
                    break;
            }
        }

        private async Task SetupHeartbeatAsync(int interval) {
            while (Volatile.Read(ref _isOpen)) {
                var heartbeatPayload = new GatewayPayload(OpCode.Heartbeat, DateTime.Now.Ticks);
                await SocketClient.SendAsync(heartbeatPayload);
                await Task.Delay(interval);
            }
        }
    }
}