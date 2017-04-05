namespace Unity.Living.App.Portable.ViewModels
{
    public class UserDetailViewModel: ViewModelBase
    {
        public bool email_notification { get; set; }
        public bool notify_tenant { get; set; }
        public bool sms_notification { get; set; }
        public int HouseID { get; set; }
        public string ID { get; set; }
        public string Rented { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string IsEmailNotification { get; set; }
        public string IsSMSNotification { get; set; }
        public string IsNotifyTenant { get; set; }
        public string IsAutoSettleDuesfromAdvance { get; set; }
        public decimal AreaInSqft { get; set; }
        public int ? NumberofAdults { get; set; }
        public int ?  NumberofChildren { get; set; }
        public int ? IntercomNumber { get; set; }
        public string LocalBodyHouseNumber { get; set; }
        public string ElectricityConsumerNumber { get; set; }
        public string SaleDeedNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleMake { get; set; }
        public string Comments { get; set; }
        public string owner_name { get; set; }
        public string owner_address { get; set; }
        public string owner_phone1 { get; set; }
        public string owner_phone2 { get; set; }
        public string owner_mobile { get; set; }
        public string owner_email { get; set; }
        public string owner_email2 { get; set; }
        public string owner_start_date { get; set; }
        public string owner_end_date { get; set; }
        public string tenant_start_date { get; set; }
        public string tenant_end_date { get; set; }
        public string resident { get; set; }
    }
}
