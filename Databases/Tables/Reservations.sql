Create Table Reservations(
	ReservationId int IDENTITY(1,1),
	PartySize int NOT NULL, 
	CustomerId int NULL,
	RestaurantId int NOT NULL,
	TimeSlotSection tinyint NOT NULL, 
	CONSTRAINT PK_ReservationId PRIMARY KEY CLUSTERED (ReservationId),
	CONSTRAINT FK_Reservations_Restaurants FOREIGN KEY (RestaurantId) REFERENCES Restaurants(RestaurantId),
	CONSTRAINT FK_Reservations_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);