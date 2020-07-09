using Vysn.Voice.Codec.Enums;

namespace Vysn.Voice.Codec.Codecs {
    /// <summary>
    /// 
    /// </summary>
    public sealed class OpusCodec : AbstractCodec {
        /// <inheritdoc />
        public override string Name
            => "Opus";

        /// <summary>
        /// 
        /// </summary>
        public static readonly byte[] SilenceFrames
            = {0xF8, 0xFF, 0xFE};

        /// <summary>
        /// 
        /// </summary>
        public const int FRAME_DURATION = 20;

        /// <summary>
        /// 
        /// </summary>
        public const byte PAYLOAD_TYPE = 120;

        /// <inheritdoc />
        public OpusCodec()
            : base(PAYLOAD_TYPE, 1000, CodecType.Audio) { }
    }
}