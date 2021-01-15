using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Models
{
    public class DbArticles
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
    }
}
