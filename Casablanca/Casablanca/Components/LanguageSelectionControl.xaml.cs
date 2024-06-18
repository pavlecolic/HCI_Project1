using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Casablanca.Utils;

namespace Casablanca.Components
{
    public partial class LanguageSelectionControl : UserControl
    {
        public LanguageSelectionControl()
        {
            InitializeComponent();
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedLanguage = selectedItem.Tag.ToString();
                LanguageManager.ChangeLanguage(selectedLanguage);
            }

           
        }
    }
}
