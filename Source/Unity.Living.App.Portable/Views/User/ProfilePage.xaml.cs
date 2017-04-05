using System;
using Unity.Living.App.Portable.Interface;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.User
{
    public partial class ProfilePage : BaseContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            IfConnected(() =>
            {
                var service = DependencyService.Get<IUserOverview>();
                var userId = service.GetCurrentUserId();
                var val = service.GetUserDetails(userId);
                name.Text = val.Result.Name;
                userName.Text = val.Result.Username;
                email.Text = val.Result.Email;
            });
        }
        private  void ChangePassword_Clicked(object sender, EventArgs e)
        {
            IfConnected(() =>
            {
                Navigation.PushModalAsync(new NavigationPage(new ChangePassword())
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.FromHex("#03A9F4")
                });
            });
        }
    }
}
