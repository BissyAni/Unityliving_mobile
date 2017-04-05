using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.ServiceRequestSpecific
{
    public class HouseDetailsFoServiceRequest
    {
        [JsonProperty(PropertyName = "house")]
        public string House { get; set; }
        [JsonProperty(PropertyName = "owner_name")]
        public string OwnerName { get; set; }
        [JsonProperty(PropertyName = "tenant_name")]
        public string TenantName { get; set; }
    }
}
