using NewsApp.Navigation;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class ArticlePageDatailsViewModel
    {
        private readonly IArticleStore _articleStore;
        private readonly IPageService _pageService;
        public ICommand OpenBrowser { get; set; }
        public ArticleViewModel Article { get; set; }
        public ArticlePageDatailsViewModel(ArticleViewModel viewModel, IArticleStore articleStore, IPageService pageService)
        {   
            if(viewModel!=null)
            {
                _articleStore = articleStore;
                _pageService = pageService;
                Article = viewModel;
                OpenBrowser = new Command(() => { RunBrowser(); });

            }
        }
        public async void RunBrowser()
        {
            if (!string.IsNullOrWhiteSpace(Article?.Url))
                Device.OpenUri(new Uri(Article.Url));

            else
            {
                await _pageService.DisplayAlert("Error", "Url is not established", "ok");
            }
               
                  
        }
    }
}
