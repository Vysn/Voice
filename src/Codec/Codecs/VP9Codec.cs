using Vysn.Voice.Codec.Enums;

namespace Vysn.Voice.Codec.Codecs {
    /// <summary>
    /// 
    /// </summary>
    public sealed class VP9Codec : AbstractCodec {
        /// <summary>
        /// 
        /// </summary>
        public override string Name
            => "VP9";

        /// <summary>
        /// 
        /// </summary>
        public const byte PAYLOAD_TYPE = 105;

        /// <summary>
        /// 
        /// </summary>
        public const byte RTX_PAYLOAD_TYPE = 106;

        /// <summary>
        /// 
        /// </summary>
        public VP9Codec()
            : base(PAYLOAD_TYPE, RTX_PAYLOAD_TYPE, 3000, CodecType.Video) { }
    }
}