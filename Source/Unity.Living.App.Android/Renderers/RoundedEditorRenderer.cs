using Android.Views;
using Xamarin.Forms;
using Unity.Living.App.Portable.Controls;
using Unity.Living.AppAndroid.Renderers;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(RoundedEditor), typeof(RoundedEditorRenderer))]
namespace Unity.Living.AppAndroid.Renderers
{
    public class RoundedEditorRenderer : EditorRenderer
    {
        #region Private fields and properties

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        #endregion

        #region Parent override

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;
            Control.Gravity = DefaultGravity;
            var RoundedEditor = Element as RoundedEditor;
            UpdateBackground(RoundedEditor);
            UpdatePadding(RoundedEditor);
            UpdateTextAlighnment(RoundedEditor);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null)
                return;
            var RoundedEditor = Element as RoundedEditor;
            if (e.PropertyName == RoundedEditor.BorderWidthProperty.PropertyName ||
                e.PropertyName == RoundedEditor.BorderColorProperty.PropertyName ||
                e.PropertyName == RoundedEditor.BorderRadiusProperty.PropertyName ||
                e.PropertyName == RoundedEditor.BackgroundColorProperty.PropertyName)
            {
                UpdateBackground(RoundedEditor);
            }
            else if (e.PropertyName == RoundedEditor.LeftPaddingProperty.PropertyName ||
                e.PropertyName == RoundedEditor.RightPaddingProperty.PropertyName)
            {
                UpdatePadding(RoundedEditor);
            }
            else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
            {
                UpdateTextAlighnment(RoundedEditor);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_renderer != null)
                {
                    _renderer.Dispose();
                    _renderer = null;
                }
            }
        }

        #endregion

        #region Utility methods

        private void UpdateBackground(RoundedEditor RoundedEditor)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(RoundedEditor.BorderColor, RoundedEditor.BackgroundColor, RoundedEditor.BorderWidth, RoundedEditor.BorderRadius);
        }

        private void UpdatePadding(RoundedEditor RoundedEditor)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(RoundedEditor.LeftPadding), 0,
                (int)Forms.Context.ToPixels(RoundedEditor.RightPadding), 0);
        }

        private void UpdateTextAlighnment(RoundedEditor RoundedEditor)
        {
            var gravity = DefaultGravity;
            Control.Gravity = gravity;
        }

        #endregion
    }
}