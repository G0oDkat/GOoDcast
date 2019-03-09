using System;

namespace GOoDcast.Messages
{
    interface IMessageTypeResolver
    {
        bool TryResolveType(string rawMessageType, out Type messageType);
    }
}