Create Table Reservations(
	ReservationId int IDENTITY(1,1),
	TimeslotId int NOT NULL,
	PartySize int NOT NULL, 
	CustomerId int NULL, 
	CONSTRAINT PK_ReservationId PRIMARY KEY CLUSTERED (ReservationId),
	CONSTRAINT FK_Reservations_Timeslots FOREIGN KEY (TimeslotId) REFERENCES Timeslots(TimeslotId),
	CONSTRAINT FK_Reservations_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);