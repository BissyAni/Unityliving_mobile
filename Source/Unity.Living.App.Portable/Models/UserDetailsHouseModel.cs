using Newtonsoft.Json;

namespace Unity.Living.App.Portable.Models
{
    public class UserDetailsHouse
    {
        [JsonProperty(PropertyName = "notify_tenant")]
        public bool NotifyTenant { get; set; }
        [JsonProperty(PropertyName = "num_adults")]
        public int NumberOfAdults { get; set; }
        [JsonProperty(PropertyName = "num_children")]
        public int NumberOfChildren { get; set; }
        [JsonProperty(PropertyName = "intercom")]
        public int ? Intercom { get; set; }
        [JsonProperty(PropertyName = "local_body_house_no")]
        public string LocalBodyHouseNumber { get; set; }
        [JsonProperty(PropertyName = "electricity_cons_no")]
        public string ElectricityConsumerNumber { get; set; }
        [JsonProperty(PropertyName = "sale_deed_no")]
        public string SaleDeedNumber { get; set; }
        [JsonProperty(PropertyName = "vehicle_number")]
        public string VehicleNumber { get; set; }
        [JsonProperty(PropertyName = "vehicle_make")]
        public string VehicleMake { get; set; }
        [JsonProperty(PropertyName = "comments")]
        public string Comments { get; set; }
        [JsonProperty(PropertyName = "resident")]
        public string Resident { get; set; }

    }
    public class UserDetailsHouseModel
    {
        [JsonProperty(PropertyName = "house")]
        public UserDetailsHouse House { get; set; }
    }
}
