using System;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Account
{
    public partial class AdvanceAccountStatement : BaseContentPage
    {
        AdvanceStatementModel stmtModel;
        private int houseId;
        AdvanceAccountStatementService _accountStatementService;

        public AdvanceAccountStatement(int id)
        {
            this.houseId = id;
            this._accountStatementService = new AdvanceAccountStatementService();
            InitializeComponent();
            GridVisibility.IsVisible = false;
        }


        protected async override void OnAppearing()
        {
            try
            {
                ShowBusy(MessageHelper.Loading);
                var result = await Task.Run(()=>_accountStatementService.GetAllService(houseId));
                this.stmtModel = result;
                Title = MessageHelper.AccountStatement + stmtModel.House.Name;

                var advanceStatemntViewModel = stmtModel.Accounts.Select(c => new AdvanceAccountStatementViewModel
                {
                    Date = c.ValueDate,
                    Doc = Convert.ToString(c.DocumentNumber),
                    Description = c.Description,
                    Debit = c.DebitAmount,
                    Credit = c.CreditAmount,
                    AdvanceBalance = c.DuesBalance,
                });         
                AccountStatementView.ItemsSource = advanceStatemntViewModel;
                GridVisibility.IsVisible = true;
            }
            catch (Exception)
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
