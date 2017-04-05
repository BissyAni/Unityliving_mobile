using System;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Receipt
{
    public partial class Receipts : ContentPage
    {
        private int _houseId;
        private IProgressDialog _busy;
        public Receipts(int houseId, string houseName)
        {
            InitializeComponent();
            Title = "Dues Receipts of " + houseName;
            AccountStatementView.ItemSelected += AccountStatementView_ItemSelected;
            _houseId = houseId;
            StackVisibility.IsVisible = false;
        }

        protected override async void OnAppearing()
        {
            try
            {
                _busy = UserDialogs.Instance.Loading(MessageHelper.Loading);
                var service = DependencyService.Get<IDueService>();
                var result = await Task.Run(() => service.GetDuereceipts(_houseId));
                var reciptViewModel = result.Receipts.Select(i => new ReceiptsViewModel
                {
                    Id = i.Id,
                    Date = i.Date,
                    Description = i.Description,
                    Advance = i.Advance ? "ok.png" : "wrong.png",
                    Source = i.Source,
                    Amount = i.Amount,
                });
                AccountStatementView.ItemsSource = reciptViewModel;
                StackVisibility.IsVisible = true;
            }
            catch (Exception ex)
            {
                if (!CrossConnectivity.Current.IsConnected)
                    UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
            finally
            {
                _busy.Hide();
            }
            base.OnAppearing();
        }

        private void AccountStatementView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var itemselected = (ReceiptsViewModel)e.SelectedItem;
            Navigation.PushAsync(new ReceiptView(itemselected.Id));
            ((ListView)sender).SelectedItem = null;
        }
    }
}

