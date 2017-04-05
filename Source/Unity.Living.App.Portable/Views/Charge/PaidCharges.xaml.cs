using Newtonsoft.Json;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Charge
{
    public partial class PaidCharges : BaseContentPage
    {
        private List<int> Ids;
        private int hId;
        public PaidCharges(List<int> Ids,int  hId)
        {
            InitializeComponent();
            this.hId = hId;
            this.Ids = Ids;
            ModeOfPayment.SelectedIndexChanged += ModeOfPayment_SelectedIndexChanged;
            BankBranch.IsVisible = false;
            BankName.IsVisible = false;
            Reference.IsVisible = false;
            ChequeNo.IsVisible = false;
        }

        private void ModeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedIndex = ModeOfPayment.SelectedIndex;
            if (SelectedIndex == 0)
            {
                BankBranch.IsVisible = false;
                BankName.IsVisible = true;
                Reference.IsVisible = true;
                ChequeNo.IsVisible = false;
            }
            else if (SelectedIndex == 1)
            {
                BankBranch.IsVisible = true;
                BankName.IsVisible = true;
                Reference.IsVisible = false;
                ChequeNo.IsVisible = true;
            }
            else if (SelectedIndex == 2)
            {
                BankBranch.IsVisible = false;
                BankName.IsVisible = false;
                Reference.IsVisible = true;
                ChequeNo.IsVisible = false;
            }
        }


        private async void Update_Clicked(object sender, EventArgs e)
        {
            IfConnected(async() =>
            {
            PaidChargesModel paid = new PaidChargesModel();
            if (ModeOfPayment.SelectedIndex == -1)
            {
                DisplayAlert(MessageHelper.SelectPaymentMode, "", "OK");
            }
            else
            {               
                paid.Date = DateValue.Date.ToString("yyyy-MM-dd");
                paid.Description = description.Text;
                paid.ModeOfPayment = ModeOfPayment.Items[ModeOfPayment.SelectedIndex];
                var jsontemp = JsonConvert.SerializeObject(Ids);
                paid.PaidChargesId = jsontemp;

                if (ModeOfPayment.SelectedIndex == 0)
                {
                    paid.BankName = BankNameValue.Text;
                    paid.Reference = ReferenceValue.Text;
                }
                else if (ModeOfPayment.SelectedIndex == 1)
                {
                    paid.BankBranch = BankBranchValue.Text;
                    paid.BankName = BankNameValue.Text;
                    paid.ChequeNumber = chequeNoValue.Text;
                }
                else if (ModeOfPayment.SelectedIndex == 2)
                {
                    paid.Reference = ReferenceValue.Text;

                }
                var service = DependencyService.Get<IDueService>();
                var result = await service.PaidChargesPost(paid);

                if (result)
                {
                    MessageHelper.ShowToast(ToastNotificationType.Success, "Success");
                    Navigation.PushAsync(new IHavePaid(hId));
                }
                else
                    MessageHelper.ShowToast(ToastNotificationType.Error, "Failure");
            }          
        });      

        }
    }
}
