using FormsPlugin.Iconize;
using ImageCircle.Forms.Plugin.Abstractions;
using RawPractice.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RawPractice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


        //    var bluePage = new ContentPage()
        //    {
        //        AutomationId = "Discover",
        //        Icon = "ic_discover.png"
        //    };
        //    var yellowPage = new ContentPage()
        //    {
        //        AutomationId = "Favorites",
        //        Icon = "ic_favorites.png"
        //    };
        //    var redPage = new ContentPage()
        //    {
        //        AutomationId = "Notifications",
        //        Icon = "ic_notification.png"
        //    };
        //    var leaderboardPage = new ContentPage()
        //    {
        //        AutomationId = "Leaderboard",
        //        Icon = "ic_leaderboard.png"
        //    };

        //    // Tabbed page to hold tabs
        //    var tabbedPage = new TabbedPage()
        //    {
        //        Title = "Discover",
        //        BarTextColor = Color.Black,
        //        Children = {
        //    bluePage,
        //    yellowPage,
        //    redPage,
        //    leaderboardPage
        //}
        //    };

        //    tabbedPage.CurrentPageChanged += (sender, e) =>
        //    {
        //        // Hide the app's navbar for the yellow page
        //        //var shouldHaveNavigation = tabbedPage.CurrentPage != yellowPage;
        //        //NavigationPage.SetHasNavigationBar(tabbedPage, shouldHaveNavigation);

        //        // Set page title to copy active tab
        //        tabbedPage.Title = tabbedPage.CurrentPage.AutomationId;
                
        //    };


            var navPage = new NavigationPage(new RawPractice.View.StartPage());
            
            var search = new ToolbarItem { Text="Search", Icon= "ic_search.png"};
            var user = new ToolbarItem { Text = "User", Icon = ImageSource.FromFile("icon.png") as FileImageSource };
            navPage.ToolbarItems.Add(search);
            navPage.ToolbarItems.Add(user);
            navPage.BarTextColor = Color.FromHex("#2C3E50");
            
            MainPage = navPage;

            //MainPage = new RawPractice.View.StartPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
