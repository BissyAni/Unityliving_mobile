using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.Statement
{
    public class HouseDetails
    {
        [JsonProperty(PropertyName = "tenant_name")]
        public string TenantName { get; set; }
        [JsonProperty(PropertyName = "owner_name")]
        public string OwnerName { get; set; }
        [JsonProperty(PropertyName = "house_id")]
        public int HouseId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
