Create Table Customers(
	CustomerId int IDENTITY(1,1),
	CustomerName NVARCHAR(100) NOT NULL,
	EmailAddress NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_CustomerId PRIMARY KEY CLUSTERED (CustomerId)
);