using System;
using Unity.Living.App.Portable.Interface;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Login
{
    public partial class Logout : ContentPage
    {
        public Logout()
        {
            InitializeComponent();
        }

        public INavigation ParentNavigation { get; set; }

        async void logoutButton_Clicked(object sender, EventArgs e)
        {
            var service = DependencyService.Get<ILoginService>();
            service.SaveUserData("");
            App.ClearToken();
            await Navigation.PushModalAsync(new LoginPage
            {
                ParentNavigation = ParentNavigation
            });
        }

      
    }
}
