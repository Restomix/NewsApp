
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardView : ContentView
	{   
        private ArticleViewModel Article { get; set; }
		public CardView(ArticleViewModel article)
		{
			InitializeComponent();
            Article = article;
            BindingContext = Article;
           
           /* if (Helper.IsUrlValid(Article.UrlToImage))
            {
                this.Image.Source = new UriImageSource() { Uri = new Uri(Article.UrlToImage) };
            }*/
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            App.Current.MainPage.Navigation.PushAsync(new DatailsPage(Article),true);
           

        }

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new DatailsPage(Article), true);
        }

        private void ClickGestureRecognizer_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new DatailsPage(Article), true);
        }
    }
}