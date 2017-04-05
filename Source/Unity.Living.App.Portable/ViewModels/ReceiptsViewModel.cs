namespace Unity.Living.App.Portable.ViewModels
{
    public  class ReceiptsViewModel: ViewModelBase
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Advance { get; set; }
        public string Source { get; set; }
        public string Amount { get; set; } 
    }
}
