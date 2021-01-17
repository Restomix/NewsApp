using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Service
{
    public static class Constants
    {   
        /// <summary>
        /// Base ApiKey +
        /// </summary>
        public const string BaseUri = "http://newsapi.org/v2/";
        /// <summary>
        /// Url for top news withot search + {0} is Api key
        /// </summary>
        public const string Articles = "top-headlines?country=us&category=business&apiKey={0}";
        /// <summary>
        /// Trial ApiKey for NewsApi has many constrains as is trial
        /// </summary>
        public const string ApiKey = "876fb0c5266a47b8a28930e0f5c0e7ae";
        /// <summary>
        /// The Uri string for a GetRequest, consist of
        /// 0 - search keyword, 1 - date from, 2 - date to, 3 - Api key, date fomat is "yyyy-mm-dd"
        /// </summary>
        public const string Search = "everything?q={0}&from={1}&to={2}&sortBy=popularity&apiKey={3}";

    }
    
}
