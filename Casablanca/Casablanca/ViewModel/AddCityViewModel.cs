using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Casablanca.ViewModel
{
    public class AddCityViewModel : ViewModelBase
    {

        private string _cityName;
        private string _postalCode;
        private string _errorMessage;
        private bool _isViewVisible = true;


        private ICityRepository cityRepository;

        public string CityName
        {
            get => _cityName;

            set
            {
                _cityName = value;
                OnPropertyChange(nameof(CityName));
            }

        }

        public string PostalCode
        {
            get => _postalCode;
            set
            {
                _postalCode = value;
                OnPropertyChange(nameof(PostalCode));
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

        public AddCityViewModel()
        {
            cityRepository = new CityRepository();
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
            if (string.IsNullOrWhiteSpace(CityName) || string.IsNullOrWhiteSpace(PostalCode))
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
            City city = new City(CityName, PostalCode);
            var isValidCity = cityRepository.Add(city);
            if (isValidCity)
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
                ErrorMessage = dictionary["cityExists"] as string;
            }
        }
    }
}
