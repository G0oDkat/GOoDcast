namespace GOoDcast.Messages
{
    using System;
    using System.Threading;
    using Newtonsoft.Json;

    /// <summary>
    ///     Message with request identifier
    /// </summary>
    public class MessageWithId : Message, IMessageWithId
    {
        private static int _id = new Random().Next();

        private int? requestId;

        /// <summary>
        ///     Gets a value indicating whether the message has a request identifier
        /// </summary>
        [JsonIgnore]
        public bool HasRequestId => requestId != null;

        /// <summary>
        ///     Gets or sets the request identifier
        /// </summary>        
        public int RequestId
        {
            get => requestId ?? (requestId = Interlocked.Increment(ref _id)).Value;
            set => requestId = value;
        }
    }
}