using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Living.App.Portable.Models.ServiceRequestSpecific;

namespace Unity.Living.App.Portable.Models
{
    public class ServiceRequestSpecificModel
    {
        [JsonProperty(PropertyName = "sr")]
        public SRData ServiceReq { get; set; }
        [JsonProperty(PropertyName = "house_details")]
        public HouseDetailsFoServiceRequest house_details { get; set; }
        [JsonProperty(PropertyName = "srmessages")]
        public List<ServiceRequestMessage> srmessages { get; set; }
    }
}
