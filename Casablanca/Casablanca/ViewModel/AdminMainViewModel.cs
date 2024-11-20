using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.View;
using Casablanca.View.UserView;
using FontAwesome.Sharp;
using System;
using System.Globalization;
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

        public ICommand ShowCitiesViewCommand
        {
            get;
        }

        public ICommand ShowArticleTypeViewCommand
        {
            get;
        }

        public ICommand ShowSettingsViewCommand
        {
            get;
        }

        public ICommand LogOutCommand
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
            ShowCitiesViewCommand = new ViewModelCommand(ExecuteShowCitiesViewCommand);
            ShowArticleTypeViewCommand = new ViewModelCommand(ExecuteShowArticleTypeViewCommand);
            ShowSettingsViewCommand = new ViewModelCommand(ExecuteShowSettingsViewCommand);

            LogOutCommand = new ViewModelCommand(ExecuteLogOutCommand);

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

        private void ExecuteShowCitiesViewCommand(object? obj)
        {
            CurrentChildView = new CitiesViewModel();

            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["cities"] as string;
            if(name != null)
            {
                Caption = name;
            }
            Icon = IconChar.City;
        }

        private void ExecuteShowArticleTypeViewCommand(object? obj)
        {
            CurrentChildView = new ArticleTypeViewModel();

            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["articleTypes"] as string;
            if (name != null)
            {
                Caption = name;
            }
            Icon = IconChar.City;
        }

        private void ExecuteShowSettingsViewCommand(object? obj)
        {
            CurrentChildView = new SettingsViewModel();

            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["settings"] as string;
            if (name != null)
            {
                Caption = name;
            }
            Icon = IconChar.Gears;
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

        protected void ExecuteLogOutCommand(object? obj)
        {


            Thread.CurrentPrincipal = null;
            var culture = new CultureInfo("en-EN");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            foreach(Window window in Application.Current.Windows)
            {
                if(window is AdminMainView)
                    window.Close();
            }

            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    if (Thread.CurrentPrincipal.IsInRole("Admin"))
                    {
                        var adminMainView = new AdminMainView();
                        adminMainView.Show();
                    }
                    else if (Thread.CurrentPrincipal.IsInRole("User"))
                    {
                        var employeeMainView = new EmployeeMainView();
                        employeeMainView.Show();
                    }
                }
            };
        }
    }
}
