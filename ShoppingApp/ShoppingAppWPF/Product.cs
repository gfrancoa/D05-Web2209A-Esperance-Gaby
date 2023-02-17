using Chevalier.Utility.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF
{
    class Product:ViewModel
    {
        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; private set; }
        public string ImageUrl { get; set; }

        public Product(int id, string name, double price, int quantity, string imageUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            ImageUrl = imageUrl;
        }

        public void IncreaseQuantity()
        {
            Quantity++;
        }

        public void DecreaseQuantity()
        {
            Quantity--;
        }
    }
}
