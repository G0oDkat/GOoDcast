using System;

namespace GOoDcast.Messages
{
    class MessageTypeResolver : IMessageTypeResolver
    {

        public bool TryResolveType(string rawMessageType, out Type messageType)
        {
            switch (rawMessageType)
            {
                default:
                    messageType = null;
                    return false;
            }
        }
    }
}
