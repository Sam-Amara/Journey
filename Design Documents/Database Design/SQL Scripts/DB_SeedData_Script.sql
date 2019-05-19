USE JourneyDB;
GO

-- insert users in identity table

INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'520225c8-f527-4b99-b95a-54af9a0f6a7a', N'strawbery.s188@outlook.com', N'STRAWBERY.S188@OUTLOOK.COM', N'strawbery.s188@outlook.com', N'STRAWBERY.S188@OUTLOOK.COM', 0, N'AQAAAAEAACcQAAAAEHd3q7Jcu+6Nh4/jdJZJL9uore0Gwis+1frICTIvIJxU1gODR2FouZdQcg9QssTKaA==', N'AN3A7OH3YV3GLNYIAFQHRP6NU3CREFQR', N'c0fd2b9c-ca20-4b80-9fcc-3dad58fbbda4', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'765bc982-719e-4b42-b380-fd9ec5e97c31', N'amaramas@my.erau.edu', N'AMARAMAS@MY.ERAU.EDU', N'amaramas@my.erau.edu', N'AMARAMAS@MY.ERAU.EDU', 0, N'AQAAAAEAACcQAAAAEFwwIKSAuRTCW1E14w/gNXReR2W9HFiRJsq1MzdSqdwDILBsKG9W+/mJdarIkZxDQA==', N'HGHH2QP5MSNBGEFFGXXRR76WBQFVYWQL', N'9a6a8060-51bd-490c-803c-d46546cca3c6', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'799137c4-0989-4f5e-9296-153154b4817d', N'rick@ricksteve.com', N'RICK@RICKSTEVE.COM', N'rick@ricksteve.com', N'RICK@RICKSTEVE.COM', 0, N'AQAAAAEAACcQAAAAECkAKdzqgS16/qNiACwf2bzhkqNfHSvJurw8kifeayrdPh0q/DYLWbhCZvc20E6EGA==', N'4QF4MA2JVOGV5NDWK3NMFAE2QCG6Y7YX', N'6cd8c6a9-e7b6-4bd5-81a0-6785417bcea2', NULL, 0, 0, NULL, 1, 0)
GO

-- insert data in journey tables

INSERT INTO Traveler (FirstName, LastName, phone, DOB, Gender, UserID, DateCreated)
VALUES
    ('Sam','Amara', '+1 910-797-4201', '1986-09-27', 'M', 
	  'amaramas@my.erau.edu', getdate()),
    ('Sandra','Fellouh', '+1 910-257-0506', '1990-12-18', 'F', 
	  'strawbery.s188@outlook.com', getdate()),
    ('Rick','Steves', '+1 425-771-8303', '1955-05-10', 'M', 
	  'rick@ricksteve.com', getdate());
GO

INSERT INTO TravelerRelationships (TravelerID1, TravelerID2, Relationship, isFollower, isEmergencyContact, StartDate)
VALUES
	(1, 2, 'Wife', 1, 1, getdate()),
	(2, 1, 'Husband', 1, 1, getdate()),
	(1, 3, 'Follower', 1, 0, getdate());
GO

INSERT INTO Trip (TripName, StartDate, EndDate, DateCreated)
VALUES
    ('Mediterranean Cruise','2017-05-09', '2017-05-23', getdate()),
    ('European Road Trip','2010-04-01', '2010-04-21', getdate());
GO

INSERT INTO TravelersTrips(TripID, TravelerID)
VALUES
	(1,1),
	(1,2),
	(2,3);
GO

INSERT INTO City(CityName, Country, CityState)
VALUES
	('Fayetteville','USA', 'North Carolina'),
	('Edmonds','USA', 'Washington'),
	('Milan','Italy', null),
	('Venice','Italy', null),
	('Rome','Italy', null),
	('Athens','Greece', null),
	('Paris', 'France', null),
	('Lyon', 'France', null);
GO

INSERT INTO TravelersCities(StartDate, TravelerAddress, isCurrent, hasLived, TravelerID, CityID)
VALUES
	('2017-08-17', '4341 Ridge Pointe', 1, 1, 1, 1),
	('2004-01-01', '81 Rue Lauriston', 1, 1, 1, 7),
	('2017-08-17', '4341 Ridge Pointe', 1, 1, 2, 1),
	('2005-02-01', '130 4th Ave N', 1, 1, 3, 2);
GO

INSERT INTO TravelersCities(StartDate, EndDate, hasVisited, TravelerID, CityID)
VALUES
	('2017-05-09', '2017-05-11', 1, 1, 3),
	('2017-05-09', '2017-05-11', 1, 2, 3),
	('2017-05-20', '2017-05-23', 1, 1, 5),
	('2017-05-20', '2017-05-23', 1, 2, 5),
	('2010-04-01', '2010-04-07', 1, 3, 7);
GO

INSERT INTO TravelersCities(StartDate, wantVisit, TravelerID, CityID)
VALUES
	('2019-12-01', 1, 1, 7),
	('2019-12-01', 1, 2, 7);
GO

INSERT INTO TripCities(StartDate, EndDate, CityID, TripID)
VALUES
	('2017-05-09', '2017-05-11', 3, 1),
	('2017-05-11', '2017-05-13', 4, 1),
	('2017-05-13', '2017-05-20', 6, 1),
	('2017-05-20', '2017-05-23', 5, 1),
	('2010-04-01', '2010-04-07', 7, 2),
	('2010-04-07', '2010-04-14', 8, 2),
	('2010-04-14', '2010-04-21', 5, 2);
GO

INSERT INTO TripDetails(Accomodation, InboundTransportation, OutboundTransportation, TripCitiesID)
VALUES
	('Hotel', 'Plane', 'Train', 1),
	('Hotel', 'Train', 'Boat', 2),
	('Cruise', 'Boat', 'Boat', 3),
	('Hotel', 'Boat', 'Plane', 4),
	('Airbnb', 'Plane', 'Car', 5),
	('Hotel', 'Car', 'Car', 5),
	('Hotel', 'Car', 'Train', 6),
	('Friends', 'Train', 'Plane', 7);
GO

INSERT INTO TripActivities(Activity, ActivityType, TripDetailsID)
VALUES
	('Duomo', 'Landmark', 1),
	('Casa Fontana', 'Restaurant', 1),
	('Sforzesco Castle', 'Landmark', 1);
GO

INSERT INTO TravelerAlbum(AlbumName, TripID, TravelerID, DateCreated)
VALUES
	('Cruise Best Pics', 1, 1, getdate()),
	('My Cruise Pics', 1, 2, getdate()),
	('Milano Pics', 1, 1, getdate());
GO

INSERT INTO TravelerPhoto(FilePath, Loc,  DateAdded)
VALUES
	('Resources/1/pic1.jpg', 'Venice', getdate()), 
	('Resources/1/pic2.jpg', 'Milan', getdate()),
	('Resources/1/pic3.jpg', 'Venice', getdate()),
	('Resources/1/pic4.jpg', 'Venice', getdate());
GO

INSERT INTO AlbumPhoto(AlbumID, PhotoID, SequenceNumber,DateAdded)
VALUES
	(1, 1, 1, getdate()), 
	(1, 2, 3, getdate()),
	(1, 3, 4, getdate()),
	(1, 4, 2, getdate());
