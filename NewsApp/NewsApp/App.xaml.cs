using NewsApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NewsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginingPage());
            
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
    public static class Helper
    {
        public static bool IsUrlValid(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) { return false; }
            return true;

        }
        public static Uri GetNewsApiUri(string keyword="")
        {
            if (keyword?.Length >= 3)
            {
                return new Uri("http://newsapi.org/v2/everything?q=" + keyword + "&from=2021-01-01&to=2021-01-06&sortBy=popularity&apiKey=876fb0c5266a47b8a28930e0f5c0e7ae");
            }
            return new Uri("http://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=876fb0c5266a47b8a28930e0f5c0e7ae");
        }
    }

}
