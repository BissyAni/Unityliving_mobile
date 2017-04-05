using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.Living.App.Portable.Models;

namespace Unity.Living.App.Portable.ViewModels
{
    public class HouseTenantandOwnerViewmodel: ViewModelBase
    {
        [JsonProperty(PropertyName = "house")]
        public HouseDetailsModel House { get; set; }
        [JsonProperty(PropertyName = "user_mapping")]
        public List<UserMapping> UserMapping { get; set; }
    }

}
