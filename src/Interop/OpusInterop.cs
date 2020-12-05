using System;
using System.Runtime.InteropServices;
using Vysn.Voice.Interop.Enums;

namespace Vysn.Voice.Interop {
    /// <summary>
    /// 
    /// </summary>
    public readonly struct OpusInterop {
        private const string NAME = "libopus";

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr opus_encoder_create(int sampleRate, int channels, int application,
                                                          out OpusError error);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void opus_encoder_destroy(IntPtr encoder);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int opus_encode(IntPtr encoder, byte[] pcm, int frameSize, IntPtr data,
                                               int maxDataBytes);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern OpusError opus_encoder_ctl(IntPtr encoder, OpusControl request, int value);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr opus_decoder_create(int sampleRate, int channels, out OpusError error);

        [DllImport(NAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void opus_decoder_destroy(IntPtr decoder);
    }
}