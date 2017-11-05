﻿using System.ServiceModel.Channels;

namespace WcfSoapLogger.EncodingExtension
{
    public class LoggingEncoderFactory : MessageEncoderFactory
    {
        internal SoapLoggerSettings Settings { get; }
        internal string MediaType { get; }
        internal MessageEncoderFactory InnerMessageFactory { get; }

        public override MessageVersion MessageVersion { get; }
        public override MessageEncoder Encoder { get; }

        internal LoggingEncoderFactory(SoapLoggerSettings settings, string mediaType, MessageVersion version, MessageEncoderFactory messageFactory)
        {
            Settings = settings;
            MediaType = mediaType;
            MessageVersion = version;
            InnerMessageFactory = messageFactory;
            Encoder = new LoggingEncoder(this);
        }
    }
}
