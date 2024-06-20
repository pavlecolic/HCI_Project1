using Casablanca.Model.Repository;
using Casablanca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Casablanca.Utils;
using Casablanca.Model;
using System.Windows.Controls.Primitives;

namespace Casablanca.ViewModel
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private string _username;
        private string _firstName;
        private string _lastName;
        private SecureString _password;
        private SecureString _confirmPassword;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private string _salary;

        private IUserRepository userRepository;
        //Properties
        public string Username
        {
            get => _username; set
            {
                _username = value; OnPropertyChange(nameof(Username));
            }
        }

        public string FirstName
        {
            get => _firstName; set
            {
                _firstName = value; OnPropertyChange(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set

            {
                _lastName = value; OnPropertyChange(nameof(LastName));
            }
        }


        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChange(nameof(Password));
            }
        }
        public SecureString ConfirmPassword
        {
            get => _confirmPassword;

            set
            {
                _confirmPassword = value;
                OnPropertyChange(nameof(ConfirmPassword));
            }

        }

        public string ErrorMessage
        {
            get => _errorMessage; set
            {
                _errorMessage = value; OnPropertyChange(nameof(ErrorMessage));
            }
        }

        public string Salary
        {
            get => _salary;
            set
            {
                _salary = value; OnPropertyChange(nameof(Salary));
            }
        }

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value; OnPropertyChange(nameof(IsViewVisible));
            }
        }


        // Commands
        public ICommand? SaveCommand
        {
            get;
        }

        public ICommand? CancelCommand
        {
            get;
        }

        public ICommand? ShowPasswordCommand
        {
            get;
        }

        public Action CloseAction
        {
            get; set;
        }

        public AddEmployeeViewModel()
        {
            userRepository = new UserRepository();
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
        }


        private bool CanExecuteSaveCommand(object? obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3 ||  ConfirmPassword== null 
                || ConfirmPassword.Length  < 3 
                ||  !double.TryParse(Salary, out double salary))
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteSaveCommand(object? obj)
        {
            // provjera lozinki (matching)
            // ako su matching
            if (!SecureStringHelper.SecureStringsEqual(Password, ConfirmPassword))
            {
                ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
                ErrorMessage = dictionary["passwordsNotMatching"] as string;
            }
            else
            {
                double salary = double.Parse(Salary);
                User user = new User(Username, SecureStringHelper.ConvertToString(Password), FirstName, LastName, salary);
                var isValidUser = userRepository.Add(user);
                if (isValidUser)
                {
                    /*Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(Username), null);*/
                    RefreshEmployeeListEvent.RaiseRefreshRequest();
                    IsViewVisible = false;
                    CloseAction?.Invoke();
                }
                else
                {
                    ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
                    ErrorMessage = dictionary["usernameExists"] as string;
                }
            }
        }

        private void ExecuteCancelCommand(object? obj)
        {
            IsViewVisible = false;
            CloseAction?.Invoke();
        }
    }
}
