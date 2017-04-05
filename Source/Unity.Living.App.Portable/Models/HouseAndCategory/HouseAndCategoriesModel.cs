using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Living.App.Portable.Models.HouseAndCategory;

namespace Unity.Living.App.Portable.Models
{
    public class HouseAndCategoriesModel
    {
        [JsonProperty(PropertyName = "houses")]
        public List<House> Houses { get; set; }
        [JsonProperty(PropertyName = "preferred_timings")]
        public List<PreferredTiming> PreferredTimings { get; set; }
        [JsonProperty(PropertyName = "categories")]
        public List<Category> Categories { get; set; }
        [JsonProperty(PropertyName = "sr")]
        public ServiceRequest Sr { get; set; }
    }
}
