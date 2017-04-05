using Xamarin.Forms;

namespace Unity.Living.App.Portable
{
    public class BaseView : ContentPage
    {
        public BaseView()
        {
            SetBinding(Page.TitleProperty, new Binding(ViewModelBase.TitlePropertyName));
            SetBinding(Page.IconProperty, new Binding(ViewModelBase.IconPropertyName));
        }
    }
}

