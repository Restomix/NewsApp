using NewsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace NewsApp
{
    public class ArticleViewModel : BaseModel
    {
        public ICommand OpenBrowser{ get; }
        private Article article;

        public ArticleViewModel()
        {
            article = new Article();
            OpenBrowser = new OpenBrowserCommand(this);
        }

        public string Title
        {
            get { return article.Title; }
            set
            {
                if (article.Title != value)
                {
                    article.Title = value;
                    OnPropertyChanged("title");
                }
            }
        }
        public string Content
        {
            get { return article.Content; }
            set
            {
                if (article.Content != value)
                {
                    article.Content = value;
                    OnPropertyChanged("content");
                }
            }
        }
        public string Url
        {
            get { return article.Url; }
            set
            {
                if (article.Url != value)
                {
                    article.Url = value;
                    OnPropertyChanged("url");
                }
            }
        }
        public string UrlToImage
        {
            get { return article.UrlToImage; }
            set
            {
                if (article.UrlToImage != value)
                {
                    article.UrlToImage = value;
                    OnPropertyChanged("urlToImage");
                }
            }
        }
        public string Author
        {
            get { return article.Author; }
            set
            {
                if (article.Author != value)
                {
                    article.Author = value;
                    OnPropertyChanged("author");
                }
            }
        }
        public string Description
        {
            get { return article.Description; }
            set
            {
                if (article.Description != value)
                {
                    article.Description = value;
                    OnPropertyChanged("description");
                }
            }
        }
        public string PublishedAt
        {
            get { return article.PublishedAt?.ToString("dd MMM yyyy hh:mm"); }
            set
            {
                if (article?.PublishedAt != DateTime.Parse(value))
                {
                    article.PublishedAt = DateTime.Parse(value);
                    OnPropertyChanged("publishedAt");
                }
            }
        }
    }
}
