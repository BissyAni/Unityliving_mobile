using System.Collections.Generic;
using Unity.Living.App.Portable.Helpers;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Views.Menu
{
    public partial class MenuPage : ContentPage
    {
        RootPage root;
        List<HomeMenuItem> menuItems;
        public MenuPage(RootPage root)
        {
            this.root = root;
            InitializeComponent();
            if (!App.IsWindows10)
            {
                BackgroundColor = Color.FromHex("#0288d1");
                ListViewMenu.BackgroundColor = Color.FromHex("#0288d1");
            }
            BindingContext = new ViewModelBase
            {
                Title = MessageHelper.UnityLiving,
                Subtitle = MessageHelper.UnityLiving,
                Icon = "slideout.png"
            };

            ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
                {
                    new HomeMenuItem { Title = "Overview", MenuType = MenuType.Overview, Icon ="overview.png" },
                    new HomeMenuItem { Title = "Service Request", MenuType = MenuType.ServiceRequestView, Icon = "servicerequest1.png" },
                    new HomeMenuItem { Title = "Profile", MenuType = MenuType.Profile, Icon ="profile1.png" },
                    new HomeMenuItem { Title = "About", MenuType = MenuType.About, Icon ="about1.png" },
                    new HomeMenuItem { Title = "Key Personnel", MenuType = MenuType.KeyPersonnel, Icon ="keypersonal.png" },
                    new HomeMenuItem { Title = "Documents", MenuType = MenuType.Documents, Icon ="documents.png" },
                    new HomeMenuItem { Title = "Events", MenuType = MenuType.Events, Icon ="events1.png" },
                    new HomeMenuItem { Title = "Album", MenuType = MenuType.Album, Icon ="album1.png" },
                    new HomeMenuItem { Title = "Sale & Rent", MenuType = MenuType.SaleAndRent, Icon ="salerent.png" },
                    new HomeMenuItem { Title = "Poll", MenuType = MenuType.Poll, Icon ="poll1.png" },
                    new HomeMenuItem { Title = "E-Vote", MenuType = MenuType.EVote, Icon ="evote1.png" },
                    new HomeMenuItem { Title = "Discussions", MenuType = MenuType.Discussions, Icon ="disscussions1.png" },
                    new HomeMenuItem { Title = "Income Report", MenuType = MenuType.Reports, Icon ="incomereport1.png" },
                    new HomeMenuItem { Title = "Financial Year Settings", MenuType = MenuType.Settings, Icon ="fyearsettings.png" },
                    new HomeMenuItem { Title = "Support", MenuType = MenuType.Help, Icon ="support1.png" },
                    new HomeMenuItem { Title = "LogOut", MenuType = MenuType.Logout, Icon = "logout1.png" }
            };
            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
                {
                    if (ListViewMenu.SelectedItem == null)
                        return;
                    await this.root.NavigateAsync(((HomeMenuItem)e.SelectedItem).MenuType);
                    ListViewMenu.SelectedItem = null;
                };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.AuthKey != null)
            {
                loggedUsername.Text = App.AuthKey.UserDetails.Name;
                loggedUserEmail.Text = App.AuthKey.UserDetails.Email;
            }
        }
    }
}

