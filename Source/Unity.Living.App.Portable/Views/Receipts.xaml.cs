using System.Linq;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Receipt
{
    public partial class Receipts : ContentPage
    {
        public Receipts(int houseId,string houseName)
        {
            InitializeComponent();
            Title = "Dues Receipts of " + houseName;
            AccountStatementView.ItemSelected += AccountStatementView_ItemSelected;
            var service = DependencyService.Get<IDuesService>();
            var result = service.GetDuereceipts(houseId);
            var mm = result.Result;
            var reciptViewModel = result.Result.receipts.Select(i => new ReceiptsViewModel
            {
                Id=i.id,
                Date = i.date,
                Description = i.description,
                Advance = i.advance ? "ok.png" : "wrong.png",
                Source=i.source,
                Amount = i.amount,            
            });
            AccountStatementView.ItemsSource = reciptViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            AccountStatementView.SelectedItem = null;
        }

        private void AccountStatementView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                var Itemselected = (ReceiptsViewModel)e.SelectedItem;
                Navigation.PushAsync(new ReceiptView(Itemselected.Id));
            }
        }
    }
}
