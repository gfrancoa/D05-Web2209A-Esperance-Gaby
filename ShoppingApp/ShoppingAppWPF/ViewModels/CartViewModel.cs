using ShoppingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF.ViewModels
{
    class CartViewModel
    {
        private Cart cart;

        public CartViewModel(Cart cart)
        {
            this.cart = cart;
        }
    }
}
