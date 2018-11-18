namespace GOoDcast.Applications
{
    using System;
    using System.Threading.Tasks;
    using Channels;

    public abstract class MediaApplicationBase : ApplicationBase
    {
        protected MediaApplicationBase(string applicationId, ReceiverChannel receiverChannel, MediaChannel mediaChannel)
            : base(applicationId, receiverChannel)
        {
            MediaChannel = mediaChannel ?? throw new ArgumentNullException(nameof(mediaChannel));
        }

        protected MediaChannel MediaChannel { get; }

        public virtual async Task Play()
        {
            await MediaChannel.Play();
        }

        public virtual async Task Pause()
        {
            await MediaChannel.Pause();
        }

        public virtual async Task Seek(double seconds)
        {
            await MediaChannel.Seek(seconds);
        }

        public virtual async Task Stop()
        {
            await MediaChannel.Stop();
        }

        public virtual async Task Next()
        {
            await MediaChannel.Next();
        }

        public virtual async Task Previous()
        {
            await MediaChannel.Previous();
        }

        public async Task VolumeUp(double amount = 0.05)
        {
            await ReceiverChannel.IncreaseVolume(amount);
        }

        public async Task VolumeDown(double amount = 0.05)
        {
            await ReceiverChannel.DecreaseVolume(amount);
        }

        public async Task SetMute(bool muted)
        {
            await ReceiverChannel.SetMute(muted);
        }

        public async Task SetVolume(double volume)
        {
            await ReceiverChannel.SetVolume(volume);
        }
    }
}