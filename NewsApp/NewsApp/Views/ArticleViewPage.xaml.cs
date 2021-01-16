using NewsApp.Navigation;
using NewsApp.Service;
using NewsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArticleViewPage : ContentPage
	{
		public ArticleViewPage ()
		{
			InitializeComponent ();
            var articleStore = new GetRequestApi();
            var pageService = new PageService();
            BindingContext = new ArticlesPageViewModel(articleStore, pageService);  
        }
        protected override void OnAppearing()
        {
            ViewModel.LoadArticlesCommand.Execute(null); 
            base.OnAppearing();
        }
        void OnArticleSelected(object sender, SelectedItemChangedEventArgs e)
        {
           // ViewModel.SelectArticleCommand.Execute(e.SelectedItem);
        }
        public ArticlesPageViewModel ViewModel
        {
            get { return BindingContext as ArticlesPageViewModel; }
            set { BindingContext = value; }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {   
            ViewModel.SearchArticlesCommand.Execute(e.NewTextValue);
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.SelectArticleCommand.Execute(e.Item);
        }
    }
}