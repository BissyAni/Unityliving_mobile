using Plugin.Toasts;
using System;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Service;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.User
{
    public partial class UserDetailsHouseEdit : BaseContentPage
    {
        UserService userDetailsService = new UserService();
        public int id;
        public UserDetailsHouseEdit(int id)
        {
            InitializeComponent();
            IfConnected(() =>
            {
                var bindingResult = userDetailsService.GetHouseEditDetails(id);
                BindingContext = bindingResult.Result;
                Status.SelectedIndex = Status.Items.IndexOf(bindingResult.Result.Resident);
                this.id = id;
            });
        }

        void NumberofAdults_TextChanged(object sender, TextChangedEventArgs e)
        {
            IfConnected(() =>
            {
                if (e.NewTextValue != "" && e.NewTextValue != null )
                {
                    if (e.NewTextValue.Substring(e.NewTextValue.Length - 1, 1) == ".")
                        adultNo.Text = e.OldTextValue;
                }
            });
        }

        void NumberofChildren_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "" && e.NewTextValue != null)
            {
                if (e.NewTextValue.Substring(e.NewTextValue.Length - 1, 1) == ".")
                    childrenNo.Text = e.OldTextValue;
            }
        }

        void IntercomNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "" && e.NewTextValue != null)
            {
                if(e.NewTextValue.Length>=11)
                        { intercomNumber.Text = e.OldTextValue;
                    }
                if (e.NewTextValue.Substring(e.NewTextValue.Length - 1, 1) == ".")
                    intercomNumber.Text = e.OldTextValue;
            }
        }

        private async void SaveButtonHouseDetails_Clicked(object sender, EventArgs e)
        {
            IfConnected(async() =>
            {
                UserDetailsHouseModel userDetailshouseModel = new UserDetailsHouseModel();
                userDetailshouseModel.House = new UserDetailsHouse()
                {
                    NotifyTenant = notifyTenent.IsToggled,
                    NumberOfAdults = adultNo.Text != "" ? Convert.ToInt32(adultNo.Text) : 0,
                    NumberOfChildren = childrenNo.Text != "" ? Convert.ToInt32(childrenNo.Text) : 0,
                    Intercom = intercomNumber.Text != "" ? Convert.ToInt32(intercomNumber.Text) : (int?)null,
                    LocalBodyHouseNumber = localBodyHouseNo.Text,
                    ElectricityConsumerNumber = electricityConsumerNo.Text,
                    SaleDeedNumber = saleDeedNo.Text,
                    VehicleNumber = vehicleNo.Text,
                    VehicleMake = vehicleMake.Text,
                    Comments = comments.Text,
                    Resident = Status.Items[Status.SelectedIndex]
                };
                var service = DependencyService.Get<IUserOverview>();
                var result = await service.EditUserHouseDetails(id, userDetailshouseModel);
                if (result)
                {
                    MessageHelper.ShowToast(ToastNotificationType.Success, MessageHelper.UpdatedSucess);
                    Navigation.PushAsync(new UserDetails(id));
                }
                else
                    MessageHelper.ShowToast(ToastNotificationType.Error, "Failure");
            });
        }
    }
}
