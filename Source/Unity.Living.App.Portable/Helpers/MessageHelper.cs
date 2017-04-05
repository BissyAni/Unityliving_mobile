using Plugin.Toasts;
using System;

namespace Unity.Living.App.Portable.Helpers
{
    public static class MessageHelper
    {
        public static string NoInternet = "Oops, Seems like there is no Internet :( ";
        public static string ServerError = "Oops, Something bad happened :( ";
        public static string TimeoutError = "Oops, Failed to load the data :( ";
        public static string AccountStatement = "Account statement of ";
        public static string LoggedSucess = "Logged in sucessfully";
        public static string UpdatedSucess = "Updated successfully";
        public static string EnterMessage = "Please enter a comment or message";
        public static string CommentSucess = "Comment added successfully";
        public static string PasswordChanged = "Password has been changed";
        public static string NoReceipt = "No receipt found";
        public static string SelectPaymentMode = "Please select a mode of payment";
        public static string EnterAmount = "Please enter an amount";
        public static string DuesAccount = "Dues account statement of ";
        public static string SelectItem = "Please select an item to intimate your payment status";
        public static string FillSettingAmount = "Please fill all setting amount";
        public static string Loading = "Loading...";
        public static string Saving = "Saving...";
        public static string LoggingIn = "Logging In...";
        public static string UnityLiving = "UnityLiving";
        public static string EnterSubject = "Please enter subject";
        public static string EnterHouse = "Please enter house";
        public static string EnterCategory = "Please select category";
        public static string EnterDescription = "Please enter description";
        public static string EnterPreferredTiming = "Please select preferred timing";
        public static string FillMandatory = "All fields are mandatory";
        public static string SelectCharge = "Select atleast one charge to settle";
        public static string EnterApartmentName = "Please enter apartment name";
        public static string EnterUserName = "Please enter userName";
        public static string EnterPassword = "Please enter password";
        public static string InvalidInput = "Invalid Input";
        public static string Cancelled = "Cancelled";

        public async static void ShowToast(ToastNotificationType type, string message)
        {
            var notificator = Xamarin.Forms.DependencyService.Get<IToastNotificator>();
            bool tapped = await notificator.Notify(type, type.ToString(), message, TimeSpan.FromSeconds(2));
        }
    }
}
