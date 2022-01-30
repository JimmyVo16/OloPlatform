Create Table Reservations(
	ReservationId int IDENTITY(1,1),
	TimeslotId int NOT NULL,
	PartySize int NOT NULL, 
	CustomerId int NULL, 
	CONSTRAINT PK_ReservationId PRIMARY KEY CLUSTERED (ReservationId),
	CONSTRAINT FK_Reservations_Timeslots FOREIGN KEY (TimeslotId) REFERENCES Timeslots(TimeslotId),
	CONSTRAINT FK_Reservations_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);
--Jimmy maybe look into customer name

-- jimmy story time. have the customer email and name as an indicator if the slot is available. 
-- Because the resturant have to clear it out each night. It might 

update rv 
set rv.
FROM Restaurants rt
INNER JOIN Timeslots slot
ON slot.RestaurantId = rt.RestaurantId
INNER JOIN Reservations rv
ON rv.TimeslotId = slot.TimeslotId
WHERE rv.PartySize = @PartySize
AND rv.IsAvailable = 1