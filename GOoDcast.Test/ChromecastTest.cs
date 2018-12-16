namespace GOoDcast.Test
{
    using System;
    using System.Threading.Tasks;
    using Channels;
    using GOoDcast.Channels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChromecastTest
    {
        private const string ChromecastName = "Test Chromecast";
        private const string IpAddress = "192.168.0.164";

        [TestMethod]
        public void ConstructionAndDisposeTest()
        {            
            using (var chromecast = new Chromecast(IpAddress, ChromecastName))
            {
                Assert.IsNotNull(chromecast);
                Assert.AreEqual(false, chromecast.IsConnected);
                Assert.AreEqual(ChromecastName, chromecast.Name);
            }
        }

        [TestMethod]
        public async Task ConnectAndDisposeTest()
        {
            using (var chromecast = new Chromecast(IpAddress, ChromecastName))
            {
                await chromecast.ConnectAsync();
                Assert.AreEqual(true, chromecast.IsConnected);
            }
        }

        [TestMethod]
        public async Task ConnectDisconnectTest()
        {
            using (var chromecast = new Chromecast(IpAddress, ChromecastName))
            {
                await chromecast.ConnectAsync();
                Assert.AreEqual(true, chromecast.IsConnected);
                await chromecast.DisconnectAsync();
                Assert.AreEqual(false, chromecast.IsConnected);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task DisconnectWithoutConnectTest()
        {
            using (var chromecast = new Chromecast(IpAddress, ChromecastName))
            {
                await chromecast.DisconnectAsync();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task ConnectMultipleTimesTest()
        {
            using (var chromecast = new Chromecast(IpAddress, ChromecastName))
            {
                await chromecast.ConnectAsync();
                await chromecast.ConnectAsync();
            }
        }

        [TestMethod]
        public async Task ReconnectTest()
        {
            using (var chromecast = new Chromecast(IpAddress, ChromecastName))
            {
                await chromecast.ConnectAsync();
                await chromecast.DisconnectAsync();
                await chromecast.ConnectAsync();
                await chromecast.DisconnectAsync();
            }
        }

        [TestMethod]
        public async Task GetChannelTest()
        {
            using (var chromecast = new Chromecast(IpAddress, ChromecastName))
            {
                await chromecast.ConnectAsync();

                IReceiverChannel channel = chromecast.GetChannel<IReceiverChannel>();

                Assert.IsNotNull(channel);
                await chromecast.DisconnectAsync();
            }
        }
    }
}