using NewsApp.Models;
using NewsApp.Navigation;
using NewsApp.Service;
using NewsApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ValidationsXFSample.Validators;
using ValidationsXFSample.Validators.Rules;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class LoginingPageViewModel : BaseModel
    {
        private LoginService _loginService { get; set; }
        private readonly IPageService _pageService;
        public IUser User { get; set; }
        public ICommand ValidateLogin { get; set; }
        public ICommand ValidatePassword { get; set; }
        public ICommand Login { get; set; }
        public ICommand LoginOut { get; set; }
        public ValidatableObject<string> Email { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> Password { get; set; } = new ValidatableObject<string>();
        private bool _onLoginAction;
        public bool LoginAction
        {
            get => _onLoginAction; 
            set => SetValue(ref _onLoginAction, value);
        }

        public LoginingPageViewModel()
        {
            //Model
            this.User = new Models.User();
            //Validation
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email required" });
            Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password required" });
            ///Service
            _loginService = new LoginService();
            this._pageService = new PageService();
            //Commands
            Login = new Command(async () => { await LoginActionTask(); });
            ValidateLogin = new Command(() => ValidateLoginMethod());
            ValidatePassword = new Command(() => ValidatePasswordMethod());

        }
        public void ValidateLoginMethod()
        {
            LoginAction = false;
            Email.Validate();
            OnPropertyChanged("Email");

        }
        public void ValidatePasswordMethod()
        {
            LoginAction = false;
            Password.Validate();
            OnPropertyChanged("Password");

        }
        public async Task LoginActionTask()
        {
            if (Password.IsValid && Email.IsValid)
            {
                User = new Models.User() { Password = Password.Value, Email = Email.Value };
                // var _user = await _loginService.GetUserByEmail(User.Email);
                await _loginService.GetUserByEmailAndPassword(User.Email, User.Password).ContinueWith(x =>
                {
                    if (x.Result != null)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            User.IsLoggedIn = true;
                            await _pageService.DisplayAlert(x.Result.Email, "Welcome", "Thank you", "Next");
                            await _pageService.PushAsync(new ArticleViewPage());
                        });

                        //_pageService.
                    }
                    else
                    {   //Reset
                        Password.Value = "";
                        Email.Value = "";
                        Password.IsValid = true;
                        Email.IsValid = true;
                        LoginAction = true;
                    }

                });

            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}
