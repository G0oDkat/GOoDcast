namespace GOoDcast.Models.ChromecastRequests
{
    using System.Runtime.Serialization;

    [DataContract]

    public class VolumeDataObject
    {
        [DataMember(Name = "level")]
        public double? Level { get; set; }

        [DataMember(Name = "muted")]
        public bool? Muted { get; set; }
    }
}