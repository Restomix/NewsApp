using NewsApp.Navigation;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NewsApp.ViewModels
{
    public class ArticlePageDatailsView
    {
        private readonly IArticleStore _articleStore;
        private readonly IPageService _pageService;
        public ICommand OpenBrowser { get; set; }
        public ArticleViewModel Article { get; set; }
        public ArticlePageDatailsView(ArticleViewModel viewModel, IArticleStore articleStore, IPageService pageService)
        {   
            if(viewModel!=null)
            {
                _articleStore = articleStore;
                _pageService = pageService;
                OpenBrowser = new OpenBrowserCommand(viewModel);
                Article = viewModel;
                
            }
        }
    }
}
