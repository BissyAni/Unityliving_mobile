using Plugin.Toasts;
using System;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Owner
{
    public partial class OwnerDetailsEdit : BaseContentPage
    {
        public int id;
        UserService userDetailsService = new UserService();
        public OwnerDetailsEdit(int id)
        {
            IfConnected(() =>
            {
                var bindingResult = userDetailsService.GetOwnerEditDetails(id);
                BindingContext = bindingResult.Result;
                InitializeComponent();
                this.id = id;
            });
        }
        private async void SaveButtonOwnerDetails_Clicked(object sender, EventArgs e)
        {
            IfConnected(async() =>
            {
                UserDetailsOwnerModel userDetailsOwnerModel = new UserDetailsOwnerModel();
                userDetailsOwnerModel.House = new UserDetailsOwner()
                {
                    OwnerName = name.Text,
                    OwnerPhone1 = phone1.Text,
                    OwnerEmail = email1.Text,
                    OwnerPhone2 = phone2.Text,
                    OwnerEmail2 = email2.Text,
                    OwnerMobile = mobile.Text,
                    OwnerAddress = noteArea.Text,
                    OwnerStartDate = PeriodFromDatePicker.Date.ToString() == "1/1/1900 12:00:00 AM" ? null : PeriodFromDatePicker.Date.ToString("yyyy-MM-dd"),
                    OwnerEndDate = PeriodToDatePicker.Date.ToString() == "1/1/1900 12:00:00 AM" ? null : PeriodToDatePicker.Date.ToString("yyyy-MM-dd"),
                };
                var service = DependencyService.Get<IUserOverview>();
                var result = await service.EditUserOwnerDetails(id, userDetailsOwnerModel);
                if (result)
                {
                    MessageHelper.ShowToast(ToastNotificationType.Success, MessageHelper.UpdatedSucess);
                    Navigation.PushAsync(new User.UserDetails(id));
                }
                else
                    MessageHelper.ShowToast(ToastNotificationType.Error, "Failure");

            });
        }
    }
}
