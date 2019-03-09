namespace GOoDcast.Messages
{
    using System;
    using Extensions;

    /// <summary>
    ///     Message base class
    /// </summary>
    public abstract class Message : IMessage
    {
        /// <summary>
        ///     Initialization
        /// </summary>
        protected Message()
        {
            Type = GetMessageType(GetType());
        }

        /// <summary>
        ///     Gets the message type
        /// </summary>
        public string Type { get; protected set; }

        /// <summary>
        ///     Gets the message type
        /// </summary>
        /// <returns>message class type</returns>
        public static string GetMessageType(Type type)
        {
            string typeName = type.Name;
            return typeName.Substring(0, typeName.LastIndexOf(nameof(Message))).ToUnderscoreUpperInvariant();
        }
    }
}