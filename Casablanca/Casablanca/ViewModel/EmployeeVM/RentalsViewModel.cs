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

namespace Casablanca.ViewModel.EmployeeVM
{
    public class RentalsViewModel : ViewModelBase
    {
        private ObservableCollection<Rental> _rentals;
        private Customer _selectedCustomer;
        private IRentalRepository rentalRepository;
        private Rental _rental;


        public ICommand RemoveRentalCommand
        {
            get;
        }
        public ICommand RecordReturnCommand
        {
            get;
        }


        public Rental Rental
        {
            get => _rental;
            set
            {
                _rental = value;
                OnPropertyChange(nameof(Rental));
            }
        }

        public ObservableCollection<Rental> Rentals
        {
            get => _rentals;
            set
            {
                _rentals = value;
                OnPropertyChange(nameof(Rentals));
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChange(nameof(SelectedCustomer));
                LoadRentals();
            }
        }

        private void LoadRentals()
        {
            if (_selectedCustomer == null) return;

            Rentals = new ObservableCollection<Rental>(rentalRepository.GetByCustomerId(_selectedCustomer.Id));
           

        }


        public RentalsViewModel(Customer customer)
        {
            rentalRepository = new RentalRepository();
            SelectedCustomer = customer;

            RefreshRentalsList.RefreshRequested += OnRefreshRequested;


            RemoveRentalCommand = new RelayCommand(RemoveRental, CanExecuteRentalCommand);
            RecordReturnCommand = new RelayCommand(RecordReturn, CanExecuteRentalCommand);
        }

        private void OnRefreshRequested()
        {
            Rentals.Clear();
            foreach (var rental in rentalRepository.GetByCustomerId(SelectedCustomer.Id))
            {
                Rentals.Add(rental);
            }
        }

        public bool CanExecuteRentalCommand()
        {
            return Rental != null;
        }

        public void RemoveRental()
        {
            if (Rental == null) return;

            rentalRepository.Delete(Rental.Id);
            Rentals.Remove(Rental);
            Rental = null;
        }

        private void RecordReturn()
        {
            if (Rental == null || Rental.ReturnDate != null) { return; }

            // samo ako nije vec razduzena

            Rental.ReturnDate = DateTime.Now;
            
            rentalRepository.Update(Rental);
            Rental = null;

            OnRefreshRequested();
        }
    }
}
