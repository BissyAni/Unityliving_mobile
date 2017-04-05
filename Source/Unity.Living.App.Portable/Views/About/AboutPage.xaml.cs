using Unity.Living.App.Portable.Interface;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.About
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var service = DependencyService.Get<IUserOverview>();
            var result = service.GetOverView();
            var version = service.GetVersion();
            VersionValue.Text = "Version " + version;

            base.OnAppearing();
        }

    }
}
