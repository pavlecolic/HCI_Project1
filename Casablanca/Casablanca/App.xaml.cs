using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Casablanca.View;
namespace Casablanca
{
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {

            // Set culture to French for demonstration purposes
            var culture = new CultureInfo("en-EN");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new AdminMainView();
                    mainView.Show();
                    loginView.Close();
                }
            };
        }
        public void ChangeCulture(string cultureCode, Window currentWindow)
        {

        }
    }
}
