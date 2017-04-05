using Xamarin.Forms;
using Unity.Living.App.Portable.Controls;
using Unity.Living.AppAndroid.Renderers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRenderer))]
namespace Unity.Living.AppAndroid.Renderers
{
    public class RoundedButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e); 

            if (e.NewElement != null)
            {

            }
            else if (e.OldElement != null)
            {

            }

            if (Control != null)
            {
                GradientDrawable gradientDrawable = new GradientDrawable();
                gradientDrawable.SetShape(ShapeType.Rectangle);
                gradientDrawable.SetColor(Element.BackgroundColor.ToAndroid());
                gradientDrawable.SetStroke(2, Element.BorderColor.ToAndroid());
                gradientDrawable.SetCornerRadius(2.0f);

                Control.SetBackground(gradientDrawable);
            }
        }
    }
}