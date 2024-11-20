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
using System.Windows;
using Casablanca.View;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Utils;
using Casablanca.View.UserView;

namespace Casablanca.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private bool _isAdminViewVisible = false;
        private bool _isEmployeeViewVisible = false;


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
                var userRole = userRepository.GetUserRole(Username);
               

                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), new[] {userRole});

                var themeUri = userRepository.GetUserTheme(Username);
               

                IsViewVisible = false;

                if (themeUri != null)
                {
                    AppTheme.ChangeTheme(themeUri);
                }

            }
            else
            {
                ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
                ErrorMessage = dictionary["badCredentialsMessage"] as string;
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

        private void ShowAdminView()
        {
            AdminMainView adminView = new AdminMainView();
            adminView.Show();
        }

        private void ShowUserView()
        {
            EmployeeMainView employeeView = new EmployeeMainView();
            employeeView.Show();

        }

    }


}
