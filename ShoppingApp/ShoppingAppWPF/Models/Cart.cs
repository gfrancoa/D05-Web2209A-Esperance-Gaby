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

        public Cart()
        {
            Products = new Dictionary<int, Product>();
        }
        public void AddProduct(Product product) {
            if (Products.ContainsKey(product.Id))
                Products[product.Id] = product;
            else
                Products.Add(product.Id, product);
           
        }

        public void RemoveProduct(int id)
        {
            if (Products[id] != null)
            Products.Remove(id);
        }

        public void IncreaseProductQty(int id)
        {
            if (Products[id] != null)
                Products[id].IncreaseQuantity();
        }

        public void DecreaseProductQty(int id)
        {
            if (Products[id] != null)
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
