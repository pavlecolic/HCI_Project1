using Casablanca.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Casablanca.Utils
{
    public class LanguageManager
    {
        public static event Action LanguageChanged;

        public static void ChangeLanguage(string cultureName)
        {
            ResourceDictionary newLanguageDict = new ResourceDictionary();
            switch (cultureName)
            {
                case "sr":
                    newLanguageDict.Source = new Uri("pack://application:,,,/Resources/Strings.sr.xaml", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    newLanguageDict.Source = new Uri("pack://application:,,,/Resources/Strings.en.xaml", UriKind.RelativeOrAbsolute);
                    break;
            }

            ResourceDictionary existingLanguageDict = null;
            foreach (var dictionary in Application.Current.Resources.MergedDictionaries)
            {
                if (dictionary.Source != null && (dictionary.Source.ToString().Contains("Resources/Strings.sr.xaml") ||
                                                  dictionary.Source.ToString().Contains("Resources/Strings.en.xaml")))
                {
                    existingLanguageDict = dictionary;
                    break;
                }
            }

            if (existingLanguageDict != null)
            {
                int index = Application.Current.Resources.MergedDictionaries.IndexOf(existingLanguageDict);
                Application.Current.Resources.MergedDictionaries.RemoveAt(index);
                Application.Current.Resources.MergedDictionaries.Insert(index, newLanguageDict);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(newLanguageDict);
            }

            CultureInfo cultureInfo = new CultureInfo(cultureName);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            LanguageChanged?.Invoke();

        }

        private static void UpdateResourceBindings()
        {
            foreach (Window window in Application.Current.Windows)
            {
                foreach (var binding in window.GetBindings())
                {
                    binding.UpdateTarget();
                }
            }
        }
    }

    public static class WindowExtensions
    {
        public static IEnumerable<BindingExpressionBase> GetBindings(this DependencyObject dependencyObject)
        {
            var bindings = new List<BindingExpressionBase>();
            var localValueEnumerator = dependencyObject.GetLocalValueEnumerator();

            while (localValueEnumerator.MoveNext())
            {
                var entry = localValueEnumerator.Current;
                if (entry.Value is BindingExpressionBase bindingExpression)
                {
                    bindings.Add(bindingExpression);
                }
            }

            foreach (DependencyObject child in LogicalTreeHelper.GetChildren(dependencyObject).OfType<DependencyObject>())
            {
                bindings.AddRange(child.GetBindings());
            }

            return bindings;
        }
    }


}


