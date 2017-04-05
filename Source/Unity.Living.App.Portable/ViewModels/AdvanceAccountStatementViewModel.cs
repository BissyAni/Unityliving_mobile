namespace Unity.Living.App.Portable.ViewModels
{
    public  class AdvanceAccountStatementViewModel: ViewModelBase
    {
        public string Date { get; set; }
        public string Doc { get; set; }
        public string Description { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double AdvanceBalance { get; set; }

    }
}
