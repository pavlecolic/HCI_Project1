using Casablanca.Model;
using Casablanca.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using System.ComponentModel;
using System.Windows;


namespace Casablanca.ViewModel.EmployeeVM
{
    public class NewRentalViewModel : ViewModelBase
    {
        private IArticleRepository _articleRepository = new ArticleRepository();
        private int _customerId;
        private double _totalPrice;
        private string _searchQuery;

        // All articles (unfiltered list)
        private ObservableCollection<Article> _allArticles;

        public ObservableCollection<Article> AvailableArticles
        {
            get; set;
        }
        public ObservableCollection<Article> SelectedArticles
        {
            get; set;
        }

        public int CustomerId
        {
            get => _customerId;
            set
            {
                _customerId = value;
                OnPropertyChange(nameof(CustomerId));
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChange(nameof(SearchQuery));
                FilterArticles();
            }
        }

        public double TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChange(nameof(TotalPrice));
            }
        }

        public ICommand SubmitRentalCommand
        {
            get;
        }

        public NewRentalViewModel()
        {
            _allArticles = new ObservableCollection<Article>(_articleRepository.GetAll());
            AvailableArticles = new ObservableCollection<Article>(_allArticles);
            SelectedArticles = new ObservableCollection<Article>();

            foreach (var article in _allArticles)
            {
                article.PropertyChanged += Article_PropertyChanged;
            }

            SubmitRentalCommand = new RelayCommand(SubmitRental);
        }

        private void Article_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Article.IsSelected))
            {
                var article = sender as Article;
                if (article != null)
                {
                    if (article.IsSelected && !SelectedArticles.Contains(article))
                    {
                        SelectedArticles.Add(article);
                        System.Diagnostics.Debug.WriteLine($"Added: {article.Name}");
                    }
                    else if (!article.IsSelected && SelectedArticles.Contains(article))
                    {
                        SelectedArticles.Remove(article);
                        System.Diagnostics.Debug.WriteLine($"Added: {article.Name}");
                    }

                    CalculateTotalPrice();
                }
            }
        }

        private void CalculateTotalPrice()
        {
            TotalPrice = SelectedArticles.Sum(a => a.Price);
            System.Diagnostics.Debug.WriteLine($"Total Price Updated: {TotalPrice:C}");
        }

        private void FilterArticles()
        {
            AvailableArticles.Clear();

            var filteredArticles = string.IsNullOrWhiteSpace(SearchQuery)
                ? _allArticles
                : _allArticles.Where(a => a.Name.Contains(SearchQuery, System.StringComparison.OrdinalIgnoreCase));

            foreach (var article in filteredArticles)
            {
                AvailableArticles.Add(article);
            }
        }

        private void SubmitRental()
        {
            if (CustomerId <= 0 || SelectedArticles.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("Invalid customer or no articles selected.");
                MessageBox.Show("Please select a valid customer and at least one article to rent.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a list of RentedArticle objects
            var rentedArticles = SelectedArticles.Select(article => new RentedArticle
            {
                Article = article,
                Price = article.Price
            }).ToList();

            // Create a Rental object
            var rental = new Rental(
                id: 0, 
                rentDate: DateTime.Now,
                dueDate: DateTime.Now.AddDays(7), 
                price: TotalPrice,
                customer: new Customer(CustomerId, "", "", "", null, ""),
                rentedArticles: rentedArticles
            );

            // Call the repository to save the rental
            var rentalRepository = new RentalRepository();
            bool isCreated = rentalRepository.Create(rental);

            if (isCreated)
            {
                System.Diagnostics.Debug.WriteLine($"Rental successfully created for Customer {CustomerId}. Total: {TotalPrice:C}");
                
                SelectedArticles.Clear();
                TotalPrice = 0;
                MessageBox.Show("Rental successfully created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed to create the rental. Please try again.");
                MessageBox.Show("Failed to create the rental. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

