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






