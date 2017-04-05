using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.ViewModels;
using Unity.Living.App.Portable.Views.Hyperlink;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Due
{
    public partial class SettleDues : ContentPage
    {
        private decimal toalAmount;
        private SettleDuesModel setlDuesMdel;
        private HouseData houseDetails;
        private   List<SettleDuesViewModel> setleDuesViewModel;
        public SettleDues( HouseData houseDetails, PayOnlineModel payOnlineModel)
        {
            this.houseDetails = houseDetails;
            InitializeComponent();          
            Title = "Settle Dues of " + houseDetails.name;
            owner.Text = houseDetails.owner_name;
            tenent.Text = houseDetails.tenant_name;
            var service = DependencyService.Get<IDuesService>();
            var result = service.GetSettleDues(houseDetails.house_id, payOnlineModel);          
            this.setlDuesMdel = result.Result;
        }

        protected override void OnAppearing()
        {
             setleDuesViewModel = setlDuesMdel.charges.Select(i => new SettleDuesViewModel
            {
                Id = i.id,
                Date = i.date,
                Description = i.description,
                DueDate = i.due_date,
                Balance = i.balance,
                SettingAmount = i.balance
             }).ToList();
            SettleDuesView.ItemsSource = setleDuesViewModel;
            toalAmount = setleDuesViewModel.Sum(i => (Convert.ToDecimal(i.SettingAmount)));
            grandTotal.Text = Convert.ToString(toalAmount);
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
                DisplayAlert("Please Fill all Setting Amount", "", "OK");
            }
            else
            {
                SettleDuesPostModel setlDuesPostModel = new SettleDuesPostModel();
                setlDuesPostModel.grand_total = Convert.ToDouble(toalAmount);
                setlDuesPostModel.base_settling_amount = setleDuesViewModel.Sum(i =>Convert.ToDecimal(i.Balance));               
                setlDuesPostModel.description = DescriptionArea.Text;
                setlDuesPostModel.charge_items = setleDuesViewModel.Select(i => new ChargeItemValues
                {
                    id = i.Id,
                    settling_amount = Convert.ToDouble(i.SettingAmount)

                }).ToList();
                var service = DependencyService.Get<IDuesService>();
                var resultPayment = service.SettleDuePostForPayment(setlDuesPostModel, houseDetails.house_id);
                if (resultPayment != null)
                {
                    Navigation.PushAsync(new HyperlinkView(resultPayment.Result, houseDetails.house_id));
                }
             }
        }
    }
}
