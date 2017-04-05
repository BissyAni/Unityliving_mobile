using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models.OverView
{
    public class SreviceRequestList
    {
        [JsonProperty(PropertyName = "sr_id")]
        public int ServiceRequestID { get; set; }
        [JsonProperty(PropertyName = "sr_subject")]
        public string ServiceRequestDescription { get; set; }
        [JsonProperty(PropertyName = "house_door_no")]
        public string HouseNo { get; set; }
    }
}
