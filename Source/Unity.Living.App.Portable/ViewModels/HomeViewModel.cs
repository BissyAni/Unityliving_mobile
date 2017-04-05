using System.Collections.ObjectModel;

namespace Unity.Living.App.Portable
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<HomeMenuItem> MenuItems { get; set; }
        public HomeViewModel()
        {
            CanLoadMore = true;
            Title = "UnityLiving";
            MenuItems = new ObservableCollection<HomeMenuItem>();
            MenuItems.Add(new HomeMenuItem
            {
                Id = 0,
                Title = "Overview",
                MenuType = MenuType.Overview,
                Icon = "about.png"
            });
            MenuItems.Add(new HomeMenuItem
            {
                Id = 1,
                Title = "ServiceRequest",
                MenuType = MenuType.ServiceRequestView,
                Icon = "blog.png"
            });
        }

    }
}

