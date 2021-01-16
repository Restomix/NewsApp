using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Service
{
    public interface IArticleStore
    {
        Task<IEnumerable<Article>> GetArticlesAsync();
        Task<IEnumerable<Article>> SearchArticlesAsync(string key);
    }
}
