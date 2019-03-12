using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BtvEpgData
{
    [Serializable]
    [XmlRoot(ElementName = "tv")]
    public class BtvEpg
    {
        public BtvEpg()
        {
            this.ChannelList = new List<ChannelInfo>();
            this.ProgramList = new List<ProgramInfo>();

            this.generator = "btv epg grabber";
        }

        [XmlAttribute("generator-info-name")]
        public string generator { get; set; }


        [XmlElement(ElementName = "channel")]
        public List<ChannelInfo> ChannelList { get; set; }


        [XmlElement(ElementName = "programme")]
        public List<ProgramInfo> ProgramList { get; set; }
    }

    [Serializable]
    public class ChannelInfo
    {
        [XmlAttribute("id")]
        public string id { get; set; }

        [XmlElement(ElementName = "display-name")]
        public string DisplayName { get; set; }
    }

    [Serializable]
    public class ProgramInfo
    {

        public ProgramInfo()
        {
            this.title = new SubInfo();
            this.desc = new SubInfo();
            this.category = new SubInfo();
            this.credits = new CreditsInfo();
            this.rating = new RatingInfo();
        }

        [XmlAttribute("channel")]
        public string channel { get; set; }

        [XmlAttribute("start")]
        public string start { get; set; }

        [XmlAttribute("stop")]
        public string stop { get; set; }

        [XmlElement("title")]
        public SubInfo title { get; set; }

        [XmlElement("desc")]
        public SubInfo desc { get; set; }

        [XmlElement("category")]
        public SubInfo category { get; set; }

        [XmlElement("credits")]
        public CreditsInfo credits { get; set; }

        [XmlElement("rating")]
        public RatingInfo rating { get; set; }

    }

    public class SubInfo
    {
        public SubInfo()
        {
            this.Lang = "kr";
        }

        [XmlAttribute("lang")]
        public string Lang { get; set; }

        [XmlText]
        public string Desc { get; set; }
    }

    public class CreditsInfo
    {
        [XmlElement("director")]
        public string director { get; set; }

        [XmlElement("actor")]
        public string actor { get; set; }
    }

    public class RatingInfo
    {
        public RatingInfo()
        {
            this.system = "VCHIP";
        }

        [XmlAttribute("system")]
        public string system { get; set; }

        [XmlElement("value")]
        public string value { get; set; }
    }    
}
