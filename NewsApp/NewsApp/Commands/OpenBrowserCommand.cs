using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsApp
{
    class OpenBrowserCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        ArticleViewModel viewModel;
        public OpenBrowserCommand(ArticleViewModel vm)
        {
            viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return viewModel?.Url != null;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                Device.OpenUri(new Uri(viewModel.Url));
                
        }
    }
}
