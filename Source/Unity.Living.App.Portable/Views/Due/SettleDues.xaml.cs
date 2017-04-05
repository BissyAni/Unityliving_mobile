using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.DuesModel;
using Unity.Living.App.Portable.ViewModels;
using Unity.Living.App.Portable.Views.Hyperlink;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Due
{
    public partial class SettleDues : ContentPage
    {
        private decimal toalAmount;
        private SettleDuesModel setlDuesMdel;
        private Models.DuesModel.HouseData houseDetails;
        private List<SettleDuesViewModel> setleDuesViewModel;
        private PayOnlineModel _payOnlineModel;
        private IProgressDialog _busy;
        public SettleDues(Models.DuesModel.HouseData houseDetails, PayOnlineModel payOnlineModel)
        {
            this.houseDetails = houseDetails;
            InitializeComponent();
            _payOnlineModel = payOnlineModel;
            Title = "Settle Dues of " + houseDetails.Name;
        }

        protected override async void OnAppearing()
        {
            try
            {
                _busy = UserDialogs.Instance.Loading(MessageHelper.Loading);
                owner.Text = houseDetails.OwnerName;
                tenent.Text = houseDetails.TenantName;
                var service = DependencyService.Get<IDueService>();
                var result = await Task.Run(() => service.GetSettleDues(houseDetails.HouseId, _payOnlineModel)) ;
                this.setlDuesMdel = result;
                setleDuesViewModel = setlDuesMdel.Charges.Select(i => new SettleDuesViewModel
                {
                    Id = i.Id,
                    Date = i.Date,
                    Description = i.Description,
                    DueDate = i.DueDate,
                    Balance = i.Balance,
                    SettingAmount = i.Balance
                }).ToList();
                SettleDuesView.ItemsSource = setleDuesViewModel;
                SettleDuesView.HeightRequest = setleDuesViewModel.Count * 30;
                toalAmount = setleDuesViewModel.Sum(i => (Convert.ToDecimal(i.SettingAmount)));
                grandTotal.Text = Convert.ToString(toalAmount);
            }
            catch (Exception)
            {
                if (!CrossConnectivity.Current.IsConnected)
                    UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
            finally
            {
                _busy.Hide();
            }
        }

        void SettlingAmount_Changed(object sender, ToggledEventArgs e)
        {
            toalAmount = setleDuesViewModel.Sum(i => string.IsNullOrWhiteSpace(i.SettingAmount) ? (decimal)0 : Convert.ToDecimal(i.SettingAmount));
            grandTotal.Text = Convert.ToString(toalAmount);
        }
        private void Payment_Clicked(object sender, EventArgs e)
        {
            var resultValue = setleDuesViewModel.Any(i => string.IsNullOrWhiteSpace(i.SettingAmount));
            if (resultValue)
            {
                DisplayAlert(MessageHelper.FillSettingAmount, "", "OK");
            }
            else
            {
                SettleDuesPostModel setlDuesPostModel = new SettleDuesPostModel();
                setlDuesPostModel.GrandTotal = Convert.ToDouble(toalAmount);
                setlDuesPostModel.BaseSettlingAmount = setleDuesViewModel.Sum(i => Convert.ToDecimal(i.Balance));
                setlDuesPostModel.Description = DescriptionArea.Text;
                setlDuesPostModel.ChargeItems = setleDuesViewModel.Select(i => new ChargeItemValues
                {
                    Id = i.Id,
                    SettlingAmount = Convert.ToDouble(i.SettingAmount)

                }).ToList();
                var service = DependencyService.Get<IDueService>();
                var resultPayment = service.SettleDuePostForPayment(setlDuesPostModel, houseDetails.HouseId);

                if (resultPayment != null)
                {
                    Navigation.PushAsync(new HyperlinkView(resultPayment.Result, houseDetails.HouseId));
                }
            }
        }


    }
}
