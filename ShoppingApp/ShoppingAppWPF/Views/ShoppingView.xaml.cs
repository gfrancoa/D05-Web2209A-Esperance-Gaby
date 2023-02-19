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
        ProductListViewModel productListViewModel;
        CartViewModel cartViewModel;
        public ShoppingView()
        {
            InitializeComponent();

            productListView.NavigateToCartRequested += OnNavigateToCartRequested;
            cartView.NavigateToProductListRequested += OnNavigateToProductListRequested;

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                cart = new Cart();
                productListViewModel = new ProductListViewModel(cart);
               cartViewModel = new CartViewModel(cart);
               
                productListView.DataContext = productListViewModel;
                cartView.DataContext = cartViewModel;
            }
        }

        private void OnNavigateToCartRequested()
        {
            productListView.Visibility = Visibility.Collapsed;
            cartView.Visibility = Visibility.Visible;
            cartViewModel.Subtotal = cart.Subtotal;
            cartViewModel.Total = cart.Total;
            cartViewModel.TaxAmount = cart.TaxAmount;
        }

        private void OnNavigateToProductListRequested()
        {
            productListView.Visibility = Visibility.Visible;
            cartView.Visibility = Visibility.Collapsed;
        }
    }
}
