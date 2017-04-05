using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.HouseAndCategory
{
    public class PreferredTiming
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "timings")]
        public string Timings { get; set; }
    }
}
