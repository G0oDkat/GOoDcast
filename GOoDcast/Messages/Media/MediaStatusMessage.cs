namespace GOoDcast.Messages.Media
{
    using System.Collections.Generic;
    using Models.Media;

    /// <summary>
    /// Message to retrieve the media status
    /// </summary>
    [ReceptionMessage]
    class MediaStatusMessage : StatusMessage<IEnumerable<MediaStatus>>
    {
    }
}
