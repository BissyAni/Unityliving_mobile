using System;

namespace Unity.Living.App.Portable.Views.ServiceRequest
{
    public partial class ServiceRequestSearch : BaseContentPage
    {
        public ServiceRequestSearch()
        {
            InitializeComponent();       
        }     

        private void ButtonServiceRequestView_Clicked(object sender, EventArgs e)
        {
            IfConnected(() =>
            {
                string subjectOrDescriptionValue = "";
                if (subjectOrDescription.Text != null)
                {
                    subjectOrDescriptionValue = subjectOrDescription.Text;
                }
                string statusValue = "";
                if (Status.SelectedIndex == -1 || Status.SelectedIndex == 0)
                {
                    statusValue = "";
                }
                else
                {
                    statusValue = Status.Items[Status.SelectedIndex];
                }
                App.ServiceRequestDescription = subjectOrDescriptionValue;
                App.ServiceRequestStatus = statusValue;
                App.IsRequestFiltered = true;
                 Navigation.PopModalAsync();
            });
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            IfConnected(() =>
            {
                Navigation.PopModalAsync();
            });
        }
        protected override void OnAppearing()
        {
            Status.SelectedIndex = 0;
            base.OnAppearing();
        }
    }
    }
