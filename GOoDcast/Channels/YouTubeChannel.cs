﻿namespace GOoDcast.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.CustomTypes;
    using Newtonsoft.Json;

    //public class YouTubeChannel : ChromecastChannel
    //{
    //    public static string Urn = "urn:x-cast:com.google.youtube.mdx";
    //    public event EventHandler<string> ScreenIdChanged;
    //    public YouTubeChannel(ChromecastClient client) : base(client, Urn)
    //    {
    //        MessageReceived += YouTubeChannel_MessageReceived;
    //    }

    //    private void YouTubeChannel_MessageReceived(object sender, ChromecastSSLClientDataReceivedArgs e)
    //    {
    //        var json = e.Message.PayloadUtf8;
    //        var response = JsonConvert.DeserializeObject<YouTubeSessionStatusResponse>(json);
    //        ScreenIdChanged?.Invoke(this, response.Data.ScreenId);
    //    }
    //}

    //public static class YouTubeChannelExtesion
    //{
    //    public static YouTubeChannel GetYouTubeChannel(this IEnumerable<IChromecastChannel> channels)
    //    {
    //        return (YouTubeChannel)channels.First(x => x.Namespace == YouTubeChannel.Urn);
    //    }
    //}
}
