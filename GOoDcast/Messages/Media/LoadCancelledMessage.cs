namespace GOoDcast.Messages.Media
{
    using System;

    /// <summary>
    /// Load cancelled message
    /// </summary>
    [ReceptionMessage]
    class LoadCancelledMessage : MessageWithId
    {
        //TODO
        //[OnDeserializing]
        //private void OnDeserializing(StreamingContext context)
        //{
        //    throw new Exception("Load cancelled");
        //}
    }
}
