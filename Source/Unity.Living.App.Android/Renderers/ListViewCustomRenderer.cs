
using Unity.Living.App.Portable.Controls;
using Unity.Living.AppAndroid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomListView), typeof(ListViewCustomRenderer))]
namespace Unity.Living.AppAndroid.Renderers
{
    public class ListViewCustomRenderer: ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var listView = this.Control as Android.Widget.ListView;
                listView.NestedScrollingEnabled = true;
            }
        }
    }
}