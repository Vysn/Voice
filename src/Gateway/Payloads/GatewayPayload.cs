using System;
using System.Text.Json;
using Vysn.Voice.Gateway.Enums;

namespace Vysn.Voice.Gateway.Payloads {
    internal readonly struct GatewayPayload {
        public OpCode OpCode { get; }
        public object OpData { get; }

        public GatewayPayload(OpCode opCode, object opData) {
            OpCode = opCode;
            OpData = opData;
        }

        public GatewayPayload(byte[] data) {
            using var document = JsonDocument.Parse(data);
            var rootElement = document.RootElement;

            if (!rootElement.TryGetProperty("op", out var opElement)) {
                throw new Exception("Missing op property from payload.");
            }

            OpCode = (OpCode) opElement.GetInt32();
            if (!rootElement.TryGetProperty("d", out var dataElement)) {
                throw new Exception("Missing data property from payload.");
            }

            OpData = OpCode switch {
                OpCode.Ready => new ReadyPayload {
                    SSRC = rootElement.GetProperty("ssrc").GetInt32(),
                    Ip = rootElement.GetProperty("ip").GetString(),
                    Port = rootElement.GetProperty("port").GetInt32(),
                    Modes = default,
                    Interval = rootElement.GetProperty("interval").GetInt32()
                }
            };
        }
    }
}