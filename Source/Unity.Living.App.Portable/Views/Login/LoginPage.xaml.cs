using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Models;
using Unity.Living.App.Portable.Models.Apartment;
using Unity.Living.App.Portable.Service;
using Unity.Living.App.Portable.ViewModels;
using Xamarin.Forms;
using System.Collections;
using System.Linq;
using LinqToTwitter;

namespace Unity.Living.App.Portable.Views.Login
{
    public partial class LoginPage : ContentPage
    {
        private ApartmentService apartmentService;
        List<ApartmentModel> apartment;
        private LoginPageViewModel viewModel;
        public LoginPage()
        {
            BindingContext = viewModel = new LoginPageViewModel();
            apartmentService =new ApartmentService();
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var serviceValue = DependencyService.Get<ILoginService>();
            string appartmentDataTaken= serviceValue.GetAppartment();
            if(!string.IsNullOrEmpty(appartmentDataTaken))
            {
                ApartmentName.Text = appartmentDataTaken;
            }

            if (App.IsLoggedIn)
            {
                var MainPage = new RootPage();
                Navigation.PushModalAsync(new NavigationPage(MainPage));
            }
            else
            {
                PageInit();
            }
        }
        private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                SearchBar searchBar = (SearchBar)sender;
                string searchText = searchBar.Text;
                ApartmentListView.ItemsSource = (viewModel).filteredList(searchText);      
            }
            else
            {
                UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
        }
        protected virtual void PageInit()
        {
        }
        public INavigation ParentNavigation { get; set; }
        public const int Latency = 30000;
        bool ValidateLoginInput(out string message)
        {
            bool isValid = true;
            message = "";
            if (string.IsNullOrEmpty(ApartmentName.Text))
            {
                isValid = false;
                message += MessageHelper.EnterApartmentName + "\n";
            }
            if (string.IsNullOrEmpty(loginuserName.Text))
            {
                isValid = false;
                message += MessageHelper.EnterUserName + "\n";
            }
            if (string.IsNullOrEmpty(loginpassword.Text))
            {
                isValid = false;
                message += MessageHelper.EnterPassword + "\n";
            }
            return isValid;
        }
               
        async void SignInButton_Clicked(object sender, EventArgs e)
        {
            var errorMessage = "";
            var valid = ValidateLoginInput(out errorMessage);
            if (valid)
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    ShowBusy(MessageHelper.LoggingIn);
                    TryExecute(async () =>
                        {
                            var payload = new SignInModel
                            {
                                Username = loginuserName.Text.Trim(),
                                Password = loginpassword.Text.Trim(),
                                ApartmentName = ApartmentName.Text.Trim()
                            };

                            var task = await SignInTask(payload);
                            HideBusy();
                        });
                }
                else
                {
                    UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
                }
            }
            else
            {
                await DisplayAlert(MessageHelper.InvalidInput, errorMessage, "OK");
            }
        }

        protected void ReportCrash(Exception exception)
        {            
        }

        protected bool IsBadTask(Task task)
        {
            if (task.Status == TaskStatus.Faulted)
            {
                UserDialogs.Instance.ErrorToast(MessageHelper.ServerError);
                return true;
            }
            else if (task.Status == TaskStatus.Canceled)
            {
                UserDialogs.Instance.InfoToast(MessageHelper.Cancelled);
                return true;
            }
            return false;
        }

        protected void TryExecute(Action action, Func<Exception, bool> onError)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                ReportCrash(exception);
                var handled = onError(exception);
                if (!handled)
                {
                    UserDialogs.Instance.ErrorToast(MessageHelper.ServerError);
                }
            }
        }

        protected void TryExecute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                ReportCrash(exception);
                UserDialogs.Instance.ErrorToast(MessageHelper.ServerError);
            }
        }

        IProgressDialog _busy;
        protected void ShowBusy(string message = "Logging In...")
        {
            if (_busy == null)
            {
                _busy = UserDialogs.Instance.Loading(message);
            }
            else if (!_busy.IsShowing)
            {
                _busy.Show();
            }
        }
        protected void HideBusy()
        {
            if (_busy != null)
            {
                _busy.Hide();
            }
        }

        async Task<TokenModel> SignInTask(SignInModel payload)
        {
            var userService = DependencyService.Get<ILoginService>();
            var result = await userService.SignIn(payload);
            if (result.Success == true)
            {
                App.SetAuth(result);
                var json = JsonConvert.SerializeObject(result);
                var service = DependencyService.Get<ILoginService>();
                await service.SaveUserData(json);
                await service.SaveAppartment(ApartmentName.Text.Trim());
                var MainPage = new RootPage();
                await Navigation.PushModalAsync(MainPage);
                MessageHelper.ShowToast(ToastNotificationType.Success, MessageHelper.LoggedSucess);
            }
            else
            {
                MessageHelper.ShowToast(ToastNotificationType.Error, result.ErrorMessage);
            }

            return result;
        }

        private void ApartmentName_OnFocused(object sender, FocusEventArgs e)
        {
            ApartmentName.IsVisible = false;
            apartmentSearch.IsVisible = true;
        }

        private void Apartment_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var tappedItem = (ApartmentModel)e.SelectedItem;
            if (tappedItem.Name != null)
                viewModel.ApartmentName = tappedItem.Name;
            viewModel.FrameVisibility = false;
            viewModel.EntryVisibility = true; 
            viewModel.SearchBarVisibility = false;
            ((ListView)sender).SelectedItem = null;
        }

        private void SearchAndEntryVisibility(object sender, FocusEventArgs e)
        {
            viewModel.SearchBarVisibility = false;
            viewModel.EntryVisibility = true;
        }
        protected override bool OnBackButtonPressed()
        {

            base.OnBackButtonPressed();
            return false;
        }
    }
}
