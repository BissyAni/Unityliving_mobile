using Newtonsoft.Json;
using System.Collections.Generic;

namespace Unity.Living.App.Portable.Models
{
    public class  GetUserDetailsEditModel
    {
        [JsonProperty(PropertyName = "house")]
        public HouseEdit House { get; set; }
    }
}
