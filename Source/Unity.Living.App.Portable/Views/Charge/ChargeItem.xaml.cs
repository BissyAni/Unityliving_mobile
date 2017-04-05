using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Charge
{
    public partial class ChargeItem : BaseContentPage
    {
        private int _houseId;
        private string _houseName;
        private int _chargeItemId;
        public ChargeItem(int houseId, int chargeItemId, string houseName)
        {
            InitializeComponent();
            _houseId = houseId;
            _houseName = houseName;
            _chargeItemId = chargeItemId;
        }

        protected override async void OnAppearing()
        {
            try
            {
                ShowBusy(MessageHelper.Loading);
                var service = DependencyService.Get<IDueService>();
                var result = await Task.Run(() => service.ChargeItemGet(_houseId, _chargeItemId));
                if (result == null)
                {
                    DisplayAlert(MessageHelper.NoReceipt, "", "OK");
                }
                else
                {
                    HouseName.Text = _houseName;
                    Date.Text = result.ChargeItem.Date;
                    Description.Text = result.ChargeItem.Description;
                    DueDate.Text = result.ChargeItem.DueDate;
                    FineSetting.Text = result.ChargeItem.FineSetting;
                    NextFineProcessDate.Text = result.ChargeItem.NextFineProcessDate;
                    AutoSettleFromAdvance.Source = result.ChargeItem.SettleFromAdvance ? "ok.png" : "wrong.png";
                    IsThisSystemGenerated.Source = result.ChargeItem.SysGen ? "ok.png" : "wrong.png";
                    Comment.Text = result.ChargeItem.Comment;
                }
            }
            catch (Exception ex)
            {

                if (!CrossConnectivity.Current.IsConnected)
                    UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
            finally
            {
                HideBusy();
            }
            base.OnAppearing();
        }
    }
}
