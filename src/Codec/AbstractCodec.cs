using System.Collections.Generic;
using System.Linq;
using Vysn.Voice.Codec.Codecs;
using Vysn.Voice.Codec.Enums;

namespace Vysn.Voice.Codec {
    /// <summary>
    /// 
    /// </summary>
    public abstract class AbstractCodec {
        /// <summary>
        /// 
        /// </summary>
        public abstract string Name { get; }

        private readonly byte _payloadType;
        private readonly byte _rtxPayloadType;
        private readonly int _priority;
        private readonly CodecType _codecType;
        private static readonly IDictionary<string, AbstractCodec> AudioCodecs;
        private static readonly IDictionary<string, AbstractCodec> VideoCodecs;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payloadType"></param>
        /// <param name="priority"></param>
        /// <param name="codecType"></param>
        protected AbstractCodec(byte payloadType, int priority, CodecType codecType)
            : this(payloadType, 0, priority, codecType) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payloadType"></param>
        /// <param name="rtxPayloadType"></param>
        /// <param name="priority"></param>
        /// <param name="codecType"></param>
        protected AbstractCodec(byte payloadType, byte rtxPayloadType, int priority, CodecType codecType) {
            _payloadType = payloadType;
            _rtxPayloadType = rtxPayloadType;
            _priority = priority;
            _codecType = codecType;
        }

        static AbstractCodec() {
            AudioCodecs = new Dictionary<string, AbstractCodec>() {
                {"Opus", new OpusCodec()}
            };

            VideoCodecs = new Dictionary<string, AbstractCodec>() {
                {"VP8", new VP8Codec()},
                {"VP9", new VP9Codec()},
                {"H264", new H264Codec()}
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AbstractCodec GetAudioCodec(string name) {
            return AudioCodecs[name];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AbstractCodec GetVideoCodec(string name) {
            return VideoCodecs[name];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payloadType"></param>
        /// <returns></returns>
        public static AbstractCodec GetByPayload(byte payloadType) {
            return AudioCodecs
                .Concat(VideoCodecs)
                .Select(x => x.Value)
                .FirstOrDefault(x => x._payloadType == payloadType);
        }
    }
}