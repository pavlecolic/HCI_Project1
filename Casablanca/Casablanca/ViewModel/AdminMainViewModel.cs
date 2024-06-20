using Casablanca.Model;
using Casablanca.Model.Repository;
using Casablanca.Repository;
using FontAwesome.Sharp;
using System;
using System.Threading;
using System.Windows;
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

        public ICommand ShowSupplierViewCommand
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
            ShowSupplierViewCommand = new ViewModelCommand(ExecuteShowSuppliersViewCommand);
            ShowArticleViewCommand = new ViewModelCommand(ExecuteShowArticlesViewCommand);

            //Default View
            ExecuteShowEmployeesViewCommand(null);

            LoadCurrentUserData();
        }

       

        private void ExecuteShowEmployeesViewCommand(object? obj)
        {
            CurrentChildView = new EmployeesViewModel();
            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["employees"] as string;
            if (name != null)
                Caption = name;
            Icon = IconChar.Users;
        }

        private void ExecuteShowSuppliersViewCommand(object? obj)
        {
            CurrentChildView = new SuppliersViewModel();
            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["suppliers"] as string;
            if (name != null)
                Caption = name;
            Icon = IconChar.TruckField;
        }

        private void ExecuteShowArticlesViewCommand(object? obj)
        {
            CurrentChildView = new ArticlesViewModel();

            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["articles"] as string;
            if (name != null)
                Caption = name;
            Icon = IconChar.CompactDisc;
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
