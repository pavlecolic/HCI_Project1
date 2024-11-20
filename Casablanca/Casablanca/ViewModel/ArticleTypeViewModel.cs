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
    public class ArticleTypeViewModel : ViewModelBase
    {

        private ArticleType _selectedArticleType;

        public ArticleType SelectedArticleType
        {
            get => _selectedArticleType;
            set
            {
                _selectedArticleType = value;
                OnPropertyChange(nameof(SelectedArticleType));
                ((RelayCommand<ArticleType>)EditCommand).RaiseCanExecuteChanged();
                ((RelayCommand<ArticleType>)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        ITypeRepository _articleTypeRepository;

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


        public ObservableCollection<ArticleType> ArticleTypes
        {
            get; set;
        }


        public ArticleTypeViewModel()
        {
            _articleTypeRepository = new TypeRepository();
            ArticleTypes = new ObservableCollection<ArticleType>(_articleTypeRepository.GetAll());

            AddCommand = new RelayCommand(AddCity);
            EditCommand = new RelayCommand<ArticleType>(EditCity, CanEditOrRemove);
            RemoveCommand = new RelayCommand<ArticleType>(RemoveCity, CanEditOrRemove);

            RefreshSupplierList.RefreshRequested += OnRefreshRequested;

        }


        private void OnRefreshRequested()
        {
            ArticleTypes.Clear();
            foreach (var supplier in _articleTypeRepository.GetAll())
            {
                ArticleTypes.Add(supplier);
            }
        }

        private void AddCity()
        {
            var dialog = new AddArticleTypeDialog();

        }


        private void EditCity(ArticleType articleType)
        {
            if (articleType != null)
            {
                _articleTypeRepository.Update(articleType);
                OnPropertyChange(nameof(ArticleType));
            }
        }

        private void RemoveCity(ArticleType articleType)
        {
            if (articleType != null)
            {
                ArticleTypes.Remove(articleType);
                _articleTypeRepository.Update(articleType);
            }
        }

        private bool CanEditOrRemove(ArticleType articleType)
        {
            return articleType != null;
        }
    }

}
