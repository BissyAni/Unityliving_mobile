using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Living.App.Portable.Models.OverView;

namespace Unity.Living.App.Portable.Models
{
    public class OverViewModel
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "site_name")]
        public string SiteName { get; set; }
        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "open_sr_count")]
        public int OpenSRCount { get; set; }
        [JsonProperty(PropertyName = "warning")]
        public List<Warning> Warning { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "house_list")]
        public List<HouseList> HouseList { get; set; }
    }
}
