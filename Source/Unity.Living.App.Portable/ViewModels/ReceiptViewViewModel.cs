using Unity.Living.App.Portable.Models;

namespace Unity.Living.App.Portable.ViewModels
{
    public class ReceiptViewViewModel: ViewModelBase
    {
        public ChargesSettled chargesSettled { get; set; }
        public PaymentReceived paymentReceived { get; set; }
        public string AdvanceBalance { get; set; }
    }

}
