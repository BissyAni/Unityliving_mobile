using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Living.App.Portable.Models
{
    public class HouseEdit
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "door_no")]
        public string DoorNumber { get; set; }
        [JsonProperty(PropertyName = "sort_order")]
        public int? SortOrder { get; set; }
        [JsonProperty(PropertyName = "owner_name")]
        public string OwnerName { get; set; }
        [JsonProperty(PropertyName = "owner_address")]
        public string OwnerAddress { get; set; }
        [JsonProperty(PropertyName = "owner_phone1")]
        public string OwnerPhone1 { get; set; }
        [JsonProperty(PropertyName = "owner_phone2")]
        public string OwnerPhone2 { get; set; }
        [JsonProperty(PropertyName = "owner_mobile")]
        public string OwnerMobile { get; set; }
        [JsonProperty(PropertyName = "owner_email")]
        public string OwnerEmail { get; set; }
        [JsonProperty(PropertyName = "owner_email2")]
        public string OwnerEmail2 { get; set; }
        [JsonProperty(PropertyName = "rented")]
        public bool Rented { get; set; }
        [JsonProperty(PropertyName = "tenant_name")]
        public string TenantName { get; set; }
        [JsonProperty(PropertyName = "tenant_address")]
        public string TenantAddress { get; set; }
        [JsonProperty(PropertyName = "tenant_phone1")]
        public string TenantPhone1 { get; set; }
        [JsonProperty(PropertyName = "tenant_phone2")]
        public string TenantPhone2 { get; set; }
        [JsonProperty(PropertyName = "tenant_mobile")]
        public string TenantMobile { get; set; }
        [JsonProperty(PropertyName = "tenant_email")]
        public string TenantEmail { get; set; }
        [JsonProperty(PropertyName = "email_notification")]
        public bool EmailNotification { get; set; }
        [JsonProperty(PropertyName = "sms_notification")]
        public bool SMSNotification { get; set; }
        [JsonProperty(PropertyName = "notify_tenant")]
        public bool NotifyTenant { get; set; }
        [JsonProperty(PropertyName = "area")]
        public string Area { get; set; }
        [JsonProperty(PropertyName = "num_adults")]
        public int? NumberOfAdults { get; set; }
        [JsonProperty(PropertyName = "num_children")]
        public int? NumberOfChildren { get; set; }
        [JsonProperty(PropertyName = "intercom")]
        public int? Intercom { get; set; }
        [JsonProperty(PropertyName = "local_body_house_no")]
        public string LocalBodyHouseNumber { get; set; }
        [JsonProperty(PropertyName = "electricity_cons_no")]
        public string ElectricityConsumerNumber { get; set; }
        [JsonProperty(PropertyName = "sale_deed_no")]
        public string SaleDeedNumber { get; set; }
        [JsonProperty(PropertyName = "parking_slot")]
        public string ParkingSlot { get; set; }
        [JsonProperty(PropertyName = "resident")]
        public string Resident { get; set; }
        [JsonProperty(PropertyName = "vehicle_number")]
        public string VehicleNumber { get; set; }
        [JsonProperty(PropertyName = "vehicle_make")]
        public string VehicleMake { get; set; }
        [JsonProperty(PropertyName = "comments")]
        public string Comments { get; set; }
        [JsonProperty(PropertyName = "settle_from_advance")]
        public bool SettleFromAdvance { get; set; }
        [JsonProperty(PropertyName = "owner_start_date")]
        public object OwnerStartDate { get; set; }
        [JsonProperty(PropertyName = "owner_end_date")]
        public object OwnerEndDate { get; set; }
        [JsonProperty(PropertyName = "tenant_start_date")]
        public object TenantStartDate { get; set; }
        [JsonProperty(PropertyName = "tenant_end_date")]
        public object TenantEndDate { get; set; }
        [JsonProperty(PropertyName = "account_dues")]
        public int AccountDues { get; set; }
        [JsonProperty(PropertyName = "account_adv")]
        public int AccountAdvance { get; set; }
        [JsonProperty(PropertyName = "site")]
        public int Site { get; set; }
        [JsonProperty(PropertyName = "users")]
        public List<int> Users { get; set; }
    }
}
