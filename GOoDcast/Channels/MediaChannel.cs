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

        /// <summary>
        ///     Loads a queue items
        /// </summary>
        /// <param name="repeatMode">queue repeat mode</param>
        /// <param name="medias">media items</param>
        /// <returns>media status</returns>
        public Task QueueLoadAsync(RepeatMode repeatMode, string transportId, params MediaInformation[] medias)
        {
            return QueueLoadAsync(repeatMode, medias.Select(mi => new QueueItem {Media = mi}), transportId);
        }

        /// <summary>
        ///     Loads a queue items
        /// </summary>
        /// <param name="repeatMode">queue repeat mode</param>
        /// <param name="queueItems">items to load</param>
        /// <returns>media status</returns>
        public Task QueueLoadAsync(RepeatMode repeatMode, string transportId, params QueueItem[] queueItems)
        {
            return QueueLoadAsync(repeatMode, queueItems, transportId);
        }

        /// <summary>
        ///     Edits tracks info
        /// </summary>
        /// <param name="enabledTextTracks">true to enable text tracks, false otherwise</param>
        /// <param name="language">language for the tracks that should be active</param>
        /// <param name="activeTrackIds">track identifiers that should be active</param>
        /// <returns>media status</returns>
        public Task EditTracksInfoAsync(string transportId, string language = null, bool enabledTextTracks = true,
                                        params int[] activeTrackIds)
        {
            return
                RequestAsync(new EditTracksInfoMessage {Language = language, EnableTextTracks = enabledTextTracks, ActiveTrackIds = activeTrackIds},
                             transportId);
        }

        /// <summary>
        ///     Plays the media
        /// </summary>
        /// <param name="transportId"></param>
        /// <returns>media status</returns>
        public Task PlayAsync(string transportId)
        {
            return RequestAsync(new PlayMessage(), transportId);
        }

        /// <summary>
        ///     Pauses the media
        /// </summary>
        /// <param name="transportId"></param>
        /// <returns>media status</returns>
        public Task PauseAsync(string transportId)
        {
            return RequestAsync(new PauseMessage(), transportId);
        }

        /// <summary>
        ///     Stops the media
        /// </summary>
        /// <param name="transportId"></param>
        /// <returns>media status</returns>
        public Task StopAsync(string transportId)
        {
            return RequestAsync(new StopMessage(), transportId);
        }

        /// <summary>
        ///     Seeks to the specified time
        /// </summary>
        /// <param name="seconds">time in seconds</param>
        /// <param name="transportId"></param>
        /// <returns>media status</returns>
        public Task SeekAsync(double seconds, string transportId)
        {
            return RequestAsync(new SeekMessage {CurrentTime = seconds}, transportId);
        }

        /// <summary>
        ///     Loads a media
        /// </summary>
        /// <param name="media">media to load</param>
        /// <param name="autoPlay">true to play the media directly, false otherwise</param>
        /// <param name="activeTrackIds">track identifiers that should be active</param>
        /// <returns>media status</returns>
        public Task LoadAsync(MediaInformation media, string transportId, string sessionId, bool autoPlay = true,
                              int[] activeTrackIds = null)
        {
            return
                RequestAsync(new LoadMessage {Media = media, AutoPlay = autoPlay, /*ActiveTrackIds = activeTrackIds,*/ SessionId = sessionId},
                             transportId);
        }

        private Task RequestAsync(MediaSessionMessage message, string transportId, bool mediaSessionIdRequired = true)
        {
            long? mediaSessionId = Status?.First().MediaSessionId;
            if (mediaSessionIdRequired && mediaSessionId == null) throw new ArgumentNullException("MediaSessionId");

            message.MediaSessionId = mediaSessionId;
            return RequestAsync((IMessageWithId) message, transportId);
        }

        private async Task RequestAsync(IMessageWithId message, string transportId)
        {
            try
            {
                Status = (await RequestAsync<MediaStatusMessage>(message, transportId)).Status;
            }
            catch (Exception)
            {
                Status = null;
                throw;
            }
        }

        /// <summary>
        ///     Retrieves the status
        /// </summary>
        /// <param name="transportId"></param>
        /// <returns>the status</returns>
        public Task GetStatusAsync(string transportId)
        {
            return RequestAsync(new GetStatusMessage {MediaSessionId = Status?.First().MediaSessionId}, transportId,
                                false);
        }

        private Task QueueLoadAsync(RepeatMode repeatMode, IEnumerable<QueueItem> queueItems, string transportId)
        {
            return RequestAsync(new QueueLoadMessage {RepeatMode = repeatMode, Items = queueItems}, transportId);
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