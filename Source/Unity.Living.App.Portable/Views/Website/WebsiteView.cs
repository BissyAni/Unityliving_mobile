using Xamarin.Forms;

namespace Unity.Living.App.Portable
{
    public class WebsiteView : BaseView
    {
        public WebsiteView(string site, string title)
        {
            Title = title;
            var webView = new WebView();
            webView.Source = new UrlWebViewSource
            {
                Url = site
            };
            Content = webView;
        }
    }
}

