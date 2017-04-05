using Acr.UserDialogs;
using Plugin.Connectivity;
using System;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.Views.Owner;
using Unity.Living.App.Portable.Views.Tenant;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.User
{
    public partial class UserDetails : TabbedPage
    {
        UserService userDetailsService = new UserService();
        private IProgressDialog _busy;
        private int HouseID { get; set; }
        public UserDetails(int hid)
        {
            InitializeComponent();
            HouseID = hid;
        }

        protected override async void OnAppearing()
        {
            try
            {
                _busy= UserDialogs.Instance.Loading(MessageHelper.Loading);
                var bindingResult = await Task.Run(() => userDetailsService.GetUserDetails(HouseID));
                BindingContext = bindingResult;
            }
            catch (Exception ex)
            {
                if (!CrossConnectivity.Current.IsConnected)
                    UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
            finally
            {
                _busy.Hide();
            }
            base.OnAppearing();
        }

        private void EditButtonTenantDetails_Clicked(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new UserDetailTenantDetailEdit(HouseID));
            }
            else
            {
                UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
        }

        private void EditButtonHouseDetails_Clicked(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new UserDetailsHouseEdit(HouseID));
            }
            else
            {
                UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
        }

        private void EditButtonOwnerDetails_Clicked(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Navigation.PushAsync(new OwnerDetailsEdit(HouseID));
            }
            else
            {
                UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
        }
    }
}
