--DROP TABLE Restaurants
--DROP TABLE Timeslots
--DROP TABLE Reservations

begin tran

	--DROP TABLE Customers
	--DROP TABLE Reservations
	--DROP TABLE Timeslots
	--DROP TABLE Restaurants

	--insert into Restaurants values()

	select * from Restaurants

--commit
rollback


INSERT INTO Restaurants DEFAULT VALUES


select * from sys.indexes
where object_id = (select object_id from sys.objects where name = 'Reservations')



https://stackoverflow.com/questions/19375579/how-to-check-if-value-is-inserted-successfully-or-not
Jimmy this is goood for the updating of reservation
update rese
set rese.CustomerId = 100
from Reservations rese
where rese.ReservationId = 100
print  @@ROWCOUNT 


update res
SET res.CustomerId = @CustomerId
FROM Reservations res
WHERE res.RestaurantId = @RestaurantId
	AND res.CustomerId = NULL
	AND res.PartySize = @PartySize
	AND res.TimeSlotSection = @TimeSlotSection
PRINT  @@ROWCOUNT


SELECT c.CustomerId FROM Customers c
WHERE c.CustomerName = @CustomerName
AND c.EmailAddress = @EmailAddress