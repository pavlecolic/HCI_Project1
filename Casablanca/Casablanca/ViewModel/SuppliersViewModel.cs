using Casablanca.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casablanca.Model;
using Casablanca.Repository;
using System.Windows.Input;
using Casablanca.Model.Repository;
using System.Collections.ObjectModel;
using Casablanca.View.Modal;

namespace Casablanca.ViewModel
{
    public class SuppliersViewModel : ViewModelBase
    {

        private Supplier _selectedSupplier;

        public Supplier SelectedSupplier
        {
            get => _selectedSupplier;
            set
            {
                _selectedSupplier = value;
                OnPropertyChange(nameof(SelectedSupplier));
                ((RelayCommand<Supplier>)EditCommand).RaiseCanExecuteChanged();
                ((RelayCommand<Supplier>)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        ISupplierRepository _supplierRepository;

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

        public ObservableCollection<Supplier> Suppliers
        {
            get; set;
        }

        public SuppliersViewModel()
        {
            // get suppliers from database
            _supplierRepository = new SupplierRepository();
            Suppliers = new ObservableCollection<Supplier>(_supplierRepository.GetAll());

            AddCommand = new RelayCommand(AddSupplier);
            EditCommand = new RelayCommand<Supplier>(EditSupplier, CanEditOrRemove);
            RemoveCommand = new RelayCommand<Supplier>(RemoveSupplier, CanEditOrRemove);

            RefreshSupplierList.RefreshRequested += OnRefreshRequested;

        }

        private void OnRefreshRequested()
        {
            Suppliers.Clear();
            foreach (var supplier in _supplierRepository.GetAll())
            {
                Suppliers.Add(supplier);
            }
        }

        private void AddSupplier()
        {
            var dialog = new AddSupplierDialog();
        }

        private void EditSupplier(Supplier supplier)
        {
            // da li preko modala??

            if (supplier != null)
            {
                _supplierRepository.Edit(supplier);
                OnPropertyChange(nameof(Suppliers));
            }
        }

        private void RemoveSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                Suppliers.Remove(supplier);
                _supplierRepository.Remove(supplier);
            }
        }

        private bool CanEditOrRemove(Supplier supplier)
        {
            return supplier != null;
        }

    }
}
