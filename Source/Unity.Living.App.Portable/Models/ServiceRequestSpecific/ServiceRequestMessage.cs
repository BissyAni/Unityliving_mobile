using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.ServiceRequestSpecific
{
    public class ServiceRequestMessage
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "created_date")]
        public string CreatedDate { get; set; }
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
        [JsonProperty(PropertyName = "created_user")]
        public string CreatedUser { get; set; }
        [JsonProperty(PropertyName = "service_request")]
        public int? ServiceRequest { get; set; }
        [JsonProperty(PropertyName = "site")]
        public int? Site { get; set; }
    }
}
