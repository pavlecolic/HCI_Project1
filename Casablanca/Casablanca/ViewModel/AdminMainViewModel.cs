using Casablanca.Model;
using Casablanca.Model.Repository;
using Casablanca.Repository;
using Casablanca.View;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Casablanca.ViewModel
{
    class AdminMainViewModel : ViewModelBase
    {
        private UserAccount _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        public UserAccount CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChange(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChange(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChange(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChange(nameof(Icon));
            }
        }

        // Commands
        public ICommand ShowEmployeeViewCommand
        {
            get;
        }

        public ICommand ShowArticleViewCommand
        {
            get;
        }


        public AdminMainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccount();

            //Initialie commands
            ShowEmployeeViewCommand = new ViewModelCommand(ExecuteShowEmployeesViewCommand);
            ShowArticleViewCommand = new ViewModelCommand(ExecuteShowArticlesViewCommand);

            //Default View
            ExecuteShowEmployeesViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowArticlesViewCommand(object? obj)
        {
            CurrentChildView = new ArticlesViewModel();
            Caption = "Articles";
            Icon = IconChar.CompactDisc;
        }

        private void ExecuteShowEmployeesViewCommand(object? obj)
        {
            CurrentChildView = new EmployeesViewModel();
            Caption = "Employees";
            Icon = IconChar.Users;
        }


        private void LoadCurrentUserData()
        {
            User user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.username;
                CurrentUserAccount.DisplayName = $"{user.firstName} {user.lastName}";
            } 

        }
    }
}
