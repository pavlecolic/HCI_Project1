using Casablanca.Model;
using Casablanca.Repository;
using Casablanca.Repository.RepoInterfaces;
using Casablanca.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Casablanca.ViewModel.EmployeeVM
{
    public class AddArticleViewModel : ViewModelBase
    {

        public string Name
        {
            get; set;
        }
        public string ImageURL
        {
            get; set;
        }
        public double Price
        {
            get; set;
        }
        public ArticlePublisher SelectedPublisher
        {
            get; set;
        }
        public ArticleType SelectedType
        {
            get; set;
        }



        private IPublisherRepository PublisherRepository;
        private ITypeRepository TypeRepository;
        private IArticleRepository ArticleRepository;


        public Article NewArticle
        {
            get; set;
        }

        public ObservableCollection<ArticlePublisher> Publishers
        {
            get; set;
        }
        public ObservableCollection<ArticleType> Types
        {
            get; set;
        }

        public ICommand BrowseImageCommand
        {
            get;
        }
        public ICommand SaveCommand
        {
            get;
        }
        public ICommand CancelCommand
        {
            get;
        }


        private bool _isViewVisible = true;

        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value; OnPropertyChange(nameof(IsViewVisible));
            }
        }

        public AddArticleViewModel()
        {
            PublisherRepository = new PublisherRepository();
            TypeRepository = new TypeRepository();
            ArticleRepository = new ArticleRepository();

            Publishers = new ObservableCollection<ArticlePublisher>(PublisherRepository.GetAll());
            Types = new ObservableCollection<ArticleType>(TypeRepository.GetAll());

            BrowseImageCommand = new RelayCommand(BrowseImage);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }


        private void BrowseImage()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png;*.jpeg",
                Title = "Select Image"
            };

            if (dialog.ShowDialog() == true)
            {
                ImageURL = dialog.FileName;
                OnPropertyChange(nameof(ImageURL));
            }
        }

        private void Save()
        {

            if (string.IsNullOrWhiteSpace(Name) || Price <= 0 || SelectedPublisher == null || SelectedType == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Article article = new Article(Name, ImageURL, SelectedType, SelectedPublisher, false, false, Price);
            System.Diagnostics.Debug.WriteLine(article);

            if (SaveArticle(article))
                MessageBox.Show("Article saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MessageBox.Show("Article not saved", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CloseWindow();
        }

        private bool SaveArticle(Article article)
        {
            return ArticleRepository.Add(article);
        }


        private void Cancel()
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.DataContext == this)?.Close();
        }

    }
}
