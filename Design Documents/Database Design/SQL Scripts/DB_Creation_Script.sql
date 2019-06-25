USE MASTER;
GO

DROP database IF EXISTS JourneyDB;
GO

CREATE DATABASE JourneyDB;
GO

USE JourneyDB;
GO

-- Identity Tables
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
*/

CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL unique,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO

CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO

CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO

CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO

CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO


-- Journey Tables

CREATE TABLE Traveler (
	ID bigint NOT NULL identity(1,1) primary key,
	FirstName nvarchar(40),
	LastName nvarchar(40),
	Phone nvarchar(20),
	DOB date,
	Gender char,
	Email2 nvarchar(40),
	AboutMe nvarchar(2000),
	Occupation nvarchar(100),
	Hobbies nvarchar(1000),
	SocialMedia nvarchar(1000),
	DateCreated datetime NOT NULL,
	UserID nvarchar(450) unique,
	Foreign Key (UserID) references AspNetUsers(Id)
);
GO

CREATE TABLE TravelerRelationships (
	TravelerID1 bigint NOT NULL,
	TravelerID2 bigint NOT NULL,
	Relationship nvarchar(40) NOT NULL,
	isFollower bit default 0 NOT NULL,
	isEmergencyContact bit default 0 NOT NULL,
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
	isCurrent bit default 0 NOT NULL, 
	hasLived bit default 0 NOT NULL, 
	hasVisited bit default 0 NOT NULL, 
	wantVisit bit default 0 NOT NULL, 
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
	Thumbnail nvarchar(1000),
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
	Thumbnail nvarchar(1000),
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
