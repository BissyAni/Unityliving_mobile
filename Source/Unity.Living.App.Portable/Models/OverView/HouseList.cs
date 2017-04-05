using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.OverView
{
    public class HouseList
    {
        [JsonProperty(PropertyName = "advance")]
        public decimal Advance { get; set; }
        [JsonProperty(PropertyName = "total_dues")]
        public decimal TotalDues { get; set; }
        [JsonProperty(PropertyName = "house_id")]
        public int HouseId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "latest_sr_id")]
        public int LatestServiceRequestId { get; set; }
        [JsonProperty(PropertyName = "latest_sr_subject")]
        public string LatestServiceRequest { get; set; }
        [JsonProperty(PropertyName = "over_due")]
        public decimal OverDue { get; set; }

    }
}
