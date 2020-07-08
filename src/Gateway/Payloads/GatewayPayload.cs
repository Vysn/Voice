using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vysn.Voice.Gateway.Enums;

namespace Vysn.Voice.Gateway.Payloads {
    internal readonly struct GatewayPayload {
        [JsonPropertyName("op")]
        public OpCode OpCode { get; }

        [JsonPropertyName("d")]
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
                    Modes = GetModes(rootElement),
                    Interval = rootElement.GetProperty("interval").GetInt32()
                },
                OpCode.Hello => new HelloPayload {
                    Interval = rootElement.GetProperty("heartbeat_interval").GetInt32()
                },
                OpCode.SessionDescription => new SessionDescriptionPayload {
                    Mode = rootElement.GetProperty("mode").GetString(),
                    SecretKey = GetSecretKey(rootElement)
                }
            };
        }

        private static string[] GetModes(JsonElement jsonElement) {
            var element = jsonElement.GetProperty("modes");
            var elementArray = new string[element.GetArrayLength()];
            var i = 0;
            foreach (var item in element.EnumerateArray()) {
                elementArray[i] = element.GetString();
                i++;
            }

            return elementArray;
        }

        private static byte[] GetSecretKey(JsonElement jsonElement) {
            var element = jsonElement.GetProperty("secret_key");
            var elementArray = new byte[element.GetArrayLength()];
            var i = 0;
            foreach (var item in element.EnumerateArray()) {
                elementArray[i] = element.GetByte();
                i++;
            }

            return elementArray;
        }
    }
}