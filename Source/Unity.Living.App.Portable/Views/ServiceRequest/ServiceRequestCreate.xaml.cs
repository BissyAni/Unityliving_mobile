using Plugin.Toasts;
using System;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using Unity.Living.App.Portable.Helpers;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Service;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.ServiceRequest
{
    public partial class ServiceRequestCreate : BaseContentPage
    {
        ServiceRequestService _serviceRequestService;
        public ServiceRequestCreate()
        {
            InitializeComponent();
            _serviceRequestService = new ServiceRequestService();
        }

        protected override async void OnAppearing()
        {
            try
            {
                ShowBusy(MessageHelper.Loading);
                var service = DependencyService.Get<IServiceRequest>();
                var houseandcategory = await Task.Run(() => service.GetAllDropDown()) ;
                if (houseandcategory != null)
                {
                    foreach (var item in houseandcategory.Categories)
                    {
                        Category.Items.Add(item.Name);
                    }
                    foreach (var houseitem1 in houseandcategory.Houses)
                    {
                        HouseCategory.Items.Add(houseitem1.DoorNumber.ToString());
                    }
                    foreach (var timeitem1 in houseandcategory.PreferredTimings)
                    {
                        PreferredTimingsCategory.Items.Add(timeitem1.Timings.ToString());
                    }
                }
                base.OnAppearing();
            }
            catch (Exception)
            {
                if (!CrossConnectivity.Current.IsConnected)
                    UserDialogs.Instance.ErrorToast(MessageHelper.NoInternet);
            }
            finally
            {
                HideBusy();
            }
        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            IfConnected(async () =>
            {
                ShowBusy(MessageHelper.Saving);
                if (subject.Text == "")
                    DisplayAlert(MessageHelper.EnterSubject, "", "OK");
                else if (HouseCategory.SelectedIndex == -1)
                    DisplayAlert(MessageHelper.EnterHouse, "", "OK");
                else if (Category.SelectedIndex == -1)
                    DisplayAlert(MessageHelper.EnterCategory, "", "OK");
                else if (noteArea.Text == "" || noteArea.Text == null)
                    DisplayAlert(MessageHelper.EnterDescription, "", "OK");
                else if (PreferredTimingsCategory.SelectedIndex == -1)
                    DisplayAlert(MessageHelper.EnterPreferredTiming, "", "OK");
                else
                {
                    ShowBusy(MessageHelper.Loading);
                    var service = DependencyService.Get<IServiceRequest>();
                    var houseandcategory = await service.GetAllDropDown();
                    var houseValue = (HouseCategory.Items[HouseCategory.SelectedIndex]);
                    var categoryValue = Category.Items[Category.SelectedIndex];
                    var timingValue = PreferredTimingsCategory.Items[PreferredTimingsCategory.SelectedIndex];
                    Models.ServiceRequest ser = new Models.ServiceRequest();
                    ser.Subject = subject.Text;
                    var houseCat = houseandcategory.Houses.FirstOrDefault(i => i.DoorNumber == houseValue);
                    if (houseCat != null)
                        ser.House = (houseCat.Id);
                    var CategoryData = houseandcategory.Categories.FirstOrDefault(i => i.Name == categoryValue);
                    if (CategoryData != null)
                        ser.Category = (CategoryData.Id);
                    var timingData = houseandcategory.PreferredTimings.FirstOrDefault(i => i.Timings == timingValue);
                    if (timingData != null)
                        ser.PreferredTimings = (timingData.Id);
                    var dd = DatePicker.Date;
                    ser.PreferredDate = dd.ToString("yyyy-MM-dd");
                    ser.Content = noteArea.Text;
                    var result = await _serviceRequestService.ServiceRequestCreate(ser);
                    HideBusy();
                    if (result)
                    {
                        HideBusy();
                        MessageHelper.ShowToast(ToastNotificationType.Success, "Success");
                        Navigation.PopAsync();
                    }
                    else
                    {
                        HideBusy();
                        MessageHelper.ShowToast(ToastNotificationType.Error, "Failure");
                    }
                }
                HideBusy();
            });
        }
    }
}
