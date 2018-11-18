namespace GOoDcast.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Models.ChromecastRequests;
    using Models.ChromecastStatus;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ProtoBuf;

    public class ReceiverChannel : ChromecastChannel
    {
        private string chromecastApplicationId;
        private string currentApplicationSessionId;

        public ReceiverChannel(IChromecastClient client) : base(client, "urn:x-cast:com.google.cast.receiver")
        {
        }

        public float? Volume { get; private set; }

        public bool? IsMuted { get; private set; }

        public bool? IsActiveInput { get; private set; }

        public bool? IsStandby { get; set; }


        private List<ChromecastApplication> applications;

        public IReadOnlyCollection<ChromecastApplication> Applications => applications;

        //private async void ReceiverChannel_MessageReceived(object sender, ChromecastSSLClientDataReceivedArgs e)
        //{
        //    var json = e.Message.PayloadUtf8;
        //    var response = JsonConvert.DeserializeObject<ChromecastStatusResponse>(json);
        //    if (response.ChromecastStatus == null) return;
        //    Client.ChromecastStatus = response.ChromecastStatus;
        //    Client.Volume = response.ChromecastStatus.Volume;
        //    await ConnectToApplication(Client.ChromecastApplicationId);
        //}

        public async Task LaunchApplication(string applicationId, bool joinExisting = true)
        {
            chromecastApplicationId = applicationId ?? throw new ArgumentNullException(nameof(applicationId));

            //if (joinExisting && await ConnectToApplication(applicationId))
            //{
            //    //await Client.MediaChannel.GetMediaStatus();
            //    return;
            //}

            ChromecastStatusResponse response =
                await RequestAsync<LaunchRequest, ChromecastStatusResponse>(new LaunchRequest(applicationId));
        }

        public async Task<bool> ConnectToApplication(string applicationId)
        {
            throw new NotImplementedException();

            //var startedApplication = Client.ChromecastStatus?.Applications?.FirstOrDefault(x => x.AppId == applicationId);
            //if (startedApplication == null) return false;
            //if (!string.IsNullOrWhiteSpace(Client.CurrentApplicationSessionId)) return false;
            //Client.CurrentApplicationSessionId = startedApplication.SessionId;
            //Client.CurrentApplicationTransportId = startedApplication.TransportId;
            //await Client.ConnectionChannel.ConnectWithDestination();
            //Client.RunningApplication = startedApplication;
            //return true;
        }

        public async Task RefreshChromecastStatus()
        {
            ChromecastStatusResponse response =
                await RequestAsync<GetStatusRequest, ChromecastStatusResponse>(new GetStatusRequest());

            UpdateState(response.ChromecastStatus);
        }

        public async Task SetMute(bool muted)
        {
            ChromecastStatusResponse response =
                await RequestAsync<VolumeRequest, ChromecastStatusResponse>(new VolumeRequest(muted));
            UpdateState(response.ChromecastStatus);
        }

        public async Task IncreaseVolume(double amount = 0.05)
        {
            if (!Volume.HasValue)
            {
                await RefreshChromecastStatus();
            }

            await SetVolume(Volume?? 0 + amount);
        }

        public async Task DecreaseVolume(double amount = 0.05)
        {
            if (!Volume.HasValue)
            {
                await RefreshChromecastStatus();
            }

            await SetVolume(Volume ?? 100 - amount);
        }

        public async Task SetVolume(double level)
        {
            if (level < 0 || level > 1.0)
            {
                throw new ArgumentOutOfRangeException(nameof(level), level, "level must be between 0.0f and 1.0f");
            }

            var request = new VolumeRequest(level);
            ChromecastStatusResponse response = await RequestAsync<VolumeRequest, ChromecastStatusResponse>(request);
            UpdateState(response.ChromecastStatus);
        }

        public async Task StopApplication()
        {
            var request = new StopApplicationRequest(currentApplicationSessionId);
            ChromecastStatusResponse response =await RequestAsync<StopApplicationRequest, ChromecastStatusResponse>(request);
            UpdateState(response.ChromecastStatus);
        }

        private void UpdateState(ChromecastStatus status)
        {
            Volume = status.Volume.level;
            IsMuted = status.Volume.muted;
            applications.Clear();
            applications.AddRange(status.Applications);
            IsActiveInput = status.IsActiveInput;
            IsStandby = status.IsStandBy;
        }
    }
}