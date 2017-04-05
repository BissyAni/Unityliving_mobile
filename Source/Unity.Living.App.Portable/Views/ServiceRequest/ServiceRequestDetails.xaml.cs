using Acr.UserDialogs;
using Plugin.Connectivity;
using Plugin.Toasts;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.ServiceRequest
{
    public partial class ServiceRequestDetails : TabbedPage
    {

        ServiceRequestSpecificModel srs;
        public ObservableCollection<CommentOrMessageViewModel> messages { get; set; }
        private int _serviceRequestId;
        private IProgressDialog _busy;
        public ServiceRequestDetails(int serviceRequestId)
        {
            InitializeComponent();
            _serviceRequestId = serviceRequestId;
        }

        protected override async void OnAppearing()
        {
            messages = new ObservableCollection<CommentOrMessageViewModel>();
            try
            {
                _busy = UserDialogs.Instance.Loading(MessageHelper.Loading);
                if (_serviceRequestId != 0)
                {
                    ServiceRequestService _serviceRequestService = new ServiceRequestService();
                    var result = await Task.Run(() => _serviceRequestService.GetServiceRequestById(_serviceRequestId));
                    this.srs = result;
                    Title = "Service Request ID - " + _serviceRequestId;
                }
                lblCreatedBy.Text = srs.ServiceReq.CreatedUser.ToString();
                lblCreatedDate.Text = srs.ServiceReq.CreatedDate.Substring(0, 10);
                lblLastUpdate.Text = getLastUpdated(Convert.ToDateTime(srs.ServiceReq.UpdatedDate));
                lblHouse.Text = srs.ServiceReq.House.ToString();
                lblPrfDate.Text = srs.ServiceReq.PreferredDate.Substring(0, 10);
                lblPrfTime.Text = srs.ServiceReq.PreferredTimings;

                if (srs.ServiceReq.Closed)
                {
                    lblStatus.Text = "Closed";
                }
                else
                {
                    lblStatus.Text = "Open";
                }

                lblCloseDate.Text = srs.ServiceReq.ClosedDate;
                lblSubject.Text = srs.ServiceReq.Subject;
                var coments = srs.srmessages.Select(c => new CommentOrMessageViewModel
                {
                    Id = c.Id,
                    ServiceId = c.ServiceRequest,
                    Title = c.Content,
                    CreatedBy = Convert.ToString(c.CreatedUser),
                    CreatedDate = Convert.ToDateTime(c.CreatedDate),
                }).ToList();
                foreach (var item in coments)
                {
                    messages.Add(item);
                }
                ServiceRequestView.ItemsSource = messages;
                var tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += async (sender, e) =>
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        if (AddComments.Text == null || AddComments.Text == "")
                        {
                            UserDialogs.Instance.Alert(MessageHelper.EnterMessage);
                        }
                        else
                        {
                            AddCommentToServiceRequestModel addcom = new AddCommentToServiceRequestModel();
                            addcom.Content = AddComments.Text;
                            var service = DependencyService.Get<IServiceRequest>();
                            var result = await service.AddCommentsEdit(srs.ServiceReq.Id, addcom);
                            if (result)
                            {
                                AddComments.Text = "";
                                messages.Add(new CommentOrMessageViewModel
                                {
                                    Title = addcom.Content,
                                    CreatedBy = srs.ServiceReq.CreatedUser,
                                    CreatedDate = DateTime.Now
                                });
                                ServiceRequestView.ItemsSource = messages;
                                MessageHelper.ShowToast(ToastNotificationType.Success, MessageHelper.CommentSucess);
                            }

                            else
                                MessageHelper.ShowToast(ToastNotificationType.Error, "Failure");
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
                    }
                };
                CommentButton.GestureRecognizers.Add(tapGesture);
            }
            catch (Exception)
            {
                if (!CrossConnectivity.Current.IsConnected)
                    UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
            finally
            {
                _busy.Hide();
            }
            base.OnAppearing();
        }

        public string getLastUpdated(DateTime yourDate)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - yourDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);
            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            if (delta < 2 * MINUTE)
                return "a minute ago";
            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";
            if (delta < 90 * MINUTE)
                return "an hour ago";
            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";
            if (delta < 48 * HOUR)
                return "yesterday";
            if (delta < 30 * DAY)
                return ts.Days + " days ago";
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}
