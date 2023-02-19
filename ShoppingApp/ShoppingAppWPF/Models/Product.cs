using Chevalier.Utility.ViewModels;

namespace ShoppingAppWPF.Models
{
    public class Product:ViewModel
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; private set; }

        public int Inventory { get; private set; }
        public string ImageUrl { get; set; }

        public double TotalPrice
        {
            get
            {
                return Price*Quantity;
            }
        }

        public Product(int id,string category, string name, string description, double price, int quantity, int inventory, string imageUrl)
        {
            Id = id;
            Category= category;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            ImageUrl = imageUrl;
            Inventory= inventory;
        }

        public Product(int id, string category, string name, string description, double price, int inventory, string imageUrl)
        :this(id,category,name,description,price,quantity:0,inventory,imageUrl)
        {
        
        }

        public void IncreaseQuantity()
        {
            if(Quantity<Inventory)
                Quantity++;
        }

        public void ResetQuantity()
        {
            Quantity = 0;
        }

        public void DecreaseQuantity()
        {
            if(Quantity>0)
                Quantity--;
        }
    }
}
