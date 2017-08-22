using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using RawPractice.Droid.CustomRenderers;
using RawPractice.Controls;
using Android.Graphics;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace RawPractice.Droid.CustomRenderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (!string.IsNullOrEmpty(e.NewElement?.StyleId)) {
                var font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, e.NewElement.StyleId+".otf");
                Control.Typeface = font;
                Control.SetMaxLines(2);
            }
        }
    }
}