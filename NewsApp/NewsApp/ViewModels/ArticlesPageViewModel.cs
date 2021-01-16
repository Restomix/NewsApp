using NewsApp.Navigation;
using NewsApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class ArticlesPageViewModel: BaseModel
    {
        private ArticleViewModel _selectedArticle;
        private bool _isDataLoaded;
        public ObservableCollection<ArticleViewModel> Articles { get; private set; } = new ObservableCollection<ArticleViewModel>();
        public ICommand LoadArticlesCommand { get; private set; }
        public ICommand SelectArticleCommand { get; private set; }
        public ICommand SearchArticlesCommand { get; private set; }
        private IArticleStore _articleStore;
        private IPageService _pageService;

        public ArticlesPageViewModel(IArticleStore articleStore, IPageService pageService)
        {
            _articleStore = articleStore;
            _pageService = pageService;
            LoadArticlesCommand = new Command(async () => await LoadData());
            SelectArticleCommand = new Command<ArticleViewModel>(async x => await SelectArticle(x));
            SearchArticlesCommand = new Command(async x => await SearchArticles((string)x));
        }
        public ArticleViewModel SelectedArticle
        {
            get { return _selectedArticle; }
            set { SetValue(ref _selectedArticle, value); }
        }
        public async Task SearchArticles(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                var articles = await _articleStore.SearchArticlesAsync(key);
                Articles.Clear();
                foreach (var article in articles)
                    Articles.Add(new ArticleViewModel(article));
            }
            return;
        }
        private async Task LoadData()
        {
             if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var articles = await _articleStore.GetArticlesAsync();
            foreach (var article in articles)
                Articles.Add(new ArticleViewModel(article));
        }
        private async Task SelectArticle(ArticleViewModel article)
        {
            if(article == null )
            {
                return;
            }
            SelectedArticle = null;
            await _pageService.PushAsync(new DatailsPage(article));
        }


    }
}
