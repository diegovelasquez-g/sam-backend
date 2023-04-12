CREATE DATABASE SAM
GO
USE SAM
GO
create table Users (
	UserId int IDENTITY(1,1) not null PRIMARY KEY,
	RoleId int not null,
	IsActive bit not null,
	FullName varchar(50),
	UserName varchar(50) not null,
	Email varchar(50) not null,
	Password varchar(max) not null,
	ProfilePicture varchar(max),
	PhoneNumber varchar(8),
	Token varchar(max),
	CreatedDate datetime  not null,
	ModifiedDate datetime 
)

create table Roles(
	RoleId int IDENTITY(1,1) not null PRIMARY KEY,
	RoleName varchar(50) not null,
	CreatedDate datetime  not null,
	ModifiedDate datetime ,
	IsActive bit not null
)

CREATE TABLE Addresses(
	AddressId int IDENTITY(1,1) not null PRIMARY KEY,
	UserId int not null,
	Municipality varchar(50) not null,
	Department varchar(50) not null,
	AddressLine1 varchar(max) not null,
	IsActive bit not null
)

CREATE TABLE Products(
	ProductId int IDENTITY(1,1) not null PRIMARY KEY,
	ProductName varchar(50) not null,
	Description varchar(200),
	ProductCode varchar(20) not null,
	UnitPrice DECIMAL(19,4) not null,
	DiscountId int not null,
	ProductImage varchar(max),
	StatusId int not null,
	CreatedDate datetime  not null,
	ModifiedDate datetime ,
)

CREATE TABLE Categories(
	CategoryId int IDENTITY(1,1) not null PRIMARY KEY,
	CategoryName varchar(50) not null,
	Description varchar(200),
	IsActive bit not null,
	CreatedDate datetime  not null,
	ModifiedDate datetime ,
)

CREATE TABLE Products_Categories(
	Id int PRIMARY KEY IDENTITY(1,1) not null,
	CategoryId int not null,
	ProductId int not null
)

CREATE TABLE Discounts(
	DiscountId int PRIMARY KEY IDENTITY(1,1) not null,
	DiscountName varchar(50) not null,
	Description varchar(200),
	Percentage DECIMAL(3,2),
	IsActive bit not null,
	CreatedDate datetime  not null,
	ModifiedDate datetime ,
)

CREATE TABLE Inventories(
	InventoryId int PRIMARY KEY IDENTITY(1,1) not null,
	ProductId int not null UNIQUE,
	InitialStock int not null,
	CurrentStock int not null,
	EntryDate datetime  not null,
	WithdrawalDate datetime ,
	CreatedDate datetime  not null,
	ModifiedDate datetime ,
)

CREATE TABLE Providers(
	ProviderId int PRIMARY KEY IDENTITY(1,1) not null,
	ProviderName varchar(50) not null,
	Description varchar(200),
	Country varchar(50) not null,
	IsActive bit not null,
	CreatedDate datetime  not null,
	ModifiedDate datetime ,
)

CREATE Table Products_Providers(
	Id int PRIMARY KEY IDENTITY(1,1) not null,
	ProductId int not null,
	ProviderId int not null
)

CREATE TABLE Carts(
	CartId int PRIMARY KEY IDENTITY(1,1) not null,
	UserId int not null,
	ExpirationDate datetime ,
	CreatedDate datetime  not null,
	TotalPrice DECIMAL(19,4) not null,
)

CREATE TABLE CartsItems(
	CartItemId int PRIMARY KEY IDENTITY(1,1) not null,
	CartId int not null,
	ProductId int not null,
	ItemQuantity int not null,
	ItemTotal DECIMAL(19,4) not null
)


CREATE TABLE Sales(
	SaleId int IDENTITY(1,1) not null PRIMARY KEY,
	SaleCode varchar(20) not null,
	UserId int not null,
	SaleDate datetime  not null
)

CREATE TABLE SalesItems(
	SaleItemId int PRIMARY KEY IDENTITY(1,1) not null,
	SaleId int not null,
	ProductId int not null,
	ItemQuantity int not null,
	DiscountId int not null,
	ItemTotal DECIMAL(19,4) not null
)

CREATE TABLE Payments(
	PaymentId int PRIMARY KEY IDENTITY(1,1) not null,
	SaleId int not null UNIQUE,
	TotalPrice DECIMAL(19,4)  not null,
	StatusId int not null,
	PaymentDate datetime  not null,
	PaymentMethodId int not null
)

CREATE TABLE PaymentsMethods(
	PaymentMethodId int PRIMARY KEY IDENTITY(1,1) not null,
	Method varchar(50) not null,
	IsActive bit not null,
	StatusId int not null,
	PaymentDate datetime  not null,
	CreatedDate datetime  not null,
	ModifiedDate datetime ,
)


CREATE TABLE Deliveries(
	DeliveryId int IDENTITY(1,1) PRIMARY KEY not null,
	DeliveryMethodId int not null,
	AddressId int,
	StatusId int not null,
	DueDate datetime ,
	TrackingNumber varchar(20) not null,
	SaleId int not null UNIQUE
)

CREATE TABLE DeliveriesMethods(
	DeliveryMethodId int IDENTITY(1,1) PRIMARY KEY not null,
	Method varchar(50) not null,
	IsActive bit not null,
	CreatedDate datetime  not null,
	ModifiedDate datetime ,
)

CREATE TABLE Status(
	StatusId int IDENTITY(1,1) not null PRIMARY KEY,
	StatusName varchar(50) not null,
	StatusType varchar(20) not null,
	description varchar(200),
	IsActive bit not null,
	CreatedDate datetime  not null
)

ALTER TABLE Users
ADD FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)

ALTER TABLE Addresses
ADD FOREIGN KEY (UserId) REFERENCES Users(UserId)

ALTER TABLE Products
ADD FOREIGN KEY (StatusId) REFERENCES Status(StatusId)

ALTER TABLE Products
ADD FOREIGN KEY (DiscountId) REFERENCES Discounts(DiscountId)

ALTER TABLE Products_Categories
ADD FOREIGN KEY (ProductId) REFERENCES Products(ProductId)

ALTER TABLE Products_Categories
ADD FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)

ALTER TABLE Inventories
ADD FOREIGN KEY (ProductId) REFERENCES Products(ProductId)

ALTER TABLE Deliveries
ADD FOREIGN KEY (StatusId) REFERENCES Status(StatusId)

ALTER TABLE Products_Providers
ADD FOREIGN KEY (ProductId) REFERENCES Products(ProductId)

ALTER TABLE Products_Providers
ADD FOREIGN KEY (ProviderId) REFERENCES Providers(ProviderId)

ALTER TABLE Carts
ADD FOREIGN KEY (UserId) REFERENCES Users(UserId)

ALTER TABLE CartsItems
ADD FOREIGN KEY (CartId) REFERENCES Carts(CartId)

ALTER TABLE CartsItems
ADD FOREIGN KEY (ProductId) REFERENCES Products(ProductId)

ALTER TABLE Sales
ADD FOREIGN KEY (UserId) REFERENCES Users(UserId)

ALTER TABLE SalesItems
ADD FOREIGN KEY (SaleId) REFERENCES Sales(SaleId)

ALTER TABLE SalesItems
ADD FOREIGN KEY (ProductId) REFERENCES Products(ProductId)

ALTER TABLE Payments
ADD FOREIGN KEY (SaleId) REFERENCES Sales(SaleId)

ALTER TABLE Payments
ADD FOREIGN KEY (PaymentMethodId) REFERENCES PaymentsMethods(PaymentMethodId)

ALTER TABLE Payments
ADD FOREIGN KEY (StatusId) REFERENCES Status(StatusId)

ALTER TABLE Deliveries
ADD FOREIGN KEY (DeliveryMethodId) REFERENCES DeliveriesMethods(DeliveryMethodId)

ALTER TABLE Deliveries
ADD FOREIGN KEY (SaleId) REFERENCES Sales(SaleId)

ALTER TABLE Deliveries
ADD FOREIGN KEY (AddressId) REFERENCES Addresses(AddressId)



