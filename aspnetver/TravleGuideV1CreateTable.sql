create database TravelGuideV1

use TravelGuideV1

create table Destination(
	DestinationID int not null identity(1,1),
	CityName nvarchar(50) not null,
	Country nvarchar (50) not null,
	TimeZone nvarchar(50),
	Latitude decimal,
	Longitude decimal,
	primary key (DestinationID)
);

create table PointOfInterest(
	PoiID int not null identity(1,1),
	PoiName nvarchar(100) not null,
	Description nvarchar(255), 
	Type nvarchar(255),
	DestinationID int not null,
	primary key (PoiID),
	foreign key (DestinationID) references Destination(DestinationID)


);

create table Hotel( 
	HotelID int not null identity(1,1),
	HotelName nvarchar(255) not null,
	HotelAddress nvarchar(255) not null,
	DestinationID int not null,
	PricePerNight decimal not null,
	TotalPriceOfStay decimal,
	HotelType nvarchar(255) not null,
	Notes nvarchar(500)
	primary key (HotelID),
	foreign key (DestinationID) references Destination(DestinationID)


)



