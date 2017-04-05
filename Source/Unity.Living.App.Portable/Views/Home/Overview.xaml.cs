using System;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Home
{
    public partial class Overview : BaseContentPage
    {
        private OverviewViewModel viewModel;
        public Overview()
        {
            BindingContext = viewModel = new OverviewViewModel(Navigation);
            InitializeComponent();            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!viewModel.Initialized)
                viewModel.Initialize();
            viewModel.Tapped = false;
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert(null, "Do you realy want to exit application?", "Yes", "No");
                if (result)
                {
                    await closeApp();
                }
            });
            return true;
        }
        private async Task closeApp()
        {
            DependencyService.Get<ICloseAppAlert>().CloseApp();
        }
    }
}
