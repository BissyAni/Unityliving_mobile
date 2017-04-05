using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public class ServiceRequest
    {
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "category")]
        public int Category { get; set; }
        [JsonProperty(PropertyName = "preferred_date")]
        public string PreferredDate { get; set; }
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
        [JsonProperty(PropertyName = "preferred_timings")]
        public int? PreferredTimings { get; set; }
        [JsonProperty(PropertyName = "house")]
        public int House { get; set; }
    }

}
