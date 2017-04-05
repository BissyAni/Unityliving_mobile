
using Android.Text;
using Android.Widget;
using Unity.Living.App.Portable.Controls;
using Unity.Living.AppAndroid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using G = Android.Graphics;
[assembly: ExportRenderer(typeof(CustomSearchbar), typeof(CustomSearchBarRenderer))]
namespace Unity.Living.AppAndroid.Renderers
{

   public class CustomSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(G.Color.Rgb(255, 255, 255));
            }
            SearchView searchView = (Control as SearchView);
            searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);

            int textViewId = searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
            EditText textView = (searchView.FindViewById(textViewId) as EditText);
            // Set custom colors
            textView.SetBackgroundColor(G.Color.Rgb(255, 255, 255));
            textView.SetTextColor(G.Color.Rgb(0,0,0));
            textView.SetHintTextColor(G.Color.Rgb(128, 128, 128));

            // Customize frame color
            int frameId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
            Android.Views.View frameView = (searchView.FindViewById(frameId) as Android.Views.View);
            frameView.SetBackgroundColor(G.Color.Rgb(255, 255, 255));

        }
    }
}
