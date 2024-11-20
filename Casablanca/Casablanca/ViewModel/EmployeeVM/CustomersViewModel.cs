using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Utils;
using Casablanca.View.Modal;
using MahApps.Metro.Controls;


namespace Casablanca.ViewModel.EmployeeVM
{
    public class CustomersViewModel : ViewModelBase
    {

        public ObservableCollection<Customer> Customers { get; set; }
        private ICustomerRepository CustomerRepository;

        private EmployeeMainViewModel EmployeeMainViewModel;



        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChange(nameof(SelectedCustomer));
                ((RelayCommand<Customer>)EditCommand).RaiseCanExecuteChanged();
                ((RelayCommand<Customer>)RemoveCommand).RaiseCanExecuteChanged();
                ((RelayCommand<Customer>)RentalsCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddCommand { get; set; }

        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RentalsCommand { get; set; }


        

        public CustomersViewModel(EmployeeMainViewModel employeeMainViewModel)
        {
            EmployeeMainViewModel = employeeMainViewModel;

            CustomerRepository = new CustomerRepository();
            Customers = new ObservableCollection<Customer>(CustomerRepository.GetAll());

            AddCommand = new RelayCommand(AddCustomer);
            EditCommand = new RelayCommand<Customer>(EditCustomer, CanEditOrRemove);
            RemoveCommand = new RelayCommand<Customer>(RemoveCustomer, CanEditOrRemove);
            RentalsCommand = new RelayCommand<Customer>(DisplayRentals, CanEditOrRemove);

            RefreshEmployeeListEvent.RefreshRequested += OnRefreshRequested;
            LanguageManager.LanguageChanged += OnLanguageChanged;

        }

        private void OnLanguageChanged()
        {
            Refresh();

        }

        private void OnRefreshRequested()
        {
            Customers.Clear();
            foreach (var customer in CustomerRepository.GetAll())
            {
                Customers.Add(customer);
            }
        }

        private void AddCustomer()
        {
           var dialog =  new AddCustomerDialog();
        }

        private void EditCustomer(Customer customer)
        {
            if(customer != null)
            {
                CustomerRepository.Edit(customer);
                OnPropertyChange(nameof(Customers));

            }
        }

        private void RemoveCustomer(Customer customer)
        {
            if(customer != null)
            {
                Customers.Remove(customer);
                CustomerRepository.Remove(customer.Id);
            }
        }

        private void DisplayRentals(Customer customer)
        {
            File.AppendAllText("log.txt", "Display Rentals ");

            if (customer != null)
            {
                EmployeeMainViewModel.CurrentChildView = new RentalsViewModel(customer);
                File.AppendAllText("log.txt", "Display Rentals " + customer);

            }
        }

        private bool CanEditOrRemove(Customer customer)
        {
            return customer != null;
        }
    }
}
