namespace GOoDcast.Channels
{
    using Ninject.Modules;

    internal class ChannelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConnectionChannel>().To<ConnectionChannel>();
            Bind<IHeartbeatChannel>().To<HeartbeatChannel>();
            Bind<IReceiverChannel>().To<ReceiverChannel>();            
            Bind<IMediaChannel>().To<MediaChannel>();
            Bind<IDashCastChannel>().To<DashCastChannel>();
            Bind<IYouTubeChannel>().To<YouTubeChannel>();
        }
    }
}