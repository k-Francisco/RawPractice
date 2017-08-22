using RawPractice.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawPractice.ViewModel
{
    public class DiscoverPageViewModel
    {
        //public List<BandModel> bandlist = new List<BandModel>() {
        //        new BandModel(){ imgSource = "icon.png", bandName="Maroon 5"},
        //        new BandModel(){ imgSource = "icon.png", bandName="Paramore"},
        //        new BandModel(){ imgSource = "icon.png", bandName="Panic at the Disco"},
        //        new BandModel(){ imgSource = "icon.png", bandName="Sleeping with the sirens"},
        //        new BandModel(){ imgSource = "icon.png", bandName="Up Dharma Down"},
        //        new BandModel(){ imgSource = "icon.png", bandName="Fall Out Boys"},
        //        new BandModel(){ imgSource = "icon.png", bandName="All Time Low"},
        //    };
        //public ObservableCollection<DiscoveryModel> discovery = new ObservableCollection<DiscoveryModel>() {};

        List<BandModel> bandlist = new List<BandModel>() {
                    new BandModel(){ imgSource = "icon.png", bandName="Maroon 5"},
                    new BandModel(){ imgSource = "icon.png", bandName="Paramore"},
                    new BandModel(){ imgSource = "icon.png", bandName="Panic at the Disco"},
                    new BandModel(){ imgSource = "icon.png", bandName="Sleeping with the sirens"},
                    new BandModel(){ imgSource = "icon.png", bandName="Up Dharma Down"},
                    new BandModel(){ imgSource = "icon.png", bandName="Fall Out Boys"},
                    new BandModel(){ imgSource = "icon.png", bandName="All Time Low"},
        };
        ObservableCollection<DiscoveryModel> discovery = new ObservableCollection<DiscoveryModel>();

        public List<BandModel> BandList {
            get { return bandlist; }
            set { bandlist = value; }
        }

        public ObservableCollection<DiscoveryModel> Discovery
        {
            get {
                if (!discovery.Any()) {
                    discovery.Add(new DiscoveryModel() { categoryName = "Trending", bandList = bandlist });
                    discovery.Add(new DiscoveryModel() { categoryName = "Most Favorite", bandList = bandlist });
                    discovery.Add(new DiscoveryModel() { categoryName = "Recommended", bandList = bandlist });
                    discovery.Add(new DiscoveryModel() { categoryName = "Rising Stars", bandList = bandlist });
                    discovery.Add(new DiscoveryModel() { categoryName = "Rockers", bandList = bandlist });
                    discovery.Add(new DiscoveryModel() { categoryName = "Show Bands", bandList = bandlist });
                    discovery.Add(new DiscoveryModel() { categoryName = "BisRock", bandList = bandlist });
                }
                return discovery;
            }
            set { discovery = value; }
        }

        
        
           
    }
}
