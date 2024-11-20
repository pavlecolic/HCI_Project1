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


namespace Casablanca.ViewModel.EmployeeVM
{
    public class AddCustomerViewModel : ViewModelBase
    {

        private string _jmb;
        private string _firstName;
        private string _lastName;
        private bool _isViewVisible = true;
        private string _addressName;
        private int _addressNumber;
        private string _phoneNumber;
        private string _errorMessage;

        private CustomerRepository CustomerRepository;



        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChange(nameof(PhoneNumber));
            }
        }

        public string AddressName
        {
            get => _addressName;
            set
            {
                _addressName = value;
                OnPropertyChange(nameof(AddressName));
            }
        }

        public int AddressNumber
        {
            get => _addressNumber;
            set
            {
                _addressNumber = value;
                OnPropertyChange(nameof(AddressNumber));
            }
        }

        public string FirstName
        {
            get => _firstName;
            set {
                _firstName = value;
                OnPropertyChange(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChange(nameof(LastName));
            }
        }
        public string JMB
        {
            get => _jmb;
            set
            {
                _jmb = value;
                OnPropertyChange(nameof(JMB));
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

        public string ErrorMessage
        {
            get => _errorMessage;

            set
            {
                _errorMessage = value; OnPropertyChange(nameof(ErrorMessage));
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

        public AddCustomerViewModel()
        {
            CustomerRepository = new CustomerRepository();
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
        }


        private bool CanExecuteSaveCommand(object? obj)
        {
            return true;
        }

        private void ExecuteSaveCommand(object? obj)
        {
            
           
            Address Address = new Address(AddressName, AddressNumber);

            Customer customer = new Customer(FirstName, LastName, JMB, Address, PhoneNumber);
            var isValidCustomer = CustomerRepository.Add(customer);

            if (isValidCustomer)
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
                ErrorMessage = dictionary["invalidCustomer"] as string;
            }
        }

        private void ExecuteCancelCommand(object? obj)
        {
            IsViewVisible = false;
            CloseAction?.Invoke();
        }



    }

}
