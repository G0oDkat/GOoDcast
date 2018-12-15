namespace GOoDcast.Channels
{
    using System;
    using Ninject.Modules;

    internal class ChannelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConnectionChannel>().To<ConnectionChannel>();
            Bind<IHeartbeatChannel>().To<HeartbeatChannel>();
            Bind<IReceiverChannel>().To<ReceiverChannel>();            
            Bind<IMediaChannel>().To<MediaChannel>();
            Bind<IWebChannel>().To<WebChannel>();
        }
    }
}