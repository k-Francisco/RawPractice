using RawPractice.Model;
using RawPractice.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RawPractice.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscoverPage : ContentPage
    {
        public DiscoverPage()
        {
            
            InitializeComponent();
            BindingContext = new DiscoverPageViewModel();
            
           
        }
    }
}