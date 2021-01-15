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
        public Task<string> downloading = null;
        public MainPage()
        {
            InitializeComponent();
            StartApp();
        }
        public void StartApp(string keyword = "")
        {

            if (downloading?.IsCompleted == true || downloading == null)
            {

                loadingLable.IsVisible = true;
                loadingLable.Text = "Loading...";
                Stack.Children.Clear();

                downloading = new WebClient().DownloadStringTaskAsync(Helper.GetNewsApiUri(keyword));
                downloading.ContinueWith(x =>
                {
                    try
                    {
                        var json = x.Result;
                        Device.BeginInvokeOnMainThread(() =>
                        {

                            DbArticles articles = JsonConvert.DeserializeObject<DbArticles>(json);
                            foreach (var item in articles.Articles)
                            {
                                Stack.Children.Add(new CardView(item));
                            }
                            loadingLable.IsVisible = false;

                        });
                    }
                    catch (Exception ex)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            if (ex.InnerException is System.Net.WebException)
                            {

                                loadingLable.Text = "Проблема подключения к серверу!";
                            }
                            else
                            {
                                loadingLable.Text = "Напишите нам подробно о проблеме novostragonlakos@gmail.com";
                            }
                        });
                    }

                });
            }



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

            var searchBar = sender as SearchBar;

            if ((string.IsNullOrWhiteSpace(searchBar.Text) || searchBar.Text.Length < 3) && e.OldTextValue?.Length >= 3)
            {
                StartApp();

            }
            else if (e?.NewTextValue?.Length >= 3)
            {

                StartApp(searchBar.Text);
            }

        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {

        }
    }
}
