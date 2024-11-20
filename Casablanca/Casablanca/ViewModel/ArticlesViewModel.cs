using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.ViewModel
{
    public class ArticlesViewModel : ViewModelBase
    {
        private ObservableCollection<Article> _articles;
        private ObservableCollection<Article> _filteredArticles;

        private ArticleType _selectedCategory;
        private bool? _isRentedFilter;

        private IArticleRepository articleRepository = new ArticleRepository();
        private ITypeRepository typeRepository = new TypeRepository();

        private string _searchQuery;

        public ArticlesViewModel()
        {
            _articles = new ObservableCollection<Article>(articleRepository.GetAll());
            _filteredArticles = new ObservableCollection<Article>(_articles);
            List<ArticleType> types = typeRepository.GetAll();
            types.Add(new ArticleType(-1, "All"));

            Categories = new ObservableCollection<ArticleType>(types);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
