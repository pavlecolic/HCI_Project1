using Casablanca.ViewModel;
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
using System.Windows.Shapes;

namespace Casablanca.View.Modal
{
   
    public partial class AddEmployeeDialog : Window
    {
      /*  public string FirstName => FirstNameTextBox.Text;
        public string LastName => LastNameTextBox.Text;
        public float Salary => float.Parse(SalaryTextBox.Text);
        public string Username => UsernameTextBox.Text;*/

        public AddEmployeeDialog()
        {
            InitializeComponent();
           
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
