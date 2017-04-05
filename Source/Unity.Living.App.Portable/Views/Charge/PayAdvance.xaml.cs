using Acr.UserDialogs;
using System;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.DuesModel;
using Unity.Living.App.Portable.Views.Hyperlink;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Charge
{
    public partial class PayAdvance : BaseContentPage
    {
        Models.DuesModel.HouseData house;
        public PayAdvance(HouseData house)
        {
            this.house = house;
            InitializeComponent();
            Title = "Pay Advance of " + house.Name;
            owner.Text = house.OwnerName;
            tenent.Text = house.TenantName;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            IfConnected(async() =>
            {
            if ((PayingAmount.Text == "" || PayingAmount.Text == null))
            {
                    await UserDialogs.Instance.AlertAsync(MessageHelper.EnterAmount);
            }
            else
            {
                PayAdvanceModel payAdvModel = new PayAdvanceModel();
                payAdvModel.OnlineAmount = Convert.ToDouble(PayingAmount.Text);
                payAdvModel.Description = Comment.Text;


                var service = DependencyService.Get<IDueService>();
                var resultPayment = await service.PayAdvance(payAdvModel, house.HouseId);
                if (resultPayment != null)
                {
                    Navigation.PushAsync(new HyperlinkView(resultPayment, house.HouseId));
                }
            }
            });
        }
    }
}
