using Acr.UserDialogs;
using Plugin.Connectivity;
using Plugin.Toasts;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Views.Due;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Hyperlink
{
    public partial class HyperlinkView : ContentPage
    {
        IProgressDialog busy;
        int hid;
        private OnlinePaymentModel paymentModel;
        public HyperlinkView(OnlinePaymentModel paymentModel,int hid)
        {
            InitializeComponent();
            noInternetStack.IsVisible = false;
            this.paymentModel = paymentModel;
            this.hid = hid;
            this.Title = "Payment";
        }
        protected override void OnAppearing()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                busy = UserDialogs.Instance.Loading(MessageHelper.Loading);
                webViewStack.IsVisible = true;
                noInternetStack.IsVisible = false;
                var service = DependencyService.Get<IDueService>();
                var result = service.PaymentURL(paymentModel);
                webView.Source = result.Result;
            }
            else
            {
                busy.Hide();
                BackgroundColor = Color.FromHex("#f2f2f2");
                webViewStack.IsVisible = false;
                noInternetStack.IsVisible = true;
            }
            base.OnAppearing();
        }
        void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
          
        }

        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            if (e.Url == paymentModel.Posted.Surl)
            {
                MessageHelper.ShowToast(ToastNotificationType.Success, "Success");
                Navigation.PushAsync(new DuesViewDetails(hid));
            }
         
            else if (e.Url == paymentModel.Posted.Furl)
            {

                Navigation.PushAsync(new DuesViewDetails(hid));
                MessageHelper.ShowToast(ToastNotificationType.Error, "Failure");
            }
            
            busy.Hide();
        }

    }
}
