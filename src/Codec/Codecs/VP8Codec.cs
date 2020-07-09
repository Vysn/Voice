using Vysn.Voice.Codec.Enums;

namespace Vysn.Voice.Codec.Codecs {
    /// <summary>
    /// 
    /// </summary>
    public sealed class VP8Codec : AbstractCodec {
        /// <summary>
        /// 
        /// </summary>
        public override string Name
            => "VP8";

        /// <summary>
        /// 
        /// </summary>
        public const byte PAYLOAD_TYPE = 101;

        /// <summary>
        /// 
        /// </summary>
        public const byte RTX_PAYLOAD_TYPE = 104;

        /// <summary>
        /// 
        /// </summary>
        public VP8Codec()
            : base(PAYLOAD_TYPE, RTX_PAYLOAD_TYPE, 2000, CodecType.Video) { }
    }
}