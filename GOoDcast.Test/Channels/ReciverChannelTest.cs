namespace GOoDcast.Test.Channels
{
    using System.Threading.Tasks;
    using GOoDcast.Channels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.ChromecastStatus;

    [TestClass]
    public class ReciverChannelTest
    {
        private ReceiverChannel channel;
        private Chromecast chromecast;

        [TestInitialize]
        public async Task Initialize()
        {
            chromecast = new Chromecast("192.168.0.164", "Test Chromecast");
            await chromecast.ConnectAsync();
            channel = chromecast.GetOrCreateChannel(client => new ReceiverChannel(client));
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await chromecast.DisconnectAsync();
            chromecast.Dispose();
        }

        [TestMethod]
        public async Task LaunchApplicationTest()
        {
            await channel.LaunchApplication("5CB45E5A");
        }

        [TestMethod]
        public async Task ConnectToApplicationTest()
        {
            await channel.ConnectToApplication("5CB45E5A");
        }

        [TestMethod]
        public async Task GetChromecastStatusTest()
        {
            await channel.RefreshChromecastStatus();
            Assert.IsNotNull(channel.Applications);
            Assert.IsNotNull(channel.IsActiveInput);
            Assert.IsNotNull(channel.IsMuted);
            Assert.IsNotNull(channel.IsStandby);
            Assert.IsNotNull(channel.Volume);
        }

        [TestMethod]
        public async Task SetMuteTest()
        {
            await channel.SetMute(true);

            Assert.IsNotNull(channel.IsMuted);
            Assert.IsTrue(channel.IsMuted.Value);

            await channel.SetMute(false);

            Assert.IsNotNull(channel.IsMuted);
            Assert.IsFalse(channel.IsMuted.Value);            
        }

        [TestMethod]
        public async Task IncreaseVolumeTest()
        {
            await channel.IncreaseVolume();
        }

        [TestMethod]
        public async Task DecreaseVolumeTest()
        {
            await channel.DecreaseVolume();
        }

        [TestMethod]
        public async Task SetVolumeTest()
        {
            await channel.SetVolume(0.5);
        }

        [TestMethod]
        public async Task StopApplicationTest()
        {
            await channel.StopApplication();
        }
    }
}