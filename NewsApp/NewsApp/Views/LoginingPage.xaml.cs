using NewsApp.Navigation;
using NewsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginingPage : ContentPage
	{   
		public LoginingPage ()
		{
			InitializeComponent ();
            var pageService = new PageService();
            this.BindingContext = new LoginingPageViewModel(new UserViewModel(new Models.User()), pageService);
           
		}
        public LoginingPageViewModel ViewModel
        {
            get { return BindingContext as LoginingPageViewModel; }
            set { BindingContext = value; }
        }

    }

}