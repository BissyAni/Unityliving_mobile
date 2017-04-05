using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Living.App.Portable.Models.SettleDue;

namespace Unity.Living.App.Portable.Models
{
    public class SettleDuesModel
    {
        [JsonProperty(PropertyName = "advance")]
        public double Advance { get; set; }
        [JsonProperty(PropertyName = "serv_tax")]
        public string ServiceTax { get; set; }
        [JsonProperty(PropertyName = "charges")]
        public List<Charge> Charges { get; set; }
        [JsonProperty(PropertyName = "house")]
        public HouseSettleDue House { get; set; }
        [JsonProperty(PropertyName = "user_details")]
        public UserDetails UserDetails { get; set; }
        [JsonProperty(PropertyName = "credits")]
        public List<Credits> Credits { get; set; }
    }
}
