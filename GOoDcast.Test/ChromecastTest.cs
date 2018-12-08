namespace GOoDcast.Test
{
    using System.Threading.Tasks;
    using Channels;
    using GOoDcast.Channels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChromecastTest
    {
        [TestMethod]
        public async Task ConnectDisconnectTest()
        {
            using (var chromecast = new Chromecast("192.168.0.164", "Test"))
            {
                await chromecast.ConnectAsync();
                await Task.Delay(20000);
                await chromecast.DisconnectAsync();
            }
        }

        [TestMethod]
        public async Task GetOrCreateChannelTest()
        {
            using (var chromecast = new Chromecast("192.168.0.164", "Test"))
            {
                await chromecast.ConnectAsync();

                IReceiverChannel channel = chromecast.GetOrCreateChannel(c => new ReceiverChannel(c));

                Assert.IsNotNull(channel);
                await chromecast.DisconnectAsync();
            }
        }
    }
}