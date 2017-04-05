using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.OverView;
using Unity.Living.App.Portable.Views.Account;
using Unity.Living.App.Portable.Views.Charge;
using Unity.Living.App.Portable.Views.Due;
using Unity.Living.App.Portable.Views.Login;
using Unity.Living.App.Portable.Views.ServiceRequest;
using Unity.Living.App.Portable.Views.User;
using Xamarin.Forms;
using Receipts = Unity.Living.App.Portable.Views.Receipt.Receipts;

namespace Unity.Living.App.Portable.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        private INavigation navigation;
        private string _userName;
        private string _siteName;
        public bool Initialized = false;
        public string houseName { get; set; }
        public int houseId { get; set; }
        public string _latestServiceRequest { get; set; }
        public int _latestServiceRequestId { get; set; }
        private IUserOverview _service;
        private OverViewModel result;
        private LatestServiceRequest srResult;
        private string _versionValue;
        private ObservableCollection<string> _pickerItems = new ObservableCollection<string>();
        private string _selectedItem;
        private decimal _totalDues;
        private decimal _overDue;
        private decimal _advance;
        public bool Tapped = false;

        public OverviewViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public async void Initialize()
        {
            IfConnected(async () =>
            {
                Initialized = true;
                _service = DependencyService.Get<IUserOverview>();
                result = await _service.GetOverView();
                if (!App.TokenExpired)
                {
                    PickerItems.Clear();
                    if (result != null)
                    {
                        foreach (var item in result.HouseList)
                        {
                            PickerItems.Add(item.Name);
                        }
                        SelectedItem = PickerItems.First();
                    }                 
                }
                else
                {
                    App.Current.MainPage = new LoginPage();
                }
            });
        }
        public void LoadData(string selectedHouse)
        {
            IfConnected(() =>
            {
                var houseDetails = result.HouseList.FirstOrDefault(i => i.Name == selectedHouse);
                houseId = houseDetails.HouseId;
                UserName = result.UserName;
                SiteName = result.SiteName;
                houseName = houseDetails.Name;
                TotalDues = houseDetails.TotalDues;
                OverDue = houseDetails.OverDue;
                Advance = houseDetails.Advance;
                LatestServiceRequest = houseDetails.LatestServiceRequest;
                LatestServiceRequestId = houseDetails.LatestServiceRequestId;
            });
        }
        public ICommand EditDetailsTapped
        {
            get
            {
                return new Command(() =>
               {
                   Navigation(new UserDetails(houseId));
               });
            }
        }
        public ICommand ServiceRequestTapped
        {
            get
            {
                return new Command(() =>
                {
                    Navigation(new ServiceRequestView("", ""));
                });
            }
        }
        public ICommand LateServiceRequestTapped
        {
            get
            {
                return new Command(() =>
                {
                    Navigation(new ServiceRequestDetails(LatestServiceRequestId));
                });
            }
        }
        public ICommand ViewDetailsTapped
        {
            get
            {
                return new Command(() =>
                {
                    Navigation(new DuesViewDetails(houseId));
                });
            }
        }
        public ICommand HavePaidTapped
        {
            get
            {
                return new Command(() =>
                {
                    Navigation(new IHavePaid(houseId));
                });
            }
        }
        public ICommand DueStatementTapped
        {
            get
            {
                return new Command(() =>
                {
                    Navigation(new AccountStatement(houseId));
                });
            }
        }
        public ICommand ReceiptsTapped
        {
            get
            {
                return new Command(() =>
                {
                    Navigation(new Receipts(houseId, houseName));
                });
            }
        }
        public ICommand DueAccountStatementTapped
        {
            get
            {
                return new Command(() =>
                {
                    Navigation(new DuesAccountStatement(houseId));
                });
            }
        }
        public ICommand AdvanceAccountStatementTapped
        {
            get
            {
                return new Command(() =>
                {
                    Navigation(new AdvanceAccountStatement(houseId));
                });
            }
        }
        private  void Navigation<T>(T page)
        {
            if (!Tapped)
            {
                Tapped = true;
                IfConnected(() =>
                {
                    navigation.PushAsync(page as Page);
                });
            }
        }
#region Properties

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public string SiteName
        {
            get { return _siteName; }
            set
            {
                _siteName = value;
                OnPropertyChanged("SiteName");
            }
        }
        public string LatestServiceRequest
        {
            get { return _latestServiceRequest; }
            set
            {
                _latestServiceRequest = value;
                OnPropertyChanged("LatestServiceRequest");
            }
        }
        public int LatestServiceRequestId
        {
            get { return _latestServiceRequestId; }
            set
            {
                _latestServiceRequestId = value;
                OnPropertyChanged("LatestServiceRequestId");
            }
        }
        public decimal TotalDues
        {
            get { return _totalDues; }
            set
            {
                _totalDues = value;
                OnPropertyChanged("TotalDues");
            }
        }

        public decimal OverDue
        {
            get { return _overDue; }
            set
            {
                _overDue = value;
                OnPropertyChanged("OverDue");
            }
        }

        public decimal Advance
        {
            get { return _advance; }
            set
            {
                _advance = value;
                OnPropertyChanged("Advance");
            }
        }

        public ObservableCollection<string> PickerItems
        {
            get { return _pickerItems; }
            set
            {
                _pickerItems = value;
                OnPropertyChanged("PickerItems");
            }
        }

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                LoadData(_selectedItem);
                OnPropertyChanged("SelectedItem");
            }
        } 
#endregion
    }
}
