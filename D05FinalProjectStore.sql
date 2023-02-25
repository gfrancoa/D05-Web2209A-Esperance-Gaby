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

--drop table Products

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
	Username nvarchar(MAX) NOT NULL,
	PasswordSalt varbinary(MAX) NOT NULL,
	PasswordHash varbinary(MAX) NOT NULL,
	Name nvarchar(MAX) NOT NULL
)

--drop table Users

INSERT INTO Users
(Username, PasswordSalt, PasswordHash,Name)
VALUES
('anon123',0x576A021C3009722B7D60FA8BF46C0DC3CC39883C076A254741C694490E39CF58,0xD752B6BFCD5AF7285C9431B08487B39D3BD74979F695F9B1FD54731B0E3AB25F,'Anonymous'),
('gfrancoa',0x02DF1A478DA5E63CA3AF050FF2C44A22C21FF2007C269E6B0B8BB1F98DA91699,0x41E9EBDBD554B45519B48895B7270320C91B7CEDFA8C6C6D7D8437B02B980316,'Gabriela'),
('ssmisth',0xEAF63E6EBAB490C60760EA2BDF497C8522778CE4F84355D50F7F54291F0B1A2F,0x533CE3D84290F381CCFBB8019B09D187F73CAD24B2EE613873C263A5FE89F80C,'Sam')
