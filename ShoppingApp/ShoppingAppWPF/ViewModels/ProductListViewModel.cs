using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using ShoppingAppWPF.Models;
using ShoppingAppWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF.ViewModels
{
    class ProductListViewModel: ViewModel
    {
        public ObservableCollection<Product> Products { get; }

        public Cart ShoppingCart { get; set; }

        private ProductRepository repository;

        private Product selectedProduct;

        public Product SelectedProduct 
        {
            get
            {
                return selectedProduct;
            }

            set
            {
                selectedProduct= value;
                if (selectedProduct != null)
                {
                    Quantity = selectedProduct.Quantity;
                    ProductName = selectedProduct.Name;
                    ProductDescription = selectedProduct.Description;
                    ImageURL = selectedProduct.ImageUrl;
                    Price = selectedProduct.Price;
                } else
                {
                    Quantity = 0;
                    ProductName = null;
                    ProductDescription = null;
                    ImageURL = null;
                    Price = 0;
                }
                    NotifyPropertyChanged(nameof(Quantity));
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
        public string ImageURL { get; set; } 

        public int TotalQuantity { get; set; }
        public DelegateCommand IncreaseQtyCommand { get; }
        public DelegateCommand DecreaseQtyCommand { get; }
        public DelegateCommand AddToCartCommand { get; }

        private int quantity;

        public ProductListViewModel(Cart cart) {
            repository = new ProductRepository();
            List<Product> productList = repository.GetProducts();
            Products = new ObservableCollection<Product>(productList); 

            IncreaseQtyCommand = new DelegateCommand(IncreaseQty);
            DecreaseQtyCommand = new DelegateCommand(DecreaseQty);
            AddToCartCommand = new DelegateCommand(AddToCart);

            ShoppingCart = cart ?? throw new ArgumentNullException(nameof(cart));
        }

        private void IncreaseQty(object _)
        {
            if(SelectedProduct is not null)
            {
                ShoppingCart.AddProductUnit(SelectedProduct);
                Quantity = SelectedProduct.Quantity;
            }
        }

        private void DecreaseQty(object _)
        {
            if (SelectedProduct is not null)
            {
                ShoppingCart.RemoveProductUnit(SelectedProduct);
                Quantity = SelectedProduct.Quantity;
            }
        }

        private void AddToCart(object _)
        {
            if (SelectedProduct is not null)
            {
                ShoppingCart.AddProductUnit(SelectedProduct);
                Quantity = SelectedProduct.Quantity;
            }
        }
    }
}
