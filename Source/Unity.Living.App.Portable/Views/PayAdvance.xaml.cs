using System;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Views.Hyperlink;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Charge
{
    public partial class PayAdvance : ContentPage
    {
        HouseData house;
        public PayAdvance(HouseData house)
        {
            this.house = house;
            InitializeComponent();
            Title = "Pay Advance of " + house.name;
            owner.Text = house.owner_name;
            tenent.Text = house.tenant_name;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if ((PayingAmount.Text == "" || PayingAmount.Text == null) || (Comment.Text == "" || Comment.Text == null))
            {
                DisplayAlert("Please Enter Amount and Comment", "", "OK");
            }
            else
            {
                PayAdvanceModel payAdvModel = new PayAdvanceModel();
                payAdvModel.online_amount = Convert.ToDouble(PayingAmount.Text);
                payAdvModel.description = Comment.Text;
                var service = DependencyService.Get<IDuesService>();
                var resultPayment = await service.PayAdvance(payAdvModel, house.house_id);
                if (resultPayment != null)
                {
                    Navigation.PushAsync(new HyperlinkView(resultPayment, house.house_id));
                }
            }
        }
    }
}
