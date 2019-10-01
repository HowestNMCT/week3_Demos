using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo2_NavigationPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage(); //setting the startup page

            //wrap the MainPage (contentpage) in a navigationpage
            MainPage = new NavigationPage(new MainPage());
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
