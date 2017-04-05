namespace Unity.Living.App.Portable.ViewModels
{
    public class SettleDuesViewModel: ViewModelBase
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public string Balance { get; set; }
        public string  SettingAmount { get; set; }
    }
}
