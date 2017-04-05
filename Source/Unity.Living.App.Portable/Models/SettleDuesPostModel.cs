using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Unity.Living.App.Portable.Models
{
    public class ChargeItemValues
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "settling_amount")]
        public double SettlingAmount { get; set; }
    }

    public class SettleDuesPostModel
    {
        [JsonProperty(PropertyName = "charge_items")]
        public List<ChargeItemValues> ChargeItems { get; set; }
        [JsonProperty(PropertyName = "grand_total")]
        public Double GrandTotal { get; set; }
        [JsonProperty(PropertyName = "base_settling_amount")]
        public decimal BaseSettlingAmount { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
