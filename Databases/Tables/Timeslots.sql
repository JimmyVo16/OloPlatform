Create Table Timeslots(
	TimeslotId int IDENTITY(1,1),
	RestaurantId int NOT NULL,
	--Hour + 15 section
	--Example 7:15 AM 071, 3:30 PM 152
	TimeSlotSection tinyint NOT NULL, 
	CONSTRAINT PK_TimeslotId PRIMARY KEY CLUSTERED (TimeslotId),
	CONSTRAINT FK_Timeslots_Restaurants FOREIGN KEY (RestaurantId) REFERENCES Restaurants(RestaurantId)
);

--jimmy look into the timeranage enum constrainst table