using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Unity.Living.App.Portable.Controls;
using Unity.Living.AppAndroid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BindablePicker), typeof(CustomPickerRenderer))]
namespace Unity.Living.AppAndroid.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement != null)
            {
                Control.TextSize = 14;
            }
        }
    }
}