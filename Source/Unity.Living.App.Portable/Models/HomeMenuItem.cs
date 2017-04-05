using System;

namespace Unity.Living.App.Portable
{
    public enum MenuType
    {
        Overview,
        ServiceRequestCreate,
        ServiceRequestView,
        ServiceRequestDetails,
        Profile,
        About,
        KeyPersonnel,
        Documents,
        Events,
        Album,
        SaleAndRent,
        Poll,
        EVote,
        Discussions,
        Reports,
        Settings,
        Help,
        Logout
    }
    public class HomeMenuItem : BaseModel
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.Overview;
        }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}

