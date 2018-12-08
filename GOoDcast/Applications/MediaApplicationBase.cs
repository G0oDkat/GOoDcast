namespace GOoDcast.Applications
{
    using System;
    using System.Threading.Tasks;
    using Channels;
    using Models.Media;

    public abstract class MediaApplicationBase : ApplicationBase
    {
        protected MediaApplicationBase(string applicationId, IReceiverChannel receiverChannel, IMediaChannel mediaChannel)
            : base(applicationId, receiverChannel)
        {
            MediaChannel = mediaChannel ?? throw new ArgumentNullException(nameof(mediaChannel));
        }

        protected IMediaChannel MediaChannel { get; }


        protected virtual Task LoadAsync(MediaInformation mediaInformation)
        {
            if (mediaInformation == null) throw new ArgumentNullException(nameof(mediaInformation));

            return MediaChannel.LoadAsync(mediaInformation, TransportId, SessionId);
        }


        public virtual Task PlayAsync()
        {
            return MediaChannel.PlayAsync(TransportId);
        }

        public virtual Task PauseAsync()
        {
            return MediaChannel.PauseAsync(TransportId);
        }

        public virtual Task SeekAsync(double seconds)
        {
            return MediaChannel.SeekAsync(seconds, TransportId);
        }

        public virtual Task StopAsync()
        {
            return MediaChannel.StopAsync(TransportId);
        }

        //public virtual async Task NextAsync()
        //{
        //    await MediaChannel.NextAsync(TransportId);
        //}

        //public virtual async Task PreviousAsync()
        //{
        //    await MediaChannel.PreviousAsync(TransportId);
        //}

        //public async Task VolumeUpAsync(double amount = 0.05)
        //{
        //    await ReceiverChannel.IncreaseVolumeAsync(amount);
        //}

        //public async Task VolumeDownAsync(double amount = 0.05)
        //{
        //    await ReceiverChannel.DecreaseVolumeAsync(amount);
        //}

        public async Task SetIsMutedAsync(bool muted)
        {
            await ReceiverChannel.SetIsMutedAsync(muted);
        }

        public async Task SetVolumeAsync(float volume)
        {
            await ReceiverChannel.SetVolumeAsync(volume);
        }
    }
}