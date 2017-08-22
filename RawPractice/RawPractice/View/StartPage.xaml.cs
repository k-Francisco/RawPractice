using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RawPractice.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : TabbedPage
    {
        public StartPage()
        {
            InitializeComponent();
            this.Title = this.CurrentPage.AutomationId;
            
            this.CurrentPageChanged += (sender, e) =>
            {
                this.Title = this.CurrentPage.AutomationId;
            };
        }
    }
}