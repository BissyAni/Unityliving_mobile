using Xamarin.Forms;

namespace Unity.Living.App.Portable.Controls
{
    public class AppNavigationPage :NavigationPage
    {
        public AppNavigationPage(Page root) : base(root)
        {
            Init();
        }

        public AppNavigationPage()
        {
            Init();
        }

        void Init()
        {
            BarBackgroundColor = Color.FromHex("#0288d1");
            BarTextColor = Color.White;
        }
    }
}

