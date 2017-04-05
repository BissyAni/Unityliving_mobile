using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public class UserDetailsOwner
    {
        [JsonProperty(PropertyName = "owner_name")]
        public string OwnerName { get; set; }
        [JsonProperty(PropertyName = "owner_phone1")]
        public string OwnerPhone1 { get; set; }
        [JsonProperty(PropertyName = "owner_email")]
        public string OwnerEmail { get; set; }
        [JsonProperty(PropertyName = "owner_phone2")]
        public string OwnerPhone2 { get; set; }
        [JsonProperty(PropertyName = "owner_email2")]
        public string OwnerEmail2 { get; set; }
        [JsonProperty(PropertyName = "owner_mobile")]
        public string OwnerMobile { get; set; }
        [JsonProperty(PropertyName = "owner_address")]
        public string OwnerAddress { get; set; }
        [JsonProperty(PropertyName = "owner_start_date")]
        public string OwnerStartDate { get; set; }
        [JsonProperty(PropertyName = "owner_end_date")]
        public string OwnerEndDate { get; set; }
    }
    public class UserDetailsOwnerModel
    {
        [JsonProperty(PropertyName = "house")]
        public UserDetailsOwner House { get; set; }
    }

}
