using Casablanca.Model;
using Casablanca.Model.Repository;
using Casablanca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;


namespace Casablanca.ViewModel
{
    class AdminMainViewModel : ViewModelBase
    {
        private UserAccount _currentUserAccount;
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

        public AdminMainViewModel()
        {
            userRepository = new UserRepository();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {

        }
    }
}
