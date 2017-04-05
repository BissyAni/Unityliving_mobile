using System;

namespace Unity.Living.App.Portable.ViewModels
{
    public class OwnerDetailsViewModel: ViewModelBase
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Mobile { get; set; }
        public DateTime ? PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
    }
}
