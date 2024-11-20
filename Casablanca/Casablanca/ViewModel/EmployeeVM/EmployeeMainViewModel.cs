using Casablanca.View.UserView;
using Casablanca.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Casablanca.Model;
using FontAwesome.Sharp;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;

namespace Casablanca.ViewModel.EmployeeVM
{
    public class EmployeeMainViewModel : ViewModelBase
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

        public ICommand LogOutCommand
        {
            get;
        }

        public ICommand ShowCustomerViewCommand
        {
            get;
        }

        public ICommand ShowArticleViewCommand
        {
            get;
        }

        public ICommand ShowNewRentalView
        {
            get;
        }



        public EmployeeMainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccount();

            LogOutCommand = new ViewModelCommand(ExecuteLogOutCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomersCommand);
            ShowArticleViewCommand = new ViewModelCommand(ExecuteShowArticleViewCommand);
            ShowNewRentalView = new ViewModelCommand(ExecuteShowNewRentalView);

            // default
            ExecuteShowArticleViewCommand(null);
            LoadCurrentUserData();

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


        public void ExecuteShowCustomersCommand(object? obj)
        {
            CurrentChildView = new CustomersViewModel(this);
            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["customers"] as string;
            if (name != null)
                Caption = name;
            Icon = IconChar.Users;
        }

        public void ExecuteShowArticleViewCommand(object? obj)
        {
            CurrentChildView = new ArticlesEmployeeViewModel();
            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["articles"] as string;
            if (name != null)
                Caption = name;
            Icon = IconChar.CompactDisc;
        }

        public void ExecuteShowNewRentalView(object? obj)
        {

            CurrentChildView = new NewRentalViewModel();
            ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
            string? name = dictionary["newRental"] as string;
            if (name != null)
                Caption = name;
            Icon = IconChar.TruckRampBox;
        }

        protected void ExecuteLogOutCommand(object? obj)
        {
            Thread.CurrentPrincipal = null;
            var culture = new CultureInfo("en-EN");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            foreach (Window window in Application.Current.Windows)
            {
                if (window is EmployeeMainView)
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
