using Newtonsoft.Json;
using System.Collections.Generic;

namespace Unity.Living.App.Portable.Models
{
    public  class PayOnlineModel
    {
        [JsonProperty(PropertyName = "charge_list")]
        public List<int> ChargeList { get; set; }
        [JsonProperty(PropertyName = "credit_list")]
        public List<int> CreditList { get; set; }       
    }
}
