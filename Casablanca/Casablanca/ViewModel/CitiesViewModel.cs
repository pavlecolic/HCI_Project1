using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Utils;
using Casablanca.View.Modal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Casablanca.ViewModel
{
    public class CitiesViewModel : ViewModelBase
    {

        private City _selectedCity;

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChange(nameof(SelectedCity));
                ((RelayCommand<City>)EditCommand).RaiseCanExecuteChanged();
                ((RelayCommand<City>)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        ICityRepository _cityRepository;

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


        public ObservableCollection<City> Cities
        {
            get; set;
        }


        public CitiesViewModel()
        {
            _cityRepository = new CityRepository();
            Cities = new ObservableCollection<City>(_cityRepository.GetAll());

            AddCommand = new RelayCommand(AddCity);
            EditCommand = new RelayCommand<City>(EditCity, CanEditOrRemove);
            RemoveCommand = new RelayCommand<City>(RemoveCity, CanEditOrRemove);

            RefreshSupplierList.RefreshRequested += OnRefreshRequested;

        }


        private void OnRefreshRequested()
        {
            Cities.Clear();
            foreach (var supplier in _cityRepository.GetAll())
            {
                Cities.Add(supplier);
            }
        }

        private  void AddCity()
        {
            var dialog = new AddCityDialog();

        }


        private void EditCity(City city)
        {
            if (city != null)
            {
                _cityRepository.Edit(city);
                OnPropertyChange(nameof(City));
            }
        }

        private void RemoveCity(City city)
        {
            if (city != null)
            {
                Cities.Remove(city);
                _cityRepository.Remove(city);
            }
        }

        private bool CanEditOrRemove(City city)
        {
            return city != null;
        }
    }
}
