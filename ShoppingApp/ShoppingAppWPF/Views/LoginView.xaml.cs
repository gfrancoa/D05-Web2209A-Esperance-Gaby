using ShoppingAppWPF.ViewModels;
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

namespace ShoppingAppWPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public event NavigationHandler NavigateToProductFromLoginRequested;
        public LoginView()
        {
            InitializeComponent();
        }

        private void OnLoginButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigateToProductFromLoginRequested?.Invoke();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((LoginViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
        }
    }
}
