using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models.OverView
{
    public class Warning
    {
        [JsonProperty(PropertyName = "door_no")]
        public string DoorNumber { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}
