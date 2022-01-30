Create Table Restaurants(
	RestaurantId int IDENTITY(1,1),

	--jimmy maybe look into check constraints for number of time slots
	CONSTRAINT PK_RestaurantId PRIMARY KEY CLUSTERED (RestaurantId),
);