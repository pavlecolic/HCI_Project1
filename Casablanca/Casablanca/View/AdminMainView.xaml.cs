using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Casablanca.View
{
    /// <summary>
    /// Interaction logic for AdminMainView.xaml
    /// </summary>
    public partial class AdminMainView : Window
    {
        public AdminMainView()
        {
            InitializeComponent();
        }


        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new EmployeeView();
        }

       
    }
}
