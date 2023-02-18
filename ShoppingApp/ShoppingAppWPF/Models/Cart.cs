using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF.Models
{
    class Cart
    {
        public Dictionary<int, Product> Products { get; }
        private const double Tax = 0.15; 
        public void AddProduct(Product product) { 
            Products.Add(product.Id,product); 
        }

        public void RemoveProduct(int id)
        {
            Products.Remove(id);
        }

        public void IncreaseProductQty(int id)
        {
            Products[id].IncreaseQuantity();
        }

        public void DecreaseProductQty(int id)
        {
            Products[id].DecreaseQuantity();
        }

        public void EmptyCart()
        {
            Products.Clear();
        }

        public double Subtotal
        {
            get
            {
              return Products.Sum(x=>x.Value.TotalPrice);
            }
        }

        public double TaxAmount
        {
            get
            {
                return Subtotal * Tax;
            }
        }

        public double Total
        {
            get
            {
                return Subtotal+TaxAmount;
            }
        }
    }
}
