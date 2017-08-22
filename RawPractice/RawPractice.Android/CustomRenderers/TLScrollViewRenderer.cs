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
using Xamarin.Forms.Platform.Android;
using RawPractice.Controls;
using Xamarin.Forms;
using RawPractice.Droid.CustomRenderers;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(TLScrollView), typeof(TLScrollViewRenderer))]
namespace RawPractice.Droid.CustomRenderers
{
    public class TLScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement as TLScrollView;
            element?.Render();

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;

                e.NewElement.PropertyChanged += OnElementPropertyChanged;

        }

        protected void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e) {
            this.HorizontalScrollBarEnabled = false;
            this.VerticalScrollBarEnabled = false;
        }

    }
}