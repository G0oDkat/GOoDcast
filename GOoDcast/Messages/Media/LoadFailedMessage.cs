namespace GOoDcast.Messages.Media
{
    using System;

    /// <summary>
    /// Load failed message
    /// </summary>
    [ReceptionMessage]
    class LoadFailedMessage : MessageWithId
    {

        //TODO
        //[OnDeserializing]
        //private void OnDeserializing(StreamingContext context)
        //{
        //    throw new Exception("Load failed");
        //}
    }
}
