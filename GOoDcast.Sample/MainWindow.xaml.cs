using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GOoDcast.Sample
{
    using Applications;
    using Device;
    using Extensions;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task _ = LoadAsync();
        }

        public async Task LoadAsync()
        {
            try
            {
                Log("Locating devices");
                IReadOnlyCollection<DeviceInfo> devices = await DeviceLocator.LocateDevicesAsync();
                Log($"Devices Located: {devices.Count}");

                if (devices.Any())
                {
                    DeviceInfo deviceInfo = devices.First();
                    using (var chromecast = new Chromecast(deviceInfo))
                    {
                        Log($"Connecting to Device. IP: {deviceInfo.IpAddress} Name: {deviceInfo.FriendlyName}");
                        await chromecast.ConnectAsync();
                        Log("Device connected");

                        Log($"Launching YouTube");
                        YouTubeApplication app = await chromecast.LaunchYouTube();
                        Log($"App launched");

                        await app.SetIsMutedAsync(true);
                        await Task.Delay(2000);
                        await app.SetIsMutedAsync(false);
                        await Task.Delay(2000);
                        await app.SetVolumeAsync(0.5f);
                        await Task.Delay(2000);
                        await app.SetVolumeAsync(1f);
                        await Task.Delay(2000);
                        await app.PauseAsync();
                        await Task.Delay(2000);
                        await app.PlayAsync();
                        await Task.Delay(2000);
                        await app.SeekAsync(1);
                        await Task.Delay(2000);
                        await app.StopAsync();


                        Log("Stopping app");
                        //await app.StopApplicationAsync();
                        Log("App stooped");
                        await Task.Delay(5000);
                        Log("Disconnecting device");
                        await chromecast.DisconnectAsync();
                        Log("Device disconnected");
                    }
                }               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void Log(string message)
        {
            LogTextBox.Text = $"{LogTextBox.Text}\n{message}";
        }
    }
}