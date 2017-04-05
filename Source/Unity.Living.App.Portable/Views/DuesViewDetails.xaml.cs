using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.ViewModels;
using Unity.Living.App.Portable.Views.Account;
using Unity.Living.App.Portable.Views.Charge;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Due
{
    public partial class DuesViewDetails : TabbedPage
    {
        private int houseId;
        DuesModel duesModel;
        private   double totalAmount=0;
        bool flag;
        List<GroupChargesViewModel> groupChargesViewModel;
        List<ChargesViewModel> chargesViewModel;
        DuesViewDetailsServices _duesViewDetailsServices;
        public DuesViewDetails(int hId)
        {          
            this._duesViewDetailsServices = new DuesViewDetailsServices();
            this.houseId = hId;
            InitializeComponent();
            PayOnlineButton.Clicked += PayOnlineButton_Clicked;
            PayAdvance.Clicked += PayAdvance_Clicked;
            GroupCharges.ItemSelected += GroupCharges_ItemSelected;
            ReadingView.ItemSelected += ReadingView_ItemSelected;
        }

     
        protected async override void OnAppearing()
        {
            flag = false;
            var result = _duesViewDetailsServices.GetAllCharges(houseId);
            this.duesModel = result.Result;
            Title = "Dues of " + duesModel.house.name;
            totalAmount = 0;
            totalDues.Text = duesModel.total_dues.ToString();
            overDues.Text = duesModel.over_due.ToString();
            advance.Text = duesModel.advance.ToString();
            owner.Text = duesModel.house.owner_name;
            tenent.Text = duesModel.house.tenant_name;
            GroupChargeSelected.Text = totalAmount.ToString();
            chargesViewModel = duesModel.dues_list.Select(c => new ChargesViewModel
            {
                Id=c.id,
                InvoiceDescription = Convert.ToString(c.group_bill_number),
                Description = c.description,
                Account = c.amount,
                DueDate = Convert.ToDateTime(c.due_date),
                NextFineProcess = c.next_fine_process_date,
                ChargedAmt = Convert.ToDouble(c.amount),
                SettledAmt = Convert.ToDouble(c.settled_amount),
                Balance = Convert.ToDouble(c.balance)
            }).ToList();
            ReadingView.ItemsSource = chargesViewModel;
            groupChargesViewModel = duesModel.lst_group_charge_batch.SelectMany(l => l.charge_item.Select(c => new GroupChargesViewModel
            {
                Id = c.id,
                InvoiceDescription = Convert.ToString(c.group_charge_batch_bill_no),
                Description = c.description,
                Account = c.credit_account,
                DueDate = Convert.ToDateTime(c.due_date),
                NextFineProcess = c.next_fine_process_date,
                ChargedAmt = Convert.ToDouble(c.amount),
                ChargeType=c.charge_type,
                SettledAmt = Convert.ToDouble(c.settled_amount),
                Balance = Convert.ToDouble(c.balance)
            })).ToList();
            GroupCharges.ItemsSource = groupChargesViewModel;
            base.OnAppearing();
        }
       
        private void GroupCharges_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                var groupChargesselected = (GroupChargesViewModel)e.SelectedItem;
                Navigation.PushAsync(new Charge.ChargeItem(houseId, groupChargesselected.Id, duesModel.house.name));                
            }
        }
        private void ReadingView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                var Chargesselected = (ChargesViewModel)e.SelectedItem;
                Navigation.PushAsync(new Charge.ChargeItem(houseId, Chargesselected.Id, duesModel.house.name));
            }
        }
        private void PayAdvance_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PayAdvance(duesModel.house));
        }

        private void PayOnlineButton_Clicked(object sender, EventArgs e)
        {
            if (totalAmount <= 0)
            {
                DisplayAlert("Please Select an Item intimate your payment status", "", "OK");
            }
            else {     
               List<int> settleDues = groupChargesViewModel.Where(i => i.Status == true&&i.ChargeType== "charge_item").Select(i => i.Id).ToList();
                List<int> settleDuesForCharges = chargesViewModel.Where(i => i.Status == true).Select(i => i.Id).ToList();
                List<int> creditGroupCharges= groupChargesViewModel.Where(i => i.Status == true && i.ChargeType == "credit_item").Select(i => i.Id).ToList();
                PayOnlineModel payOnlineModel = new PayOnlineModel();
                   payOnlineModel.charge_list = settleDues.Concat(settleDuesForCharges).ToList();
                payOnlineModel.credit_list = creditGroupCharges.ToList();
                Navigation.PushAsync(new SettleDues( duesModel.house, payOnlineModel));
            }
        }
        private void OnLabelAdvAcStatementClicked()
        {
            Navigation.PushAsync(new AdvanceAccountStatement(houseId));
        }

        private void OnLabelDuesAcStatementClicked()
        {
            Navigation.PushAsync(new DuesAccountStatement(houseId));
        }

        private void OnLabelAccountStatementClicked()
        {
            Navigation.PushAsync(new AccountStatement(houseId));
        }

        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            var swit = (Switch)sender;
            GroupChargesViewModel group = null;
            if (swit.BindingContext != null)
                group = (GroupChargesViewModel)swit.BindingContext;
            if (group != null)
            {
                if (swit.IsToggled == true)
                {
                    flag = true;
                    if (group.ChargeType== "credit_item")
                    {
                        totalAmount = Math.Round(totalAmount - group.Balance, 2);
                    }
                    else if(group.ChargeType == "charge_item")
                    {
                        totalAmount = Math.Round(totalAmount + group.Balance, 2);
                    }
                                  
                    GroupChargeSelected.Text = totalAmount.ToString();
                }
                else
                {
                    if (flag)
                    {
                        if (group.ChargeType == "credit_item")
                        {
                            totalAmount = Math.Round(totalAmount + group.Balance, 2);
                        }
                        else if (group.ChargeType == "charge_item")
                        {
                            totalAmount = Math.Round(totalAmount - group.Balance, 2);
                        }
                    }           
                    GroupChargeSelected.Text = totalAmount.ToString();
                }
            }
        }


        void switcherForCharges_Toggled(object sender, ToggledEventArgs e)
        {
            var swit = (Switch)sender;
            ChargesViewModel group = null;
            if (swit.BindingContext != null)
                group = (ChargesViewModel)swit.BindingContext;
            if (group != null)
            {
                if (swit.IsToggled == true)
                {
                    totalAmount = Math.Round(totalAmount + group.Balance, 2);
                    GroupChargeSelected.Text = totalAmount.ToString();
                }
                else
                {
                    if (Math.Round(totalAmount - group.Balance, 2) >= 0)
                    {
                        totalAmount = Math.Round(totalAmount - group.Balance, 2);
                    }
                    GroupChargeSelected.Text = totalAmount.ToString();
                }
            }
        }
    }
}
