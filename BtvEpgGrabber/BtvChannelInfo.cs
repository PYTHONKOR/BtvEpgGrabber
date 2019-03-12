using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace BtvChannelInfo
{
    [Serializable]
    [XmlRoot("BtvChannelList")]
    public class BtvChannelList
    {
        [XmlArray("ChannelList"), XmlArrayItem(typeof(ChannelInfo), ElementName = "ChannelInfo")]
        public List<ChannelInfo> ChannelList { get; set; }
    }

    [Serializable]
    public class ChannelInfo
    {
        public string ChannelName { get; set; }
        public string ChannelNo { get; set; }
        public string ServiceId { get; set; }
        public string ChannelId { get; set; }
    }
}