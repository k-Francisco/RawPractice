using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RawPractice.Controls
{
    public class TLScrollView : ScrollView
    {
        public static readonly BindableProperty ItemSourceProperty =
            BindableProperty.Create("ItemSource", typeof(IEnumerable), typeof(TLScrollView), default(IEnumerable));

        public IEnumerable ItemSource
        {
            get { return (IEnumerable)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(TLScrollView), default(DataTemplate));

        public DataTemplate ItemTemplate {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public void Render() {
            if (this.ItemTemplate == null || this.ItemSource == null)
                return;

            var layout = new StackLayout();
            layout.Orientation = this.Orientation == ScrollOrientation.Vertical ? StackOrientation.Vertical : StackOrientation.Horizontal;

            foreach (var item in this.ItemSource) {
                var viewCell = this.ItemTemplate.CreateContent() as ViewCell;
                viewCell.View.BindingContext = item;
                layout.Children.Add(viewCell.View);
            }

            this.Content = layout;
        }
    }
}
