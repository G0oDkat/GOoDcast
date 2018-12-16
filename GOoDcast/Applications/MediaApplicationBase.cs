namespace GOoDcast.Applications
{
    using System;
    using System.Threading.Tasks;
    using Channels;
    using Miscellaneous;
    using Models.Media;

    public abstract class MediaApplicationBase : ApplicationBase
    {
        protected MediaApplicationBase(string applicationId, IConnectionChannel connectionChannel, IReceiverChannel receiverChannel, IMediaChannel mediaChannel)
            : base(applicationId, connectionChannel, receiverChannel)
        {
            MediaChannel = mediaChannel ?? throw new ArgumentNullException(nameof(mediaChannel));
        }

        protected IMediaChannel MediaChannel { get; }


        protected virtual Task LoadAsync(MediaInformation mediaInformation)
        {
            if (mediaInformation == null) throw new ArgumentNullException(nameof(mediaInformation));

            return MediaChannel.LoadAsync(DefaultIdentifiers.SourceId, TransportId, mediaInformation, SessionId);
        }


        public virtual Task PlayAsync()
        {
            return MediaChannel.PlayAsync(DefaultIdentifiers.SourceId, TransportId);
        }

        public virtual Task PauseAsync()
        {
            return MediaChannel.PauseAsync(DefaultIdentifiers.SourceId, TransportId);
        }

        public virtual Task SeekAsync(double seconds)
        {
            return MediaChannel.SeekAsync(DefaultIdentifiers.SourceId, TransportId, seconds);
        }

        public virtual Task StopAsync()
        {
            return MediaChannel.StopAsync(DefaultIdentifiers.SourceId, TransportId);
        }

        public virtual async Task NextAsync()
        {
            await MediaChannel.NextAsync(DefaultIdentifiers.SourceId, TransportId);
        }

        public virtual async Task PreviousAsync()
        {
            await MediaChannel.PreviousAsync(DefaultIdentifiers.SourceId, TransportId);
        }

        public async Task VolumeUpAsync()
        {
            await ReceiverChannel.IncreaseVolumeAsync(DefaultIdentifiers.SourceId, TransportId);
        }

        public async Task VolumeUpAsync(double amount)
        {
            await ReceiverChannel.IncreaseVolumeAsync(DefaultIdentifiers.SourceId, TransportId,amount);
        }

        public async Task VolumeDownAsync()
        {
            await ReceiverChannel.DecreaseVolumeAsync(DefaultIdentifiers.SourceId, TransportId);
        }

        public async Task VolumeDownAsync(double amount)
        {
            await ReceiverChannel.DecreaseVolumeAsync(DefaultIdentifiers.SourceId, TransportId, amount);
        }

        public async Task SetIsMutedAsync(bool muted)
        {
            await ReceiverChannel.SetIsMutedAsync(DefaultIdentifiers.SourceId, TransportId, muted);
        }

        public async Task SetVolumeAsync(float volume)
        {
            await ReceiverChannel.SetVolumeAsync(DefaultIdentifiers.SourceId, TransportId, volume);
        }
    }
}