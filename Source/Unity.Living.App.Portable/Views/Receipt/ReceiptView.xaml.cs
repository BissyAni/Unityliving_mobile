using System;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Receipt
{
    public partial class ReceiptView : BaseContentPage
    {
        public ReceiptView(int Id)
        {
            InitializeComponent();
            IfConnected(() =>
            {
            var service = DependencyService.Get<IDueService>();
            var result = service.GetReceiptView(Id);

            var recieptView = new ReceiptViewViewModel
            {
                chargesSettled = new ChargesSettled
                {
                    Id = result.Result.Receipt.Id,
                    Date = result.Result.Receipt.CreatedDate.Substring(0, 10),
                    Description = result.Result.Receipt.Description,
                    Amount = result.Result.Receipt.Amount,
                    ChargedAmount = "Charged Amount " + result.Result.Receipt.Amount
                },
                paymentReceived = new PaymentReceived
                {
                    Id = result.Result.Receipt.Id,
                    Date = result.Result.Receipt.Date,
                    Description = result.Result.Receipt.Source,
                    Amount = result.Result.Receipt.Amount,
                },
                AdvanceBalance = result.Result.Receipt.AdvanceBalance
            };
            DateCharge.Text = recieptView.chargesSettled.Date;
            DescriptionCharge.Text = recieptView.chargesSettled.Description;
            AmountCharge.Text = recieptView.chargesSettled.Amount;
            ChargedAmount.Text = recieptView.chargesSettled.ChargedAmount;
            DatePay.Text = recieptView.paymentReceived.Date;
            DescriptionPay.Text = recieptView.paymentReceived.Description;
                AmountPay.Text = recieptView.paymentReceived.Amount;
            AdvanceBalance.Text = recieptView.AdvanceBalance;
            });
        }
        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
