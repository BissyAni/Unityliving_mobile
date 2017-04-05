using Acr.UserDialogs;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Models.DuesModels;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.Views.Account;
using Unity.Living.App.Portable.Views.Charge;
using Unity.Living.App.Portable.Views.Due;
using Xamarin.Forms;
using ChargeItem = Unity.Living.App.Portable.Models.DuesModels.ChargeItem;
using System;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Models;

namespace Unity.Living.App.Portable.ViewModels
{

    public class DueSummaryViewModel : ViewModelBase
    {
        DuesModel duesModel;
        DueService duesServices;
        private int houseId;
        private INavigation navigation;
        List<int> settleDues = new List<int>();
        List<int> settleDuesForCharges = new List<int>();
        private double totalValue;
        private List<ChargeItem> groupChargesList;
        private List<DuesList> chargesList;
        private bool groupAllChecked = false;
        private bool groupAllUnchecked = true;
        private bool chargesAllChecked = false;
        public bool Initialized = false;
        private bool chargesAllUnChecked = true;
        private double _totalDues;
        private double _overDue;
        private double _advance;
        private string _ownerName;
        private string _tenantName;
        private string _houseName;
        private double _totalValue;
        private List<WrappedListItems<ChargeItem>> _getGroupChargeList;
        private List<WrappedListItems<DuesList>> _getChargeList;
        
        public DueSummaryViewModel(int hId, INavigation navigation)
        {
            houseId = hId;
            this.navigation = navigation;
        }
        
        public async Task Initialize()
        {
            try
            {
                ShowBusy(MessageHelper.Loading);
                _getGroupChargeList = new List<WrappedListItems<ChargeItem>>();
                _getChargeList = new List<WrappedListItems<DuesList>>();
                Initialized = true;
                duesServices = new DueService();
                duesModel = await Task.Run(() => duesServices.GetAllCharges(houseId));
                if (duesModel != null)
                {
                    chargesList = duesModel.DuesList;
                    GetChargeList = chargesList.Select(item => new WrappedListItems<DuesList>()
                    { Item = item, IsChecked = false, UnChecked = true }).ToList();
                    if (duesModel.LstGroupChargeBatch != null)
                    {
                        groupChargesList = new List<ChargeItem>(duesModel.LstGroupChargeBatch.SelectMany(x => x.ChargeItem).ToList());
                        GetGroupChargeList = groupChargesList.Select(item => new WrappedListItems<ChargeItem>() { Item = item, IsChecked = false, UnChecked = true }).ToList();
                    }
                    TotalDues = duesModel.TotalDues;
                    OverDue = duesModel.OverDue;
                    Advance = duesModel.Advance;
                    TenantName = duesModel.House.TenantName;
                    OwnerName = duesModel.House.OwnerName;
                    HouseName = "Dues of " + duesModel.House.Name;

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
        }



        public ICommand PayDuesButton
        {
            get
            {
                return new Command(async () =>
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        if (GetGroupChargeList != null)
                        {
                            settleDues = GetGroupChargeList.Where(i => i.IsChecked == true && i.Item.ChargeType == "charge_item").Select(i => i.Item.Id).ToList();
                            if (GetChargeList != null)
                                settleDuesForCharges = GetChargeList.Where(i => i.IsChecked == true).Select(i => i.Item.Id).ToList();
                            List<int> creditGroupCharges = GetGroupChargeList.Where(i => i.IsChecked == true && i.Item.ChargeType == "credit_item").Select(i => i.Item.Id).ToList();
                            PayOnlineModel payOnlineModel = new PayOnlineModel();
                            if (settleDues.Count > 0 || settleDuesForCharges.Count > 0)
                            {
                                payOnlineModel.ChargeList = settleDues.Concat(settleDuesForCharges).ToList();
                                payOnlineModel.CreditList = creditGroupCharges.ToList();
                                await navigation.PushAsync(new SettleDues(duesModel.House, payOnlineModel));
                            }
                            else
                            {
                                await UserDialogs.Instance.AlertAsync(MessageHelper.SelectItem);
                            }
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
                    }
                });
            }
        }
        public ICommand PaidButton
        {
            get
            {
                return new Command(async () =>
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        if (TotalValue <= 0)
                        {
                            await UserDialogs.Instance.AlertAsync(MessageHelper.SelectCharge);
                        }
                        else
                        {
                            if (GetGroupChargeList != null)
                            {
                                settleDues = GetGroupChargeList.Where(i => i.IsChecked == true).Select(i => i.Item.Id).ToList();
                            }
                            if (GetChargeList != null)
                            {
                                settleDuesForCharges = GetChargeList.Where(i => i.IsChecked == true).Select(i => i.Item.Id).ToList();
                            }
                            var result = settleDues.Concat(settleDuesForCharges).ToList();
                            await navigation.PushAsync(new PaidCharges(result, houseId));
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
                    }
                });
            }
        }
        public ICommand PayAdvanceButton
        {
            get
            {
                return new Command(async () =>
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await navigation.PushAsync(new PayAdvance(duesModel.House));
                    }

                    else
                    {
                        UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
                    }
                });
            }

        }
        public ICommand OnAccountStatementClicked
        {
            get
            {
                return new Command(async () =>
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await navigation.PushAsync(new AccountStatement(houseId));
                    }
                    else
                    {
                        UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
                    }
                });
            }
        }

        public ICommand OnDueAccountStatementClicked
        {
            get
            {
                return new Command(async () =>
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await navigation.PushAsync(new DuesAccountStatement(houseId));
                    }
                    else
                    {
                        UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
                    }
                });
            }
        }
        public ICommand OnAdvanceAccountStatementClicked
        {
            get
            {
                return new Command(async () =>
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await navigation.PushAsync(new AdvanceAccountStatement(houseId));
                    }
                    else
                    {
                        UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
                    }
                });
            }
        }
        internal void TotalAmountSelected(WrappedListItems<DuesList> tappedItem)
        {
            var balance = Convert.ToDouble(tappedItem.Item.Balance);
            if (tappedItem.IsChecked)
            {
                TotalValue = Math.Round(TotalValue + balance, 2);
            }
            else
            {
                TotalValue = Math.Round(TotalValue - balance, 2);
            }
        }
        internal void TotalAmountSelected(WrappedListItems<ChargeItem> tappedItem)
        {
            if (tappedItem.IsChecked)
            {
                if (tappedItem.Item.ChargeType == "credit_item")
                {
                    TotalValue = Math.Round(TotalValue - tappedItem.Item.Balance, 2);
                }
                else if (tappedItem.Item.ChargeType == "charge_item")
                {
                    TotalValue = Math.Round(TotalValue + tappedItem.Item.Balance, 2);
                }
            }
            else
            {
                if (tappedItem.Item.ChargeType == "credit_item")
                {
                    TotalValue = Math.Round(TotalValue + tappedItem.Item.Balance, 2);
                }
                else if (tappedItem.Item.ChargeType == "charge_item")
                {
                    TotalValue = Math.Round(TotalValue - tappedItem.Item.Balance, 2);
                }
            }
        }
        public ICommand ToggleGroupCharge
        {
            get
            {
                return new Command(() =>
                {
                    if (GroupAllChecked)
                        GroupAllChecked = false;
                    else
                        GroupAllChecked = true;
                    SelectAllGroup(GroupAllChecked);
                });
            }
        }
        public ICommand ToggleCharge
        {
            get
            {
                return new Command(() =>
                {
                    if (ChargesAllChecked)
                        ChargesAllChecked = false;
                    else
                        ChargesAllChecked = true;
                    SelectAllCharges(ChargesAllChecked);
                });
            }
        }
        private void SelectAllCharges(bool value)
        {
            foreach (var item in GetChargeList.Where(i => i.IsChecked != value))
            {
                item.IsChecked = value;
                item.UnChecked = !value;
                TotalAmountSelected(item);
            }
        }
        private void SelectAllGroup(bool value)
        {
            foreach (var item in GetGroupChargeList.Where(i => i.IsChecked != value))
            {
                item.IsChecked = value;
                item.UnChecked = !value;
                TotalAmountSelected(item);
            }
        }
        #region Properties
        public List<WrappedListItems<ChargeItem>> GetGroupChargeList
        {
            get { return _getGroupChargeList; }
            set
            {
                _getGroupChargeList = value;
                OnPropertyChanged("GetGroupChargeList");
            }
        }

        public List<WrappedListItems<DuesList>> GetChargeList
        {
            get { return _getChargeList; }
            set
            {
                _getChargeList = value;
                OnPropertyChanged("GetChargeList");
            }
        }

        public string HouseName
        {
            get { return _houseName; }
            set
            {
                _houseName = value;
                OnPropertyChanged("HouseName");
            }
        }

        public double TotalValue
        {
            get { return _totalValue; }
            set
            {
                _totalValue = value;
                OnPropertyChanged("TotalValue");
            }
        }

        public double TotalDues
        {
            get { return _totalDues; }
            set
            {
                _totalDues = value;
                OnPropertyChanged("TotalDues");
            }
        }

        public double OverDue
        {
            get { return _overDue; }
            set
            {
                _overDue = value;
                OnPropertyChanged("OverDue");
            }
        }

        public double Advance
        {
            get { return _advance; }
            set
            {
                _advance = value;
                OnPropertyChanged("Advance");
            }
        }

        public string OwnerName
        {
            get { return _ownerName; }
            set
            {
                _ownerName = value;
                OnPropertyChanged("OwnerName");
            }
        }

        public string TenantName
        {
            get { return _tenantName; }
            set
            {
                _tenantName = value;
                OnPropertyChanged("TenantName");
            }
        }

        public bool GroupAllChecked
        {
            get { return groupAllChecked; }
            set
            {
                groupAllChecked = value;
                OnPropertyChanged("GroupAllChecked");
            }
        }
        public bool GroupAllUnchecked
        {
            get { return groupAllUnchecked; }
            set
            {
                groupAllUnchecked = value;
                OnPropertyChanged("GroupAllUnchecked");
            }
        }

        public bool ChargesAllChecked
        {
            get { return chargesAllChecked; }
            set
            {
                chargesAllChecked = value;
                OnPropertyChanged("ChargesAllChecked");
            }
        }

        public bool ChargesAllUnChecked

        {
            get { return chargesAllUnChecked; }
            set
            {
                chargesAllUnChecked = value;
                OnPropertyChanged("ChargesAllUnChecked");
            }
        }
        #endregion
    }   
}
