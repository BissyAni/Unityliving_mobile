namespace Unity.Living.App.Portable.ViewModels
{
    public class HouseDetailsViewModel: ViewModelBase
    {
        public string ID { get; set; }
        public bool IsEmailNotification { get; set; }
        public bool IsSMSNotification { get; set; }
        public bool IsNotifyTenant { get; set; }
        public bool IsAutoSettleDuesfromAdvance { get; set; }
        public string AreaInSqft { get; set; }
        public string NumberofAdults { get; set; }
        public string NumberofChildren { get; set; }
        public string IntercomNumber { get; set; }
        public string LocalBodyHouseNumber { get; set; }
        public string ElectricityConsumerNumber { get; set; }
        public string SaleDeedNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleMake { get; set; }
        public string Comments { get; set; }
        public string Resident { get; set; }

    }
}
