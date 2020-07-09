using Vysn.Voice.Codec.Enums;

namespace Vysn.Voice.Codec.Codecs {
    /// <summary>
    /// 
    /// </summary>
    public sealed class H264Codec : AbstractCodec {
        /// <inheritdoc />
        public override string Name
            => "H264";

        /// <summary>
        /// 
        /// </summary>
        public const byte PAYLOAD_TYPE = 101;

        /// <summary>
        /// 
        /// </summary>
        public const byte RTX_PAYLOAD_TYPE = 102;

        /// <inheritdoc />
        public H264Codec() :
            base(PAYLOAD_TYPE, RTX_PAYLOAD_TYPE, 1000, CodecType.Video) { }
    }
}