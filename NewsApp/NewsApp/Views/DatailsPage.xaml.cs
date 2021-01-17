﻿using NewsApp.Navigation;
using NewsApp.Service;
using NewsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DatailsPage : ContentPage
    {
       
        private ArticleViewModel Article { get; set; }
        public DatailsPage(ArticleViewModel article)
		{
			InitializeComponent();
            Article = article;
            var pageService = new PageService();
            var articleStore = new GetRequestApi();
            this.BindingContext = new ArticlePageDatailsViewModel(article, articleStore, pageService);
        }
        
        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}