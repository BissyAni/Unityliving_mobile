using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Living.App.Portable.Models.AccountStatement;

namespace Unity.Living.App.Portable.Models
{


    public class AdvanceStatementModel
    {
        [JsonProperty(PropertyName = "house")]
        public HouseForStatement House { get; set; }
        [JsonProperty(PropertyName = "accounts")]
        public List<AccountForStatement> Accounts { get; set; }
    }
}
