using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Casablanca.Utils
{
    public class AppTheme
    {
        public static void ChangeTheme(Uri themeUri)
        {
            ResourceDictionary theme = new ResourceDictionary()
            {
                Source = themeUri,
            };

            ResourceDictionary existingTheme = null;
            foreach (var dictionary in App.Current.Resources.MergedDictionaries)
            {
                if (dictionary.Source != null && dictionary.Source.ToString().Contains("Themes/"))
                {
                    existingTheme = dictionary;
                    break;
                }
            }

            if (existingTheme != null)
            {
                App.Current.Resources.MergedDictionaries.Remove(existingTheme);
            }

            App.Current.Resources.MergedDictionaries.Add(theme);
        }
    }
}
