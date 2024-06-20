using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Casablanca.Utils;

namespace Casablanca.Components
{
    /// <summary>
    /// Interaction logic for ChangeThemeControl.xaml
    /// </summary>
    public partial class ChangeThemeControl : UserControl
    {
        public ChangeThemeControl()
        {
            InitializeComponent();
        }

        public void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedTheme = selectedItem.Tag.ToString();
                switch (selectedTheme)
                {
                    case "dk":
                        AppTheme.ChangeTheme(new Uri("Themes/UIColorsDark.xaml", UriKind.Relative));
                        break;
                    case "li":
                        AppTheme.ChangeTheme(new Uri("Themes/UIColorsLight.xaml", UriKind.Relative));
                        break;
                    case "co":
                        AppTheme.ChangeTheme(new Uri("Themes/UIColorsCheerful.xaml", UriKind.Relative));
                        break;
                    default:
                        AppTheme.ChangeTheme(new Uri("Themes/UIColorsLight.xaml", UriKind.Relative));
                        break;
                }
                
            }
        }
    }
}
