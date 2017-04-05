using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Living.App.Portable.Models.DueStatement;

namespace Unity.Living.App.Portable.Models
{
    
   

    public class DuesStatementModel
    {
        [JsonProperty(PropertyName = "house")]
        public HouseDatas House { get; set; }
        [JsonProperty(PropertyName = "accounts")]
        public List<AccountData> Accounts { get; set; }
    }

}
