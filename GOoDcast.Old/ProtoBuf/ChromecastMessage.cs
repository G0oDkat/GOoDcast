namespace GOoDcast.ProtoBuf
{
    using System;
    using System.Text;
    using global::ProtoBuf;
    using Newtonsoft.Json;

    [ProtoContract]
    public class ChromecastMessage
    {
        public ChromecastMessage()
        {
        }

        public ChromecastMessage(string @namespace, string payload, string destinationId = "receiver-0")
        {
            ProtocolVersion = ProtoBuf.ProtocolVersion.Castv210;
            SourceId = "sender-0";
            DestinationId = destinationId ?? throw new ArgumentNullException(nameof(destinationId));
            Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
            PayloadType = ProtoBuf.PayloadType.String;
            PayloadUtf8 = payload ?? throw new ArgumentNullException(nameof(payload));
        }

        [ProtoMember(1)]
        public ProtocolVersion? ProtocolVersion { get; set; }

        /// <summary>
        ///     source and destination ids identify the origin and destination of the
        ///     message.  They are used to route messages between endpoints that share a
        ///     device-to-device channel.
        ///     For messages between applications:
        ///     - The sender application id is a unique identifier generated on behalf of
        ///     the sender application.
        ///     - The receiver id is always the the session id for the application.
        ///     For messages to or from the sender or receiver platform, the special ids
        ///     'sender-0' and 'receiver-0' can be used.
        ///     For messages intended for all endpoints using a given channel, the
        ///     wildcard destination_id '*' can be used.
        /// </summary>
        [ProtoMember(2)]
        public string SourceId { get; set; }

        [ProtoMember(3)]
        public string DestinationId { get; set; }

        /// <summary>
        ///     This is the core multiplexing key.  All messages are sent on a namespace
        ///     and endpoints sharing a channel listen on one or more namespaces.  The
        ///     namespace defines the protocol and semantics of the message.
        /// </summary>
        [ProtoMember(4)]
        public string Namespace { get; set; }

        [ProtoMember(5)]
        public PayloadType? PayloadType { get; set; }

        /// <summary>
        ///     Depending on payload_type, exactly one of the following optional fields
        ///     will always be set.
        /// </summary>
        [ProtoMember(6)]
        public string PayloadUtf8 { get; set; }

        [ProtoMember(7)]
        public byte[] PayloadBinary { get; set; }

#if DEBUG
        public override string ToString()
        {
            return
                $"[Namespace:{Namespace}, SourceId: {SourceId}, DestinationId: {DestinationId}, Payload: {PayloadUtf8}  ]";
        }
#endif

        public string GetPayloadByType()
        {
            return PayloadType == ProtoBuf.PayloadType.Binary ? Encoding.UTF8.GetString(PayloadBinary) : PayloadUtf8;
        }
    }

    /// <summary>
    ///     Encoding and payload info follows.
    ///     What type of data do we have in this message.
    /// </summary>
    public enum PayloadType
    {
        String = 0,
        Binary = 1
    }

    /// <summary>
    ///     Always pass a version of the protocol for future compatibility
    ///     requirements.
    /// </summary>
    public enum ProtocolVersion
    {
        Castv210 = 0
    }
}