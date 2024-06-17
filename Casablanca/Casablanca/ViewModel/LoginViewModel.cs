using Casablanca.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Casablanca.Repository;
using System.Threading;
using System.Security.Principal;

namespace Casablanca.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;
        //Properties
        public string Username { get => _username; set { _username = value; OnPropertyChange(nameof(Username)); } }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChange(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChange(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChange(nameof(IsViewVisible)); } }

        // Commands
        public ICommand? LoginCommand { get; }
        public ICommand? ShowPasswordCommand { get; }
        public ICommand? RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        } 

        public void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }

        public bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            } else
            {
                validData = true;
            }
            return validData;
        }
    }


}
