namespace GOoDcast.Messages.Media
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Models.Media;

    /// <summary>
    /// Message to retrieve the media status
    /// </summary>
    [DataContract]
    [ReceptionMessage]
    class MediaStatusMessage : StatusMessage<IEnumerable<MediaStatus>>
    {
    }
}
