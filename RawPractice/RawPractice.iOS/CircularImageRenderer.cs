using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System.ComponentModel;


//[assembly: ExportRenderer(typeof(CircularImage), typeof(CircularImageRenderer))]
namespace RawPractice.iOS
{
    public class CircularImageRenderer : ImageRenderer
    {
        private void DrawCircle() {
            double min = Math.Min(Element.Width, Element.Height);
            Control.Layer.CornerRadius = (float)(min / 2.0);
            Control.Layer.MasksToBounds = false;
            Control.Layer.BorderColor = Color.White.ToCGColor();
            Control.Layer.BorderWidth = 3;
            Control.ClipsToBounds = true;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            DrawCircle();

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName || e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                DrawCircle();
            }
        }

    }

}