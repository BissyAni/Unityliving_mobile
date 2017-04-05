using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public  class PayAdvanceModel
    {
        [JsonProperty(PropertyName = "online_amount")]
        public double OnlineAmount { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }   
    }
}
