using ShoppingAppWPF.Models;
using ShoppingAppWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ShoppingView : UserControl
    {
        Cart cart;
        User user;
        ProductListViewModel productListViewModel;
        CartViewModel cartViewModel;
        LoginViewModel loginViewModel;
        public ShoppingView()
        {
            InitializeComponent();

            productListView.NavigateToCartRequested += OnNavigateToCartRequested;
            productListView.NavigateToLoginRequested += OnNavigateToLoginRequested;
            cartView.NavigateToProductListRequested += OnNavigateToProductListRequested;
            cartView.NavigateToLoginRequested += OnNavigateToLoginRequested;
            loginView.NavigateToProductFromLoginRequested += OnNavigateToProductListRequested;

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                cart = new Cart();
                user = new User();
                productListViewModel = new ProductListViewModel(cart,user);
                cartViewModel = new CartViewModel(cart,user);
                loginViewModel = new LoginViewModel(user,OnNavigateToProductListRequested,loginView);
               
                productListView.DataContext = productListViewModel;
                cartView.DataContext = cartViewModel;
                loginView.DataContext = loginViewModel;
            }
        }

        private void OnNavigateToCartRequested()
        {
            productListView.Visibility = Visibility.Collapsed;
            loginView.Visibility = Visibility.Collapsed;
            cartView.Visibility = Visibility.Visible;
            cartViewModel.Subtotal = cart.Subtotal;
            cartViewModel.Total = cart.Total;
            cartViewModel.TaxAmount = cart.TaxAmount;
        }

        private void OnNavigateToProductListRequested()
        {
            productListView.Visibility = Visibility.Visible;
            cartView.Visibility = Visibility.Collapsed;
            loginView.Visibility = Visibility.Collapsed;
            productListViewModel.Name= loginViewModel.Name;
            cartViewModel.Name= loginViewModel.Name;
        }

        private void OnNavigateToLoginRequested()
        {
            productListView.Visibility = Visibility.Collapsed;
            cartView.Visibility = Visibility.Collapsed;
            loginView.Visibility = Visibility.Visible;
        }
    }
}
