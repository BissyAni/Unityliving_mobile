using Plugin.Toasts;
using System;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.User
{
    public partial class ChangePassword : BaseContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        private void ChangePassword_Clicked(object sender, EventArgs e)
        {
            IfConnected(() =>
            {
                if (Password.Text == null || Password.Text == "" || Password2.Text == null || Password2.Text == "" || OldPassword.Text == null || OldPassword.Text == "")
                {
                    DisplayAlert(MessageHelper.FillMandatory, "", "OK");
                }
                else
                {
                    var changePass = new ChangePasswordModel
                    {
                        Password = Password.Text,
                        Password2 = Password2.Text,
                        CurrentPassword = OldPassword.Text
                    };

                    var service = DependencyService.Get<IUserOverview>();
                    var result = service.ChangePassword(changePass);

                    if (result.Result == "success")
                    {
                        MessageHelper.ShowToast(ToastNotificationType.Success, MessageHelper.PasswordChanged);
                        Navigation.PushAsync(new ProfilePage());
                    }
                    else
                    {
                        MessageHelper.ShowToast(ToastNotificationType.Error, result.Result);
                    }
                }
            });
        }
        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}
