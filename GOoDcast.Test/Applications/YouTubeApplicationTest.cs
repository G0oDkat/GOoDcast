namespace GOoDcast.Test.Applications
{
    using System.Threading.Tasks;
    using Extensions;
    using GOoDcast.Applications;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class YouTubeApplicationTest
    {
        private Chromecast chromecast;

        [TestInitialize]
        public async Task Initialize()
        {
            chromecast = new Chromecast("192.168.0.164", "Test Chromecast");
            await chromecast.ConnectAsync();
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
            YouTubeApplication application = await chromecast.LaunchYouTube();

            //await application.LoadVideoAsync("AWKzr6n0ea0");

            await application.StopApplicationAsync();
        }
    }
}