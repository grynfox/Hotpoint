using AppUtility.Factory;
using AppUtility.Http;
using AppUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TheApp
{
    public partial class App : Application
    {
        public static HttpRequest TransportManager { get; set; }
        public static bool isLoggedIn { get; set; }

        public App()
        {
            InitializeComponent();
           
            TransportManager = RequestFactory.createHttp("http://169.254.80.80/");
            
            if(!isLoggedIn)
                MainPage = new NavigationPage(new TheApp.Views.MainPage());
            else
                MainPage = new NavigationPage(new TheApp.Views.CardapioPage());
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
