using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Utils;
using Casablanca.View.Modal;

namespace Casablanca.ViewModel.EmployeeVM
{ 
    public class ArticlesEmployeeViewModel :ViewModelBase
    {

        private ArticleRepository articleRepository;
        private ITypeRepository typeRepository = new TypeRepository();

        private Article _selectedArticle;
        private ObservableCollection<Article> _filteredArticles;
        private ObservableCollection<Article> _articles;


        private string _searchQuery;
        private bool? _isRentedFilter;
        private ArticleType _selectedCategory;

        public ICommand AddCommand
        {
            get;

        }

        public ICommand SelectArticleCommand
        {
            get;

        }

        public ICommand RemoveCommand
        {
            get;

        }
        public ObservableCollection<ArticleType> Categories
        {
            get; set;
        }

        public ArticleType SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                FilterArticles();
            }
        }

        public bool? IsRentedFilter
        {
            get => _isRentedFilter;
            set
            {
                _isRentedFilter = value;
                OnPropertyChanged(nameof(IsRentedFilter));
                FilterArticles();
            }
        }


        public ObservableCollection<Article> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChange(nameof(Articles));
            }
        }

        public ObservableCollection<Article> FilteredArticles
        {
            get => _filteredArticles;
            set
            {
                _filteredArticles = value;
                OnPropertyChange(nameof(FilteredArticles));
            }
        }
        public ICommand DisplayArticleCommand
        {
            get;
        }

        public Article SelectedArticle
        {
            get => _selectedArticle;

            set
            {
                _selectedArticle = value;
                OnPropertyChange(nameof(SelectedArticle));
            }

        }

        public ArticlesEmployeeViewModel()
        {
            articleRepository = new ArticleRepository();
            _articles = new ObservableCollection<Article>(articleRepository.GetAll());
            _filteredArticles = new ObservableCollection<Article>(_articles);

            DisplayArticleCommand = new RelayCommand<Article>(DisplayArticleDetails);
            RemoveCommand = new RelayCommand<Article>(ExecuteRemoveCommand, CanRemoveCommand);
            AddCommand = new RelayCommand(ExecuteAddCommand);
            SelectArticleCommand = new RelayCommand<Article>(SelectArticle);

            List<ArticleType> types = typeRepository.GetAll();
            types.Add(new ArticleType(-1, "All"));

            Categories = new ObservableCollection<ArticleType>(types);
        }

        private bool CanRemoveCommand(Article article)
        {
            return article != null;
        }

        private void DisplayArticleDetails(Article article)
        {
            SelectedArticle = article;
            // otvori DetailsView
        }



        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                FilterArticles();
            }
        }

        private void FilterArticles()
        {
            var filtered = _articles.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                filtered = filtered.Where(a => a.Name.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase));
            }

            if (SelectedCategory != null)
            {
                if (SelectedCategory.TypeName == "All")
                {
                    if (!string.IsNullOrWhiteSpace(SearchQuery))
                    {
                        filtered = filtered.Where(a => a.Name.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase));
                    }
                    else
                    {
                        // 
                    }

                }
                else
                {
                    filtered = filtered.Where(a => a.Type.Id == SelectedCategory.Id);
                }
            }

            if (IsRentedFilter.HasValue)
            {
                filtered = filtered.Where(a => a.IsRented == IsRentedFilter.Value);
            }

            FilteredArticles = new ObservableCollection<Article>(filtered);
        }

        private void ExecuteAddCommand()
        {
            System.Diagnostics.Debug.WriteLine("DIALOG");
            var dialog = new AddArticleDialog();
        }


        private void ExecuteRemoveCommand(object? obj)
        {
            if(SelectedArticle != null)
            {
                articleRepository.Remove(SelectedArticle);
            }
        }

        private void SelectArticle(Article article)
        {
            SelectedArticle = article;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
