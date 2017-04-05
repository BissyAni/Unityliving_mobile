
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models.Apartment
{
    public class ApartmentModel
    {
        [JsonProperty(PropertyName = "id")]
            public int ID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
