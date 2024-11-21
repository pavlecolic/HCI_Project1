using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casablanca.Utils;
using System.Security;
using System.Windows.Input;
using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using System.Threading;

namespace Casablanca.ViewModel
{


    public class SecurityViewModel : ViewModelBase
    {
        private SecureString _currentPassword;
        private SecureString _newPassword;
        private SecureString _confirmNewPassword;

        private IUserRepository UserRepository = new UserRepository();

        public SecureString CurrentPassword
        {
            get => _currentPassword;
            set
            {
                _currentPassword = value;
                OnPropertyChange(nameof(CurrentPassword));
            }
        }

        public SecureString NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChange(nameof(NewPassword));
            }
        }
        public SecureString ConfirmNewPassword
        {
            get => _confirmNewPassword;

            set
            {
                _confirmNewPassword = value;
                OnPropertyChange(nameof(ConfirmNewPassword));
            }

        }

        public ICommand ChangePasswordCommand
        {
            get;
        }

        public SecurityViewModel()
        {
            ChangePasswordCommand = new RelayCommand(ChangePassword);
        }

        public ICommand? SaveCommand
        {
            get;
        }

        public ICommand? ShowPasswordCommand
        {
            get;
        }


        private void ChangePassword()
        {
            if (!ValidatePasswordChange())
            {
                System.Diagnostics.Debug.WriteLine("Password validation failed.");
                return;
            }

            User current = UserRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            current.password = ConvertToUnsecureString(NewPassword);
            System.Diagnostics.Debug.WriteLine(current);

            UserRepository.ChangePassword(current);
            System.Diagnostics.Debug.WriteLine("Password changed successfully.");
        }

        private bool ValidatePasswordChange()
        {
            var currentPassword = ConvertToUnsecureString(CurrentPassword);
            var newPassword = ConvertToUnsecureString(NewPassword);
            var confirmNewPassword = ConvertToUnsecureString(ConfirmNewPassword);

            User current = UserRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (current != null)
            {

                if (!current.password.Equals(currentPassword))
                {
                    System.Diagnostics.Debug.WriteLine("Incorrect current password.");
                    return false;
                }

                if (newPassword != confirmNewPassword)
                {
                    System.Diagnostics.Debug.WriteLine("New passwords do not match.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    System.Diagnostics.Debug.WriteLine("New password cannot be empty.");
                    return false;
                }

                return true;
            } return false;
        }

        private string ConvertToUnsecureString(SecureString secureString)
        {
            if (secureString == null) return string.Empty;

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

}
