using Newtonsoft.Json;
using System.Collections.Generic;

namespace Unity.Living.App.Portable.Models.OverView
{
    public class LatestServiceRequest
    {
        [JsonProperty(PropertyName = "sr")]
        public List<SreviceRequestList> SRList { get; set; }
    }
} 
