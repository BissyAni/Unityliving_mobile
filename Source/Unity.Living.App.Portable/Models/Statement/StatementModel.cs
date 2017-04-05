using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Living.App.Portable.Models.Statement;

namespace Unity.Living.App.Portable.Models
{
    public class StatementModel
    {
        [JsonProperty(PropertyName = "total_advance")]
        public double TotalAdvance { get; set; }
        [JsonProperty(PropertyName = "house")]
        public HouseDetails House { get; set; }
        [JsonProperty(PropertyName = "accounts")]
        public List<AccountDetails> Accounts { get; set; }
    }
}
