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
        //private Task<string> DownloadingArticles = null;
        //as working with SQlight
        public GetRequestApi()
        {
           
        }
        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            Uri searchUri = new Uri(Constants.BaseUri + string.Format(Constants.Articles, Constants.ApiKey));

            return await new WebClient().DownloadStringTaskAsync(searchUri).ContinueWith(x =>
            {
                var json = x.Result;
                DbArticles articles = JsonConvert.DeserializeObject<DbArticles>(json);
                return articles.Articles;
            });
        }

        public async Task<IEnumerable<Article>> SearchArticlesAsync(string key)
        {
            Uri searchUri = new Uri(Constants.BaseUri + string.Format(Constants.Search, key, "2021-01-10", "2021-01-16", Constants.ApiKey));

            return await new WebClient().DownloadStringTaskAsync(searchUri).ContinueWith(x =>
            {   
                var json = x.Result;
                DbArticles articles = JsonConvert.DeserializeObject<DbArticles>(json);
                return articles.Articles;
            });
           
        }
    }
}
