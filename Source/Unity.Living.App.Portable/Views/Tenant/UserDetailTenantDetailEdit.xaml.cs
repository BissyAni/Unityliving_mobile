using Plugin.Toasts;
using System;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Tenant
{
    public partial class UserDetailTenantDetailEdit : BaseContentPage
    {

        UserService userDetailsService = new UserService();
        public int id;
        public UserDetailTenantDetailEdit(int id)
        {
            InitializeComponent();
            var result= userDetailsService.GetTenentEditDetails(id);
            BindingContext=result.Result;
            this.id = id;
        }
        private async void SaveButtonTenentDetails_Clicked(object sender, EventArgs e)
        {
            IfConnected(async() =>
            {
                UserDetailsTenentModel userDetailsTenentModel = new UserDetailsTenentModel();
                userDetailsTenentModel.House = new UserDetailsTenent()
                {
                    Rented = renented.IsToggled,
                    TenantName = name.Text,
                    TenantPhone1 = phone1.Text,
                    TenantPhone2 = phone2.Text,
                    TenantMobile = mobile.Text,
                    TenantEmail = email.Text,
                    TenantAddress = address.Text,
                    TenantStartDate = periodFrom.Date.ToString() == "1/1/1900 12:00:00 AM" ? null : periodFrom.Date.ToString("yyyy-MM-dd"),
                    TenantEndDate = periodTo.Date.ToString() == "1/1/1900 12:00:00 AM" ? null : periodTo.Date.ToString("yyyy-MM-dd"),
                };
                var service = DependencyService.Get<IUserOverview>();
                var result = await service.EditUserTenentDetails(id, userDetailsTenentModel);
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
