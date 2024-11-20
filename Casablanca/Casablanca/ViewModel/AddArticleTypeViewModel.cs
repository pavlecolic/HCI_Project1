using Casablanca.Model;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Repository;
using Casablanca.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Casablanca.ViewModel
{
    public class AddArticleTypeViewModel : ViewModelBase
    {
        private string _articleTypeName;
        private string _errorMessage;
        private bool _isViewVisible = true;


        private ITypeRepository articleTypeRepository;

        public string ArticleTypeName
        {
            get => _articleTypeName;

            set
            {
                _articleTypeName = value;
                OnPropertyChange(nameof(ArticleTypeName));
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

        public AddArticleTypeViewModel()
        {
            articleTypeRepository = new TypeRepository();
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
            if (string.IsNullOrWhiteSpace(ArticleTypeName))
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
            ArticleType articleType = new ArticleType(ArticleTypeName);
            articleTypeRepository.Add(articleType);
            RefreshSupplierList.RaiseRefreshRequest();
            IsViewVisible = false;
            CloseAction?.Invoke();
        }
    }
}
