using System.Collections.Generic;

namespace BtvAllJsonData
{
    public class Program
    {
        public string con_id { get; set; }
        public string subGenreName { get; set; }
        public string masterId { get; set; }
        public string img { get; set; }
        public string contPocCd { get; set; }
        public string mainGenreCd { get; set; }
        public object endTime { get; set; }
        public string ratingCd { get; set; }
        public string subGenreCd { get; set; }
        public string hotspotYn { get; set; }
        public object startTime { get; set; }
        public string mainGenreName { get; set; }
        public string programId { get; set; }
        public string hotspotUrl { get; set; }
        public string directorName { get; set; }
        public string shortUrl { get; set; }
        public string actorName { get; set; }
        public string programName { get; set; }
    }

    public class Channel
    {
        public List<Program> programs { get; set; }
        public string channelName { get; set; }
        public string hlsUrlPhoneSD { get; set; }
        public string servicePocCd { get; set; }
        public string chRank { get; set; }
        public string channelNo { get; set; }
        public string genreCd { get; set; }
        public string sortRank { get; set; }
        public string hlsUrlPhoneHD { get; set; }
        public string serviceId { get; set; }
        public string stillImageName { get; set; }
        public string thumbImageName { get; set; }
        public string channelImageName { get; set; }
        public string areaCd { get; set; }
        public string hlsUrlPhoneFHD { get; set; }
    }

    public class BtvAllData
    {
        public string result { get; set; }
        public string reason { get; set; }
        public string defaultServiceId { get; set; }
        public List<Channel> channels { get; set; }
        public string ver { get; set; }
        public string IF { get; set; }
        public string version { get; set; }
    }
}
