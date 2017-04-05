using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using Unity.Living.App.Portable.Controls;
using Unity.Living.App.Portable.Views.Home;
using Unity.Living.App.Portable.Views.Menu;
using Unity.Living.App.Portable.Views.ServiceRequest;
using Unity.Living.App.Portable.Views.User;
using Unity.Living.App.Portable.Views.Login;
using Unity.Living.App.Portable.Views.About;
using Unity.Living.App.Portable.Views.WebSite;

namespace Unity.Living.App.Portable.Views
{
    public class RootPage : MasterDetailPage
    {
        public static bool IsUWPDesktop { get; set; }
        Dictionary<MenuType, NavigationPage> Pages { get; set;} 
        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new ViewModelBase
                {
                    Title = "UnityLiving",
                    Icon = "slideout.png"
                };
            NavigateAsync(MenuType.Overview);
            InvalidateMeasure();
        }

        public async Task NavigateAsync(MenuType id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuType.Overview:
                        Pages.Add(id, new AppNavigationPage(new Overview()));
                        break;
                    case MenuType.ServiceRequestView:
                            Pages.Add(id, new AppNavigationPage(new ServiceRequestView("","")));
                        break;
                    case MenuType.Profile:
                        Pages.Add(id, new AppNavigationPage(new ProfilePage()));
                        break;
                    case MenuType.Logout:
                        Pages.Add(id, new AppNavigationPage(new Logout()));
                        break;
                    case MenuType.About:
                        Pages.Add(id, new AppNavigationPage(new AboutPage()));
                        break;
                    case MenuType.KeyPersonnel:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Key Personnel", "http://d.unityliving.com/personnel/")));
                        break;
                    case MenuType.Documents:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Documents", "http://d.unityliving.com/user/document/list")));
                        break;
                    case MenuType.Events:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Events", "http://d.unityliving.com/event/list")));
                        break;
                    case MenuType.Album:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Album", "http://d.unityliving.com/album/")));
                        break;
                    case MenuType.SaleAndRent:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Sale & Rent", "http://d.unityliving.com/ad/list/")));
                        break;
                    case MenuType.Poll:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Poll", "http://d.unityliving.com/polls/")));
                        break;
                    case MenuType.EVote:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("E-Vote", "http://d.unityliving.com/votes/")));
                        break;
                    case MenuType.Discussions:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Discussions", "http://d.unityliving.com/forum/")));
                        break;
                    case MenuType.Reports:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Income", "http://d.unityliving.com/report/income")));
                        break;
                    case MenuType.Settings:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Financial Year", "http://d.unityliving.com/account/fy")));
                        break;
                    case MenuType.Help:
                        Pages.Add(id, new AppNavigationPage(new WebSiteView("Support", "http://d.unityliving.com/support/")));
                        break;
                }
            }
            newPage = Pages[id];
            if(newPage == null)
                return;
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }
            Detail = newPage;
            if (IsUWPDesktop)
                return;
            if(Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}

