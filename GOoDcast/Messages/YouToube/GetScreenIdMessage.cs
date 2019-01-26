using System;
using System.Collections.Generic;
using System.Text;

namespace GOoDcast.Messages.YouToube
{
    using System.Runtime.Serialization;

    class GetScreenIdMessage
    {
        public GetScreenIdMessage()
        {
            Type = "TYPE_GET_SCREEN_ID";
        }

        [DataMember(Name = "MESSAGE_TYPE")]
        public string Type { get; set; }
    }
}
