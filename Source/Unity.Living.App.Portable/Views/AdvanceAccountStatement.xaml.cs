using System;
using System.Linq;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Account
{
    public partial class AdvanceAccountStatement : ContentPage
    {
        AdvanceStatementModel stmtModel;
        private int houseId;
        AdvanceAccountStatementService _accountStatementService;
        public AdvanceAccountStatement(int id)
        {
            this.houseId = id;
            this._accountStatementService = new AdvanceAccountStatementService();
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            var result = _accountStatementService.GetAllService(houseId);
            this.stmtModel = result.Result;
            Title = "Advance Account Statement of " + stmtModel.house.name;

            var advanceStatemntViewModel = stmtModel.accounts.Select(c => new AdvanceAccountStatementViewModel
            {
                Date = c.value_date,
                Doc = Convert.ToString(c.document_num),
                Description = c.description,
                Debit = c.debit_amount,
                Credit = c.credit_amount,
                AdvanceBalance = c.dues_balance,
            });
            AccountStatementView.ItemsSource = advanceStatemntViewModel;
            base.OnAppearing();           
        }

    }
}
