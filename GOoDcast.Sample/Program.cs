namespace GOoDcast.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Threading.Tasks;
    using System.Threading;
    using System.Threading.Tasks;
    using Applications;
    using Device;
    using Extensions;

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Locating devices");

            //IReadOnlyCollection<DeviceInfo> devices = await MdnsDeviceLocator.LocateDevicesAsync();
            IObservable<DeviceInfo> devices2 = MdnsDeviceLocator.LocateDevicesContinuous();

            DeviceInfo device = await devices2.FirstOrDefaultAsync();

            //Console.WriteLine($"Devices Located: {devices.Count}");

            if (device != null)
            {
                try
                {
                    using (var chromecast = new Chromecast(device))
                    {
                        await chromecast.ConnectAsync();

                        DashCastApplication app = await chromecast.LaunchDashCast();

                        //await app.LoadYouTubeViedeoAsync("uqKGREZs6-w");

                        //await app.LoadTwitchChannelAsync("pietsmiettv");

                        //await Task.Delay(10000);

                        await app.LoadTwitchVideoAsync("374521684");


                        //await Task.Delay(50000);

                        //await app.StopApplicationAsync();


                        //RedBullTvApplication app = await chromecast.LaunchRedBullTV();
                        //await app.LoadTvAsync();




                        //await Task.Delay(50000);

                        //await dashCast.StopApplicationAsync();
                        //await dashCast.LoadUrl("https://chuckyfuck.azurewebsites.net/home/about");
                        //await Task.Delay(5000);

                        //await dashCast.LoadUrl("https://chuckyfuck.azurewebsites.net/home/contact");
                        //await Task.Delay(5000);

                        //await dashCast.LoadUrl("https://chuckyfuck.azurewebsites.net/projects/3");
                        //await Task.Delay(5000);

                        //await dashCast.LoadUrl("https://chuckyfuck.azurewebsites.net/projects/3#&gid=1&pid=1");

                        //TwitchApplication twitch = await chromecast.LaunchTwitch();

                        //await twitch.LoadLiveStreamAsync();

                        //DefaultMediaApplication defaultMediaApplication = await chromecast.LaunchDefaultMediaApplication();

                        //await defaultMediaApplication.LoadAsync(new MediaInformation()
                        //{
                        //    ContentId = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
                        //    ContentType = "video/mp4",
                        //    StreamType = StreamType.Buffered,
                        //    Metadata = new MovieMetadata()
                        //    {
                        //        Title = "Big Buck Bunny",
                        //        Images = new []{new Image(){Url = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/images/BigBuckBunny.jpg"} }
                        //    }
                        //});

                        //await Task.Delay(5000);
                        //await defaultMediaApplication.PauseAsync();
                        //await Task.Delay(5000);
                        //await defaultMediaApplication.PlayAsync();
                        //await Task.Delay(5000);
                        //await defaultMediaApplication.SeekAsync(20);
                        //await Task.Delay(5000);
                        //await defaultMediaApplication.NextAsync();                    

                        //YouTubeApplication youTube = await chromecast.LaunchYouTube();
                        //await Task.Delay(2000);
                        //await youTube.LoadVideoAsync("3-tS0BpZFs0");

                        //await Task.Delay(Timeout.Infinite);
                        //await youTube.PauseAsync();
                        //await Task.Delay(5000);
                        //await youTube.PlayAsync();
                        //await Task.Delay(5000);
                        //await youTube.SeekAsync(20);
                        //await Task.Delay(5000);
                        //await youTube.StopAsync();
                        //await Task.Delay(5000);
                        await chromecast.DisconnectAsync();
                    }

                    //await Task.Delay(5000);
                    //using (var chromecast = new Chromecast(deviceInfo))
                    //{
                    //    await chromecast.ConnectAsync();

                    //    TwitchApplication twitch = await chromecast.LaunchTwitch();
                    //    await twitch.StopApplicationAsync();
                    //    await chromecast.DisconnectAsync();
                    //}

                    //WebApplication web = await chromecast.LaunchWeb();
                    //await web.LoadUrl("https://www.google.de/");
                    //await Task.Delay(5000);
                    //YouTubeApplication app = await chromecast.LaunchYouTube();                    
                    //await app.LoadAsync("AWKzr6n0ea0");

                    //await chromecast.DisconnectAsync();

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
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
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