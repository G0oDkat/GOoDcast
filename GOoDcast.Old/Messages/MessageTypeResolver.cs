using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
