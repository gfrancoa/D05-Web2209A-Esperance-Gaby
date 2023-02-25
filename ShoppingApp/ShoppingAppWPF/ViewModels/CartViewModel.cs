using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using ShoppingAppWPF.Models;
using ShoppingAppWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF.ViewModels
{
    class CartViewModel : ViewModel
    {
        private Cart cart;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }

        }
        public ObservableCollection<Product> Products { get; }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }

            set
            {
                selectedProduct = value;
                if (selectedProduct != null)
                {
                    Quantity = selectedProduct.Quantity;
                    ProductName = selectedProduct.Name;
                    ProductDescription = selectedProduct.Description;
                    ImageURL = selectedProduct.ImageUrl;
                    Price = selectedProduct.Price;
                }
                else
                {
                    Quantity = 0;
                    ProductName = null;
                    ProductDescription = null;
                    ImageURL = null;
                    Price = 0;
                }
                NotifyPropertyChanged(nameof(ProductName));
                NotifyPropertyChanged(nameof(ProductDescription));
                NotifyPropertyChanged(nameof(ImageURL));
                NotifyPropertyChanged(nameof(Price));

            }
        }
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                NotifyPropertyChanged(nameof(Quantity));
            }
        }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        private decimal subtotal;
        public decimal Subtotal
        {
            get => subtotal;
            set
            {
                subtotal = value;
                NotifyPropertyChanged(nameof(Subtotal));
            }
        }

        private decimal taxAmount;
        public decimal TaxAmount
        {
            get => taxAmount;
            set
            {
                taxAmount = value;
                NotifyPropertyChanged(nameof(TaxAmount));
            }
        }
        private decimal total;
        public decimal Total
        {
            get => total;
            set
            {
                total = value;
                NotifyPropertyChanged(nameof(Total));
            }
        }

        public string Message { get; set; }
        public string ImageURL { get; set; }

        public int TotalQuantity { get; set; }
        public DelegateCommand IncreaseQtyCommand { get; }
        public DelegateCommand DecreaseQtyCommand { get; }
        public DelegateCommand RemoveFromCartCommand { get; }
        public DelegateCommand DeleteCartCommand { get; }
        public DelegateCommand PlaceOrderCommand { get; }

        private int quantity;

        public CartViewModel(Cart cart, User user)
        {
            Products = cart.Products;
            Name = user.Name;

            IncreaseQtyCommand = new DelegateCommand(IncreaseQty);
            DecreaseQtyCommand = new DelegateCommand(DecreaseQty);
            RemoveFromCartCommand = new DelegateCommand(RemoveFromCart);
            DeleteCartCommand = new DelegateCommand(DeleteCart);
            PlaceOrderCommand = new DelegateCommand(PlaceOrder);

            this.cart = cart ?? throw new ArgumentNullException(nameof(cart));
        }

        private void IncreaseQty(object _)
        {
            if (SelectedProduct is not null)
            {
                cart.AddProductUnit(SelectedProduct);
                Quantity = SelectedProduct.Quantity;
                Subtotal = cart.Subtotal;
                TaxAmount = cart.TaxAmount;
                Total = cart.Total;
                NotifyPropertyChanged(nameof(Subtotal));
                NotifyPropertyChanged(nameof(Total));
                NotifyPropertyChanged(nameof(TaxAmount));
            }
        }

        private void DecreaseQty(object _)
        {
            if (SelectedProduct is not null)
            {
                Product selectedProduct = SelectedProduct;
                cart.RemoveProductUnit(selectedProduct);
                Quantity = selectedProduct.Quantity;
                Subtotal = cart.Subtotal;
                TaxAmount = cart.TaxAmount;
                Total = cart.Total;
                NotifyPropertyChanged(nameof(Subtotal));
                NotifyPropertyChanged(nameof(Total));
                NotifyPropertyChanged(nameof(TaxAmount));
            }
        }

        private void RemoveFromCart(object _)
        {
            Product selectedProduct = SelectedProduct;
            cart.RemoveProduct(selectedProduct);
            Quantity = selectedProduct.Quantity;
            Subtotal = cart.Subtotal;
            TaxAmount = cart.TaxAmount;
            Total = cart.Total;
            NotifyPropertyChanged(nameof(Subtotal));
            NotifyPropertyChanged(nameof(Total));
            NotifyPropertyChanged(nameof(TaxAmount));

        }
        private void DeleteCart(object _)
        {
            cart.EmptyCart();
            Subtotal = cart.Subtotal;
            TaxAmount = cart.TaxAmount;
            Total = cart.Total;
            Message = "You cart has been deleted succesfully. Click back to select products";
            NotifyPropertyChanged(nameof(Message));
            NotifyPropertyChanged(nameof(Subtotal));
            NotifyPropertyChanged(nameof(Total));
            NotifyPropertyChanged(nameof(TaxAmount));
        }
        private void PlaceOrder(object _)
        {
            cart.EmptyCart();
            Subtotal = cart.Subtotal;
            TaxAmount = cart.TaxAmount;
            Total = cart.Total;
            Message = "Your order has been placed succesfully!";
            NotifyPropertyChanged(nameof(Message));
            NotifyPropertyChanged(nameof(Subtotal));
            NotifyPropertyChanged(nameof(Total));
            NotifyPropertyChanged(nameof(TaxAmount));

        }
    }
}
