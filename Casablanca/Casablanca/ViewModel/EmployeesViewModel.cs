using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Casablanca.Model;
using Casablanca.Model.Repository;
using Casablanca.Repository;
using Casablanca.Utils;
using Casablanca.View;
using Casablanca.View.Modal;

namespace Casablanca.ViewModel
{
    public class EmployeesViewModel : ViewModelBase
    {
        
        private User _selectedEmployee;

        public User SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChange(nameof(SelectedEmployee));
                ((RelayCommand<User>)EditCommand).RaiseCanExecuteChanged();
                ((RelayCommand<User>)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<User> Employees
        {
            get; set;
        }

        IUserRepository _userRepository;

        public ICommand AddCommand
        {
            get; set;
        }
        public ICommand EditCommand
        {
            get; set;
        }
        public ICommand RemoveCommand
        {
            get; set;
        }


        public EmployeesViewModel()
        {
            // get employees from database
            _userRepository = new UserRepository();
            Employees = new ObservableCollection<User>(_userRepository.GetAllEmployees());

            AddCommand = new RelayCommand(AddEmployee);
            EditCommand = new RelayCommand<User>(EditEmployee, CanEditOrRemove);
            RemoveCommand = new RelayCommand<User>(RemoveEmployee, CanEditOrRemove);

            RefreshEmployeeListEvent.RefreshRequested += OnRefreshRequested;
            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged()
        {
            Refresh();

        }

        private void OnRefreshRequested()
        {
            Employees.Clear();
            foreach (var employee in _userRepository.GetAllEmployees())
            {
                Employees.Add(employee);
            }
        }

        private void AddEmployee()
        {
            var dialog = new AddEmployeeDialog();
        }

        private void EditEmployee(User employee)
        {
            // da li preko modala??

            if (employee != null)
            {
                _userRepository.Edit(employee);  
                OnPropertyChange(nameof(Employees));
            }
        }

        private void RemoveEmployee(User employee)
        {
            if (employee != null)
            {
                Employees.Remove(employee);
                _userRepository.Remove(employee);
            }
        }

        private bool CanEditOrRemove(User employee)
        {
            return employee != null;
        }

    }


}
