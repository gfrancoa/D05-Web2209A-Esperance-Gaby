using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF.Models
{
    public class Cart
    {
        public ObservableCollection<Product> Products { get; }

        private readonly Dictionary<int, Product> productsDictionary;
        private const decimal Tax = 0.15m;

        public Cart()
        {
            Products = new ObservableCollection<Product>();
            productsDictionary = new Dictionary<int, Product>();
        }

        public void AddProductUnit(Product product)
        {
            if (productsDictionary.ContainsKey(product.Id))
            {
                if (product.Quantity < product.Inventory)
                {
                    product.Quantity++;
                }
            }
            else
            {
                if (product.Inventory >= 1)
                {
                    product.Quantity = 1;
                    Products.Add(product);
                    productsDictionary.Add(product.Id, product);
                }
            }
        }

        public void RemoveProductUnit(Product product)
        {
            if (productsDictionary.ContainsKey(product.Id))
            {
                if (product.Quantity > 1)
                {
                    product.Quantity--;
                }
                else
                {
                    product.Quantity = 0;
                    Products.Remove(product);
                    productsDictionary.Remove(product.Id);
                }
            }
        }

        public void RemoveProduct(Product product)
        {
            if (productsDictionary.ContainsKey(product.Id))
            {
                product.Quantity = 0;
                Products.Remove(product);
                productsDictionary.Remove(product.Id);
            }
        }

        public void EmptyCart()
        {
            foreach (Product product in Products)
                product.Quantity = 0;

            Products.Clear();
            productsDictionary.Clear();
        }

        public decimal Subtotal
        {
            get
            {
              return productsDictionary.Sum(x=>x.Value.TotalPrice);
            }
        }

        public decimal TaxAmount
        {
            get
            {
                return Subtotal * Tax;
            }
        }

        public decimal Total
        {
            get
            {
                return Subtotal+TaxAmount;
            }
        }
    }
}
