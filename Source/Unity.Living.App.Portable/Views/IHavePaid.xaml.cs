using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.ViewModels;
using Unity.Living.App.Portable.Views.Account;
using Unity.Living.App.Portable.Views.Due;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Charge
{
    public partial class IHavePaid : TabbedPage
    {
        private int houseId;
        DuesModel duesModel;
        private double totalAmount=0;
        DuesViewDetailsServices _duesViewDetailsServices;
        private   List<GroupChargesViewModel> groupChargesViewModel;
        private List<ChargesViewModel> chargesViewModel;
        bool flag;
        public IHavePaid(int hId)
        {
            this._duesViewDetailsServices = new DuesViewDetailsServices();
            this.houseId = hId;
            InitializeComponent();
            IhavePaidButton.Clicked += IhavePaidButton_Clicked;
            GroupCharges.ItemSelected += GroupCharges_ItemSelected;
            ReadingView.ItemSelected += ReadingView_ItemSelected;
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
                Navigation.PushModalAsync(new NavigationPage(new ChargeItem(houseId, groupChargesselected.Id, duesModel.house.name))
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.FromHex("#03A9F4")
                });
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
                Navigation.PushModalAsync(new NavigationPage(new ChargeItem(houseId, Chargesselected.Id, duesModel.house.name))
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.FromHex("#03A9F4")
                });
            }
        }
       
        protected async  override void OnAppearing()
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
                Id = c.id,
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
                ChargeType = c.charge_type,
                SettledAmt = Convert.ToDouble(c.settled_amount),
                Balance = Convert.ToDouble(c.balance)
            })).ToList();
            GroupCharges.ItemsSource = groupChargesViewModel;
            base.OnAppearing();
        }

       

      
        private void IhavePaidButton_Clicked(object sender, EventArgs e)
        {
            if (totalAmount <= 0)
            {
                DisplayAlert("select atleast one charge to settle", "", "OK");
            }
            else
            {
                List<int> settleDues=new List<int>();
                List<int> settleDuesForCharges = new List<int>();
                  if (groupChargesViewModel!=null)
                { 
                 settleDues = groupChargesViewModel.Where(i => i.Status == true).Select(i => i.Id).ToList();
                }
                  if(chargesViewModel!=null)
                { 
                settleDuesForCharges = chargesViewModel.Where(i => i.Status == true).Select(i => i.Id).ToList();
                }
                var result = settleDues.Concat(settleDuesForCharges).ToList();            
                Navigation.PushAsync(new PaidCharges(result, houseId));
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
