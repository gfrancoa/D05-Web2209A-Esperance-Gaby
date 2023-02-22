use StoreDatabase

CREATE TABLE Products(
	Id int NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1001,1),
	Category nvarchar(MAX) NOT NULL,
	Name nvarchar(MAX) NOT NULL,
	Description nvarchar(MAX) NOT NULL,
	Price decimal NOT NULL,
	Inventory int NOT NULL,
	ImageUrl nvarchar(MAX) NOT NULL,
	DateCreated datetime2(7) NOT NULL,
	DateUpdated datetime2(7) NOT NULL
)

drop table Products

INSERT INTO Products
(Category,Name,Description,Price,Inventory,ImageUrl,DateCreated,DateUpdated)
VALUES
('Fruits','Apples','Bag per 1 lb',3.50,10,'https://rockfordpack.com/media/catalog/product/cache/1/image/1800x/040ec09b1e35df139433887a97daa66f/0/5/05nv_1.jpg','2023-02-17','2023-02-17'),
('Fruits','Black Grapes','Package per 1 lb',4,5,'https://mrboxinc.com/wp-content/uploads/2016/05/black-bag.jpg','2023-02-17','2023-02-17'),
('Fruits','Fresh Blueberries','Package per 125 g',2,8,'https://d2ln0cvn4pv5w2.cloudfront.net/unsafe/1024x800/filters:quality(100):max_bytes(200000):fill(white)/dcmzfk78s4reh.cloudfront.net/1442945070370.jpg','2023-02-17','2023-02-17'),
('Vegetables','Sweet mixed bell peppers','Package per 1 lb',5,2,'https://static-assets.boxed.com/1443632755416.jpg','2023-02-17','2023-02-17'),
('Fruits','Fresh raspberries','Package per 125 g',3.25,3,'https://rockfordpack.com/media/catalog/product/cache/1/image/1800x/040ec09b1e35df139433887a97daa66f/0/5/05nv_1.jpg','2023-02-17','2023-02-17'),
('Fruits','Pears','Bag per 1 lb',3.25,5,'https://i5.walmartimages.com/asr/3db9d46d-6cb3-4d78-9f30-2341bd173c04_1.3ce8a3c0722d128a9eb8962a84d27f98.jpeg','2023-02-17','2023-02-17'),
('Fruits','Oranges','Bag per 1 lb',5.50,5, 'https://images.heb.com/is/image/HEBGrocery/001945940','2023-02-17','2023-02-17')

SELECT Category,Name,Description,Price,Inventory,ImageUrl
FROM dbo.Products

CREATE TABLE Users(
	Id int NOT NULL PRIMARY KEY CLUSTERED IDENTITY(1000001,1),
	FirstName nvarchar(MAX) NOT NULL,
	LastName nvarchar(MAX) NOT NULL,
	Username nvarchar(MAX) NOT NULL,
	Password nvarchar(MAX) NOT NULL
)

