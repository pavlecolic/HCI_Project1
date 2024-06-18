using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Casablanca.Utils
{
    public class LanguageManager
    {
        public static void ChangeLanguage(string languageCode)
        {
          
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


