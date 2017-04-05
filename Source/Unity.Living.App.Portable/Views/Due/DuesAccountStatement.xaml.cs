using System;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.ViewModels;

namespace Unity.Living.App.Portable.Views.Due
{
    public partial class DuesAccountStatement : BaseContentPage
    {
        DuesStatementModel stmtModel;
        private int houseId;
        DuesAccountStatementService _accountStatementService;
        public DuesAccountStatement(int id)
        {
            this.houseId = id;
            this._accountStatementService = new DuesAccountStatementService();
            InitializeComponent();
            GridVisibility.IsVisible = false;
        }

        protected async override void OnAppearing()
        {
            try
            {
                ShowBusy((MessageHelper.Loading));
                var result = await Task.Run(() => _accountStatementService.GetAllService(houseId));
                this.stmtModel = result;
                Title = MessageHelper.DuesAccount + stmtModel.House.Name;
                var duesStatemntViewModel = stmtModel.Accounts.Select(c => new DuesAccountStatementViewModel
                {
                    Date = c.ValueDate,
                    Doc = Convert.ToString(c.DocumentNumber),
                    Description = c.Description,
                    Debit = c.DebitAmount,
                    Credit = c.CreditAmount,
                    DuesBalance = c.DuesBalance,
                });
                AccountStatementView.ItemsSource = duesStatemntViewModel;
                GridVisibility.IsVisible = true;
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
