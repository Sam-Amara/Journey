USE MASTER;
GO

DROP database IF EXISTS JourneyDB;
GO


CREATE DATABASE JourneyDB;
GO

USE JourneyDB;
GO

CREATE TABLE Traveler (
	ID bigint NOT NULL identity(1,1) primary key,
	FirstName nvarchar(40),
	LastName nvarchar(40),
	Phone nvarchar(20),
	DOB date,
	Gender char,
	Email nvarchar(40) NOT NULL unique,
	Email2 nvarchar(40),
	AboutMe nvarchar(2000),
	Occupation nvarchar(100),
	Hobbies nvarchar(1000),
	SocialMedia nvarchar(1000),
	Pass binary(64) NOT NULL,
	DateCreated datetime NOT NULL
);
GO

CREATE TABLE TravelerRelationships (
	TravelerID1 bigint NOT NULL,
	TravelerID2 bigint NOT NULL,
	Relationship nvarchar(40) NOT NULL,
	isFollower bit default 0,
	isEmergencyContact bit default 0,
	StartDate datetime,
	Primary Key (TravelerID1, TravelerID2),
	Foreign Key (TravelerID1) references Traveler(ID),
	Foreign Key (TravelerID2) references Traveler(ID)
);
GO

CREATE TABLE Trip (
	ID bigint NOT NULL identity(1,1) primary key,
	TripName nvarchar(100) NOT NULL,
	StartDate datetime,
	EndDate datetime,
	Descript nvarchar(2000),
	DateCreated datetime NOT NULL
);
GO

CREATE TABLE TravelersTrips (
	TripID bigint NOT NULL,
	TravelerID bigint NOT NULL,
	Primary Key (TripID, TravelerID),
	Foreign Key (TripID) references Trip(ID),
	Foreign Key (TravelerID) references Traveler(ID)
); 
GO

CREATE TABLE City (
	ID int NOT NULL identity(1,1) primary key,
	CityName nvarchar(40) NOT NULL,
	Country nvarchar(40) NOT NULL,
	CityState nvarchar(40)
);
GO

CREATE TABLE TravelersCities (
	ID bigint NOT NULL identity(1,1) primary key,
	StartDate datetime,
	EndDate datetime,
	TravelerAddress nvarchar(200),
	isCurrent bit default 0, 
	hasLived bit default 0, 
	hasVisited bit default 0, 
	wantVisit bit default 0, 
	TravelerID bigint NOT NULL,
	CityID int NOT NULL,
	Foreign Key (CityID) references City(ID),
	Foreign Key (TravelerID) references Traveler(ID)
); 
GO

CREATE TABLE TripCities (
	ID bigint NOT NULL identity(1,1) primary key,
	StartDate datetime NOT NULL,
	EndDate datetime NOT NULL,
	Note nvarchar(2000),
	CityID int NOT NULL,
	TripID bigint NOT NULL,
	Foreign Key (CityID) references City(ID),
	Foreign Key (TripID) references Trip(ID)
); 
GO

CREATE TABLE TripDetails (
	ID bigint NOT NULL identity(1,1) primary key,
	Accomodation nvarchar(200) NOT NULL,
	AccomodationDetails nvarchar(1000),
	InboundTransportation nvarchar(20) NOT NULL,
	InboundTransportationDetails nvarchar(1000),
	OutboundTransportation nvarchar(20) NOT NULL,
	OutboundTransportationDetails nvarchar(1000),
	TripCitiesID bigint NOT NULL,
	Foreign Key (TripCitiesID) references TripCities(ID)
); 
GO

CREATE TABLE TripActivities (
	ID bigint NOT NULL identity(1,1) primary key,
	Activity nvarchar(200) NOT NULL,
	ActivityDate datetime,
	ActivityType nvarchar(20),
	Cost money,
	Currency nvarchar(10),
	Note nvarchar(2000),
	TripDetailsID bigint NOT NULL,
	Foreign Key (TripDetailsID) references TripDetails(ID)
); 
GO

CREATE TABLE TravelerAlbum (
	ID bigint NOT NULL identity(1,1) primary key,
	AlbumName nvarchar(200) NOT NULL,
	Thumbnail varbinary(max),
	Descript nvarchar(2000),
	DateCreated datetime NOT NULL,
	TripID bigint,
	TravelerID bigint NOT NULL,
	Foreign Key (TripID) references Trip(ID),
	Foreign Key (TravelerID) references Traveler(ID)
); 
GO

CREATE TABLE TravelerPhoto (
	ID bigint NOT NULL identity(1,1) primary key,
	PhotoName nvarchar(200),
	Thumbnail varbinary(max),
	FilePath nvarchar(1000) NOT NULL unique,
	Loc nvarchar(100),
	DateAdded datetime NOT NULL
); 
GO

CREATE TABLE AlbumPhoto (
	AlbumID bigint NOT NULL,
	PhotoID bigint NOT NULL,
	SequenceNumber int NOT NULL,
	DateAdded datetime NOT NULL,
	Primary Key (AlbumID, PhotoID),
	Foreign Key (AlbumID) references TravelerAlbum(ID),
	Foreign Key (PhotoID) references TravelerPhoto(ID)
); 
GO
