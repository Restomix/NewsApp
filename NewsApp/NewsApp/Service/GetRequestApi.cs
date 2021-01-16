using NewsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Service
{
    public class GetRequestApi : IArticleStore
    {
        private Task<string> DownloadingArticles = null;
        public Uri GetApiUri { get; set; }
        //as working with SQlight
        public GetRequestApi()
        {
            
        }
        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            Uri searchUri = new Uri("http://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=876fb0c5266a47b8a28930e0f5c0e7ae");

            return await new WebClient().DownloadStringTaskAsync(searchUri).ContinueWith(x =>
            {
                var json = x.Result;
                DbArticles articles = JsonConvert.DeserializeObject<DbArticles>(json);
                return articles.Articles;
            });
        }

        public async Task<IEnumerable<Article>> SearchArticlesAsync(string key)
        {
            Uri searchUri = new Uri("http://newsapi.org/v2/everything?q=" 
            + key + 
            "&from=2021-01-01&to=2021-01-06&sortBy=popularity&apiKey=876fb0c5266a47b8a28930e0f5c0e7ae");

            DownloadingArticles = new WebClient().DownloadStringTaskAsync(searchUri);

            return await DownloadingArticles.ContinueWith(x =>
            {   
                var json = x.Result;
                DbArticles articles = JsonConvert.DeserializeObject<DbArticles>(json);
                return articles.Articles;
            });
           
        }
    }
}
