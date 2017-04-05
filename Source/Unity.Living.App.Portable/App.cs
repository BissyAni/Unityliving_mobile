using Xamarin.Forms;
using Unity.Living.App.Portable.Views;
using Unity.Living.App.Portable.Utils;
using Unity.Living.App.Portable.Models;
using Newtonsoft.Json;
using Unity.Living.App.Portable.Interface;
using Unity.Living.App.Portable.Views.Login;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Unity.Living.App.Portable
{
    public class App : Application
    {
        static TokenModel _authKey;
        public static TokenModel AuthKey
        {
            get
            {
                return _authKey;
            }
        }

        public static void SetAuth(TokenModel authKey)
        {
            _authKey = authKey;
        }

        static string _userName;
        private static bool _tokenExpired = false;

        public static string UserName
        {
            get
            {
                return _userName;
            }
        }

        public static void ClearToken()
        {
            _authKey = null;
        }

        public static bool TokenExpired
        {
            get { return _tokenExpired; }
            set
            {
                if (!_tokenExpired)
                {
                    ClearToken();
                }
                _tokenExpired = value; 
                
            }
        }

        public static string ServiceRequestDescription = string.Empty;
        public static int ServiceRequestId = 0;
        public static string ServiceRequestStatus = string.Empty;
        public static bool IsRequestFiltered = false;
        public static bool IsLoggedIn
        {
            get
            {
                return AuthKey != null;
            }
        }
        public static bool IsWindows10 { get; set; }
        public App()
        {
               
            var service = DependencyService.Get<ILoginService>();
            var dataUser = service.GetUserData();
            if (string.IsNullOrEmpty(dataUser))
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainPage = new RootPage();
                var casheValue = JsonConvert.DeserializeObject<TokenModel>(dataUser.ToString());
                App.SetAuth(casheValue);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
