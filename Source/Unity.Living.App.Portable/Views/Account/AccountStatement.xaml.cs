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
    public partial class AccountStatement : BaseContentPage
    {
        StatementModel stmtModel;
        private int houseId;
        AccountStatementService _accountStatementService;
        public AccountStatement(int id)
        {
            this.houseId = id;
            InitializeComponent();
            this._accountStatementService = new AccountStatementService();
            HeaderSection.IsVisible = false;
        }
        protected async override void OnAppearing()
        {
            try
            {
                ShowBusy(MessageHelper.Loading);
                var result = await Task.Run(() => _accountStatementService.GetAllService(houseId));
                if (result != null) this.stmtModel = result;
                if (stmtModel != null)
                {
                    Title = MessageHelper.AccountStatement + stmtModel.House.Name;
                    var statementViewModel = stmtModel.Accounts.Select(c => new AccountStatementViewModel
                    {
                        Date = c.ValueDate,
                        Doc = Convert.ToString(c.DocumentNumber),
                        Description = c.Description,
                        Debit = c.DebitAmount,
                        Credit = c.CreditAmount,
                        DuesBalance = c.DuesBalance,
                        AdvanceBalance = c.AdvanceTotal,
                    });
                    AccountStatementView.ItemsSource = statementViewModel;
                    HeaderSection.IsVisible = true;
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
