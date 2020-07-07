using System;
using Microsoft.Extensions.Logging;
using Vysn.Voice.Gateway;

namespace Vysn.Voice {
    /// <summary>
    /// 
    /// </summary>
    public sealed class V4Gateway : BaseVoiceGateway {
        /// <inheritdoc />
        public override int Version
            => 4;

        /// <inheritdoc />
        public V4Gateway(ILogger logger, Uri websocketAddress) : base(logger, websocketAddress) { }
    }
}