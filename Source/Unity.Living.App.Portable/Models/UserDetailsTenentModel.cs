using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public class UserDetailsTenent
    {
        [JsonProperty(PropertyName = "rented")]
        public bool Rented { get; set; }
        [JsonProperty(PropertyName = "tenant_name")]
        public string TenantName { get; set; }
        [JsonProperty(PropertyName = "tenant_phone1")]
        public string TenantPhone1 { get; set; }
        [JsonProperty(PropertyName = "tenant_phone2")]
        public string TenantPhone2 { get; set; }
        [JsonProperty(PropertyName = "tenant_mobile")]
        public string TenantMobile { get; set; }
        [JsonProperty(PropertyName = "tenant_email")]
        public string TenantEmail { get; set; }
        [JsonProperty(PropertyName = "tenant_address")]
        public string TenantAddress { get; set; }
        [JsonProperty(PropertyName = "tenant_start_date")]
        public string TenantStartDate { get; set; }
        [JsonProperty(PropertyName = "tenant_end_date")]
        public string TenantEndDate { get; set; } 
    }
    public class UserDetailsTenentModel
    {
        [JsonProperty(PropertyName = "house")]
        public UserDetailsTenent House { get; set; }
    }
}
