using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Utils;
using Mysqlx.Datatypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Casablanca.ViewModel
{
    public class SettingsViewModel :ViewModelBase
    {

        private string _username;
        private SecureString _password;
        private SecureString _confirmPassword;
        private string _errorMessage;
        private string _firstName;
        private string _lastName;


        public string ErrorMessage
        {
            get => _errorMessage;

            set
            {
                _errorMessage = value;
                OnPropertyChange(nameof(ErrorMessage));
            }
        }


        private IUserRepository UserRepository;

        public ICommand? SaveCommand
        {
            get;
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value; OnPropertyChange(nameof(Username));
            }
        }

        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value; OnPropertyChange(nameof(Password));
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


        public ICommand? ShowPasswordCommand
        {
            get;
        }


        public string FirstName
        {
            get => _firstName;
            set
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


        public SettingsViewModel()
        {
            UserRepository = new UserRepository();
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand);
            LoadUserData();

        }

        private void LoadUserData()
        {
            User user = UserRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {
                Username = user.username;
                FirstName = user.firstName;
                LastName = user.lastName;
                
            }
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
                if (!UserRepository.UsernameExists(Username))
                {
                    User admin = UserRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

                    admin.username = Username;
                    admin.password = SecureStringHelper.ConvertToString(Password);
                    admin.firstName = FirstName;
                    admin.lastName = LastName;
                    User user = new User(admin.Id, admin.username, admin.password, admin.firstName, admin.lastName, admin.theme ?? "li", admin.language ?? "en", admin.salary ?? 0.0, true);
                    UserRepository.Edit(user);
                    // valid!

                }
                else
                {
                    ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
                    ErrorMessage = dictionary["usernameExists"] as string;
                }
            }
        }

    }
}
