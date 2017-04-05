using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.ViewModels.ServiceRequest;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.ServiceRequest
{
    public partial class ServiceRequestView : BaseContentPage
    {

        private ServiceRequestViewModel viewModel;
        public ServiceRequestView(string subjectOrDescription, string status)
        {
            BindingContext = viewModel = new ServiceRequestViewModel(subjectOrDescription, status, Navigation);
            InitializeComponent();
        }
        private void ReadingView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var serviceModel = (ServiceModel)e.SelectedItem;
            Navigation.PushAsync(new ServiceRequestDetails(serviceModel.ID));
            ((ListView)sender).SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.ServiceRequests.Count == 0)
                viewModel.RefreshServiceRequests.Execute(true);
            if (App.IsRequestFiltered)
            {
                BindingContext = viewModel = new ServiceRequestViewModel(App.ServiceRequestDescription, App.ServiceRequestStatus, Navigation);
                viewModel.RefreshServiceRequests.Execute(true);

            }
        }
    }
}
