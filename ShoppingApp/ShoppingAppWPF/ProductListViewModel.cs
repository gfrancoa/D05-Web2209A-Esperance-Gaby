using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF
{
    class ProductListViewModel: ViewModel
    {
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
                selectedProduct= value;
                Quantity= selectedProduct.Quantity;
                ProductName = selectedProduct.Name;
                ImageURL = selectedProduct.ImageUrl;
                Price = selectedProduct.Price;
                NotifyPropertyChanged(nameof(Quantity));
                NotifyPropertyChanged(nameof(ProductName));
                NotifyPropertyChanged(nameof(ImageURL));
                NotifyPropertyChanged(nameof(Price));
            } 
        }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; } 

        public int TotalQuantity { get; set; }
        public DelegateCommand IncreaseQtyCommand { get; }
        public DelegateCommand DecreaseQtyCommand { get; }
        public DelegateCommand AddToCartCommand { get; }

        public ProductListViewModel() {
            Products = new ObservableCollection<Product>
            {
                new Product(1,"Bag of Apples per 1 lb",3.50,0,"https://rockfordpack.com/media/catalog/product/cache/1/image/1800x/040ec09b1e35df139433887a97daa66f/0/5/05nv_1.jpg"),
                new Product(2,"Black Grapes per 1 lb",4,0,"https://mrboxinc.com/wp-content/uploads/2016/05/black-bag.jpg"),
                new Product(3,"Fresh blueberries per 125 g",2,0,"https://d2ln0cvn4pv5w2.cloudfront.net/unsafe/1024x800/filters:quality(100):max_bytes(200000):fill(white)/dcmzfk78s4reh.cloudfront.net/1442945070370.jpg"),
                new Product(4,"Sweet mixed bell peppers  per 1 lb",5,0,"https://static-assets.boxed.com/1443632755416.jpg"),
                new Product(5,"Fresh raspberries per 125 g",3.25,0,"https://rockfordpack.com/media/catalog/product/cache/1/image/1800x/040ec09b1e35df139433887a97daa66f/0/5/05nv_1.jpg"),
                new Product(6,"Bag of Pears per 1 lb",3.25,0,"https://i5.walmartimages.com/asr/3db9d46d-6cb3-4d78-9f30-2341bd173c04_1.3ce8a3c0722d128a9eb8962a84d27f98.jpeg"),
                new Product(7,"Bag of oranges per 1 lb",5.50,0,"https://images.heb.com/is/image/HEBGrocery/001945940")
            };

            IncreaseQtyCommand = new DelegateCommand(IncreaseQty);
            DecreaseQtyCommand = new DelegateCommand(DecreaseQty);
            AddToCartCommand = new DelegateCommand(AddToCart);
        }

        private void IncreaseQty(object _)
        {
            if(SelectedProduct is not null)
            {
                SelectedProduct.IncreaseQuantity();
                Quantity = SelectedProduct.Quantity;
                NotifyPropertyChanged(nameof(Quantity));
            }
        }

        private void DecreaseQty(object _)
        {
            if (SelectedProduct is not null)
            {
                SelectedProduct.DecreaseQuantity();
                Quantity = SelectedProduct.Quantity;
                NotifyPropertyChanged(nameof(Quantity));
            }
        }

        private void AddToCart(object _)
        {

        }
    }
}
