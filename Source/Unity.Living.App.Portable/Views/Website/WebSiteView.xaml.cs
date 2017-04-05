using Acr.UserDialogs;
using Plugin.Connectivity;
using Unity.Living.App.Portable.Helpers;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.WebSite
{
    public partial class WebSiteView : ContentPage
    {
        IProgressDialog busy;
        public WebSiteView(string tittle,string url)
        {
            InitializeComponent();
            noInternetStack.IsVisible = false;
            webView.Source = url;
            this.Title = tittle;
        }

        protected override void OnAppearing()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                IsLoading.IsVisible = true;
                webViewStack.IsVisible = true;
                noInternetStack.IsVisible = false;
            }
            else
            {
                BackgroundColor = Color.FromHex("#f2f2f2");
                webViewStack.IsVisible = false;
                noInternetStack.IsVisible = true;
            }
            base.OnAppearing();
        }

        void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            IsLoading.IsVisible = true;
        }

        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            IsLoading.IsVisible = false;
        }

        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new RootPage();
            base.OnBackButtonPressed();
            return true;
               
        }
    }
}
