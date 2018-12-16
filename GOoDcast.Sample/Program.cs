namespace GOoDcast.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Applications;
    using Device;
    using Extensions;

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //Console.WriteLine("Locating devices");
            //IReadOnlyCollection<DeviceInfo> devices = await DeviceLocator.LocateDevicesAsync();
            //Console.WriteLine($"Devices Located: {devices.Count}");

            //if (devices.Any())

            var deviceInfo = new DeviceInfo("192.168.0.164", "Huppy Fluppy");
            try
            {
                using (var chromecast = new Chromecast(deviceInfo))
                {
                    await Reconnect(chromecast);

                    //Console.WriteLine($"Connecting to Device. IP: {deviceInfo.IpAddress} Name: {deviceInfo.FriendlyName}");
                    //await chromecast.ConnectAsync();
                    //Console.WriteLine("Device connected");

                    //WebApplication app = await chromecast.LaunchWeb();

                    //await Task.Delay(5000);
                    //await app.LoadUrl("https://www.google.de/");

                    //Console.WriteLine("Launching YouTube");
                    //YouTubeApplication app = await chromecast.LaunchYouTube();
                    //Console.WriteLine("App launched");

                    //Console.WriteLine("Loading video");
                    //await app.LoadAsync("SokndgrCMWU");
                    //Console.WriteLine("Video loaded");
                    //await app.SetIsMutedAsync(true);
                    //await Task.Delay(2000);
                    //await app.SetIsMutedAsync(false);
                    //await Task.Delay(2000);
                    //await app.SetVolumeAsync(0.5f);
                    //await Task.Delay(2000);
                    //await app.SetVolumeAsync(1f);
                    //await Task.Delay(2000);
                    //await app.PauseAsync();
                    //await Task.Delay(2000);
                    //await app.PlayAsync();
                    //await Task.Delay(2000);
                    //await app.SeekAsync(1);
                    //await Task.Delay(2000);
                    //await app.StopAsync();

                    //await Task.Delay(5000);
                    //Console.WriteLine("Stopping app");
                    //await app.StopApplicationAsync();
                    //Console.WriteLine("App stopped");
                    //await Task.Delay(5000);
                    //Console.WriteLine("Disconnecting device");
                    //await chromecast.DisconnectAsync();
                    //Console.WriteLine("Device disconnected");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
        }

        private static async Task ConnectAndDisconnect(IChromecast chromecast)
        {
            await chromecast.ConnectAsync();
            await chromecast.DisconnectAsync();
        }

        private static async Task Reconnect(IChromecast chromecast)
        {
            await chromecast.ConnectAsync();
            await chromecast.DisconnectAsync();
            await chromecast.ConnectAsync();
            await chromecast.DisconnectAsync();
        }

        private static async Task MultiConnect(IChromecast chromecast)
        {
            await chromecast.ConnectAsync();
            await chromecast.ConnectAsync();
        }

        private static async Task MultiDisconnect(IChromecast chromecast)
        {
            await chromecast.DisconnectAsync();
            await chromecast.DisconnectAsync();
        }
    }
}