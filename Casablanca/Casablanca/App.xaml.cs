using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Casablanca.View;
using Casablanca.View.UserView;

namespace Casablanca
{

    public partial class App : Application
    {

        protected void ApplicationStart(object sender, StartupEventArgs e)
        {

            var culture = new CultureInfo("en-EN");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    if (Thread.CurrentPrincipal.IsInRole("Admin"))
                    {
                        var adminMainView = new AdminMainView();
                        adminMainView.Show();
                    }
                    else if (Thread.CurrentPrincipal.IsInRole("User"))
                    {
                        var employeeMainView = new EmployeeMainView();
                        employeeMainView.Show();
                    }
                }
            };
        }
        public void ChangeCulture(string cultureCode, Window currentWindow)
        {

        }
    }
}
