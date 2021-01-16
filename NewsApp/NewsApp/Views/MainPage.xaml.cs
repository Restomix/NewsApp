using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
           
        }
        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            /* var searchBar = sender as SearchBar;
             searchBar.Unfocus();
             if (searchBar.Text.Length >= 3)
                 StartApp(searchBar.Text);
             if (string.IsNullOrWhiteSpace(searchBar.Text))
                 StartApp();*/
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {

        }
    }
}
