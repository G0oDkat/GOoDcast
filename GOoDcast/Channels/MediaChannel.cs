namespace GOoDcast.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Messages;
    using Messages.Media;
    using Models.Media;

    /// <summary>
    ///     Media channel
    /// </summary>
    internal class MediaChannel : StatusChannel<IEnumerable<MediaStatus>, MediaStatusMessage>, IMediaChannel
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="MediaChannel" /> class
        /// </summary>
        public MediaChannel(IChromecastClient client) : base(client, "urn:x-cast:com.google.cast.media")
        {
        }

        /// <inheritdoc />
        public Task QueueLoadAsync(string sourceId, string destinationId, RepeatMode repeatMode,
                                   params MediaInformation[] medias)
        {
            return QueueLoadAsync(sourceId, destinationId, repeatMode, medias.Select(mi => new QueueItem {Media = mi}));
        }

        /// <inheritdoc />
        public Task QueueLoadAsync(string sourceId, string destinationId, RepeatMode repeatMode,
                                   params QueueItem[] queueItems)
        {
            return QueueLoadAsync(sourceId, destinationId, repeatMode, queueItems.AsEnumerable());
        }

        /// <inheritdoc />
        public Task EditTracksInfoAsync(string sourceId, string destinationId, string language = null,
                                        bool enabledTextTracks = true, params int[] activeTrackIds)
        {
            return RequestAsync(sourceId, destinationId,
                                new EditTracksInfoMessage
                                {
                                    Language = language,
                                    EnableTextTracks = enabledTextTracks,
                                    ActiveTrackIds = activeTrackIds
                                });
        }

        /// <inheritdoc />
        public Task PlayAsync(string sourceId, string destinationId)
        {
            return RequestAsync(sourceId, destinationId, new PlayMessage());
        }

        /// <inheritdoc />
        public Task PauseAsync(string sourceId, string destinationId)
        {
            return RequestAsync(sourceId, destinationId, new PauseMessage());
        }

        /// <inheritdoc />
        public Task StopAsync(string sourceId, string destinationId)
        {
            return RequestAsync(sourceId, destinationId, new StopMessage());
        }

        /// <inheritdoc />
        public Task SeekAsync(string sourceId, string destinationId, double seconds)
        {
            return RequestAsync(sourceId, destinationId, new SeekMessage {CurrentTime = seconds});
        }

        public Task NextAsync(string sourceId, string destinationId)
        {
            return RequestAsync(sourceId, destinationId, new NextMessage());
        }

        public Task PreviousAsync(string sourceId, string destinationId)
        {
            return RequestAsync(sourceId, destinationId, new PreviousMessage());
        }

        /// <inheritdoc />
        public Task LoadAsync(string sourceId, string destinationId, MediaInformation media, string sessionId,
                              bool autoPlay = true, int[] activeTrackIds = null)
        {
            return RequestAsync(sourceId, destinationId,
                                new LoadMessage
                                {
                                    Media = media,
                                    AutoPlay = autoPlay,
                                    ActiveTrackIds = activeTrackIds,
                                    SessionId = sessionId
                                });
        }

        private Task RequestAsync(string sourceId, string destinationId, MediaSessionMessage message,
                                  bool mediaSessionIdRequired = true)
        {
            long? mediaSessionId = Status?.First().MediaSessionId;
            if (mediaSessionIdRequired && mediaSessionId == null) throw new ArgumentNullException("MediaSessionId");

            message.MediaSessionId = mediaSessionId;
            return RequestAsync(sourceId, destinationId, (IMessageWithId) message);
        }

        public Task GetStatusAsync(string sourceId, string destinationId)
        {
            return RequestAsync(sourceId, destinationId,
                                new GetStatusMessage {MediaSessionId = Status?.First().MediaSessionId}, false);
        }

        private Task QueueLoadAsync(string sourceId, string destinationId, RepeatMode repeatMode,
                                    IEnumerable<QueueItem> queueItems)
        {
            return RequestAsync(sourceId, destinationId,
                                new QueueLoadMessage {RepeatMode = repeatMode, Items = queueItems});
        }
    }
}
//    using System;
//    using System.Linq;
//    using System.Threading.Tasks;
//    using Models;
//    using Models.ChromecastRequests;
//    using Models.ChromecastStatus;
//    using Models.MediaStatus;
//    using Models.Metadata;
//    using Newtonsoft.Json;

//    public class MediaChannel : ChromecastChannel
//    {
//        public MediaChannel(IChromecastClient client, string nameSpace = "urn:x-cast:com.google.cast.media")
//            : base(client, nameSpace)
//        {
//        }

//        private MediaStatus mediaStatus;
//        //public event EventHandler<ChromecastMediaError> ErrorReceived;

//        //private void OnMessageReceived(object sender, ChromecastSSLClientDataReceivedArgs chromecastSSLClientDataReceivedArgs)
//        //{
//        //    var json = chromecastSSLClientDataReceivedArgs.Message.PayloadUtf8;
//        //    var response = JsonConvert.DeserializeObject<MediaStatusResponse>(json);
//        //    if (response.status == null)
//        //    {
//        //        var errorMessage = JsonConvert.DeserializeObject<ChromecastMediaError>(json);
//        //        ErrorReceived?.Invoke(this, errorMessage);
//        //        return;
//        //    }
//        //    if (response.status.Count == 0) return; //Initializing
//        //    Client.MediaStatus = response.status.First();
//        //    if (Client.MediaStatus.Volume != null) Client.Volume = Client.MediaStatus.Volume;
//        //    Client.CurrentMediaSessionId = Client.MediaStatus.MediaSessionId;
//        //}

//        public async Task GetMediaStatus(ApplicationSession session)
//        {
//            if (session == null) throw new ArgumentNullException(nameof(session));

//            MediaStatusResponse response = await RequestAsync<MediaStatusResponse>(new MediaStatusRequest(), TODO);
//        }

//        public async Task Seek(double seconds, ApplicationSession session)
//        {
//            if (session == null) throw new ArgumentNullException(nameof(session));

//            MediaStatusResponse response = await RequestAsync<MediaStatusResponse>(new SeekRequest(mediaStatus.MediaSessionId, seconds), TODO);
//        }

//        public async Task Pause(ApplicationSession session)
//        {
//            if (session == null) throw new ArgumentNullException(nameof(session));

//            MediaStatusResponse response = await RequestAsync<MediaStatusResponse>(new PauseRequest(mediaStatus.MediaSessionId), TODO);
//        }

//        public async Task Play(ApplicationSession session)
//        {
//            if (session == null) throw new ArgumentNullException(nameof(session));

//            MediaStatusResponse response = await RequestAsync<MediaStatusResponse>(new PlayRequest(mediaStatus.MediaSessionId), TODO);
//        }

//        public async Task Stop(ApplicationSession session)
//        {
//            if (session == null) throw new ArgumentNullException(nameof(session));

//            MediaStatusResponse response = await RequestAsync<MediaStatusResponse>(new StopMediaRequest(mediaStatus.MediaSessionId), TODO);
//        }

//        public async Task Next(ApplicationSession session)
//        {
//            if (session == null) throw new ArgumentNullException(nameof(session));

//            MediaStatusResponse response = await RequestAsync<MediaStatusResponse>(new NextRequest(mediaStatus.MediaSessionId), TODO);
//        }

//        public async Task Previous(ApplicationSession session)
//        {
//            if (session == null) throw new ArgumentNullException(nameof(session));

//            MediaStatusResponse response = await RequestAsync<MediaStatusResponse>(new PreviousRequest(mediaStatus.MediaSessionId), TODO);
//        }

//        public async Task LoadMedia(
//            ApplicationSession session,
//            string mediaUrl,
//            string contentType = "application/vnd.ms-sstr+xml",
//            IMetadata metadata = null,
//            StreamType streamType = StreamType.BUFFERED,
//            double duration = 0D,
//            object customData = null,
//            Track[] tracks = null,
//            int[] activeTrackIds = null,
//            bool autoPlay = true,
//            double currentTime = 0.0)
//        {
//            if (session == null) throw new ArgumentNullException(nameof(session));
//            var mediaObject = new MediaData(mediaUrl, contentType, metadata, streamType, duration, customData, tracks);
//            await RequestAsync<MediaStatusResponse>(new LoadRequest(session.SessionId, mediaObject, autoPlay, currentTime, customData, activeTrackIds), TODO);
//        }
//    }
//}