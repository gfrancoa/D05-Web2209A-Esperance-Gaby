using Chevalier.Utility.ViewModels;

namespace ShoppingAppWPF.Models
{
    public class Product:ViewModel
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                NotifyPropertyChanged(nameof(Quantity));
                NotifyPropertyChanged(nameof(TotalPrice));
            }
        }

        public int Inventory { get; private set; }
        public string ImageUrl { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Price*Quantity;
            }
        }

        private int quantity;

        public Product(int id,string category, string name, string description, decimal price, int quantity, int inventory, string imageUrl)
        {
            Id = id;
            Category= category;
            Name = name;
            Description = description;
            Price = price;
            this.quantity = quantity;
            ImageUrl = imageUrl;
            Inventory= inventory;
        }

        public Product(int id, string category, string name, string description, decimal price, int inventory, string imageUrl)
            :this(id,category,name,description,price,quantity:0,inventory,imageUrl)
        { }
    }
}
