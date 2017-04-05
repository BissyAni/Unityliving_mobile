using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using LinqToTwitter;
using Plugin.Connectivity;
using Unity.Living.App.Portable.Controls;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.Views.ServiceRequest;
using Xamarin.Forms;
using Exception = System.Exception;

namespace Unity.Living.App.Portable.ViewModels.ServiceRequest
{
    public class ServiceRequestViewModel : ViewModelBase
    {
        private INavigation navigation;
        private string status;
        private string subjectOrDescription;
        private ServiceRequestService _serviceRequestService;
        private List<ServiceModel> _bindingResult;
        private bool _loadFirst = true;
        private string _title;
        private List<ServiceModel> _serviceRequests;
        private bool _controlsEnabled=true;
        private bool _frameEnabled=false;
        public ServiceRequestViewModel(string subjectOrDescription, string status, INavigation navigation)
        {
            this.subjectOrDescription = subjectOrDescription;
            this.status = status;
            this.navigation = navigation;
            _serviceRequestService = new ServiceRequestService();
            ServiceRequests = new List<ServiceModel>();
        }

        public ICommand RefreshServiceRequests
        {
             get { return new Command(async() => await RefreshRequestList()); }  
        }

        private async Task RefreshRequestList()
        {
            try
            {
                if(_loadFirst)
                 ShowBusy(MessageHelper.Loading);
                _loadFirst = false;
                _bindingResult = await Task.Run(() => _serviceRequestService.GetAllServiceRequest());
                FrameEnabled = true;
                if (string.IsNullOrEmpty(subjectOrDescription) && string.IsNullOrEmpty(status))
                {
                    ServiceRequests = _bindingResult;
                    Title = "Service Requests - " + _bindingResult.Count();
                }
                else
                {
                    if (string.IsNullOrEmpty(subjectOrDescription))
                    {
                        ServiceRequests = (List<ServiceModel>) _bindingResult.Where(c => c.Status.ToUpper().Contains(status.ToUpper())).ToList();
                        Title = "Service Requests - " + _bindingResult.Count(c => c.Status == status);
                    }
                    else if (string.IsNullOrEmpty(status))
                    {
                        ServiceRequests =
                            (List<ServiceModel>) _bindingResult.Where(c => c.Subject.ToUpper().Contains(subjectOrDescription.ToUpper())).ToList();
                        Title = "Service Requests - " +
                                _bindingResult.Count(c => c.Subject.ToUpper().Contains(subjectOrDescription.ToUpper()));
                    }
                    else
                    {
                        ServiceRequests =
                            (List<ServiceModel>)
                            _bindingResult.Where(c => c.Status == status && c.Subject.ToUpper().Contains(subjectOrDescription.ToUpper())).ToList();
                        Title = "Service Requests - " +
                                _bindingResult.Count(c => c.Status == status && c.Subject.ToUpper().Contains(subjectOrDescription.ToUpper()));
                    }
                }
                App.ServiceRequestDescription = string.Empty;
                App.ServiceRequestId = 0;
                App.ServiceRequestStatus = string.Empty;
                App.IsRequestFiltered = false;

            }
            catch (Exception ex)
            {
                if (!CrossConnectivity.Current.IsConnected)
                    UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
            finally
            {
                HideBusy();
                IsBusy = false;
            }
        }

        public ICommand CreateRequest
        {
            get
            {
                return new Command(() =>
               {
                   navigation.PushAsync(new ServiceRequestCreate());
               });
            }
        }
        public ICommand SearchRequest
        {
            get
            {
                return new Command(() =>
                {
                    navigation.PushModalAsync(new AppNavigationPage(new ServiceRequestSearch()));
                });
            }
        }

        #region Properties
        public List<ServiceModel> ServiceRequests
        {
            get { return _serviceRequests; }
            set
            {
                _serviceRequests = value;
                OnPropertyChanged("ServiceRequests");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public bool FrameEnabled
        {
            get { return _frameEnabled; }
            set
            {
                _frameEnabled = value;
                OnPropertyChanged("FrameEnabled");
            }
        } 
        #endregion
    }
}
