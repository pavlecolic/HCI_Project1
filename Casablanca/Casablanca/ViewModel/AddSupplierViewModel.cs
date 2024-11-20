using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Utils;
using Mysqlx.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Casablanca.ViewModel
{
    class AddSupplierViewModel : ViewModelBase
    {
        private string _supplierName;
        private string _supplierContact;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private ISupplierRepository supplierRepository;


        public string SupplierName
        {
            get => _supplierName;
            set
            {
                _supplierName = value;
                OnPropertyChange(nameof(SupplierName));
            } 
               

        }
        public string SupplierContact
        {
            get => _supplierContact;
            set
            {
                _supplierContact = value;
                OnPropertyChange(nameof(SupplierContact));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage; set
            {
                _errorMessage = value; OnPropertyChange(nameof(ErrorMessage));
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

        public ICommand? SaveCommand
        {
            get;
        }

        public ICommand? CancelCommand
        {
            get;
        }

        public Action CloseAction
        {
            get; set;
        }

        public AddSupplierViewModel()
        {
            supplierRepository = new SupplierRepository();
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
        }

        private void ExecuteCancelCommand(object? obj)
        {
            IsViewVisible = false;
            CloseAction?.Invoke();
        }

        private bool CanExecuteSaveCommand(object? obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(SupplierName) || string.IsNullOrWhiteSpace(SupplierContact))
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
            Supplier supplier = new Supplier(SupplierName, SupplierContact);
            var isValidSupplier = supplierRepository.Add(supplier);
            if (isValidSupplier)
            {
                /*Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);*/
                RefreshSupplierList.RaiseRefreshRequest();
                IsViewVisible = false;
                CloseAction?.Invoke();
            }
            else
            {
                ResourceDictionary dictionary = Application.Current.Resources.MergedDictionaries[0];
                ErrorMessage = dictionary["supplierExists"] as string;
            }
        }
    }
}
