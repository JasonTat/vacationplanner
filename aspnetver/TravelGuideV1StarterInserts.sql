select * from Destination
select * from Hotel
select * from PointOfInterest

--


insert into Destination(CityName, Country, TimeZone)
values('LosAngeles', 'USA', 'PST');

insert into Hotel(HotelName, HotelAddress, DestinationID, PricePerNight, TotalPriceOfStay, HotelType)
values(
	'AirBnB',
	'3653 Chariette Avenue Rosemead, CA 91770',
	(select DestinationID from Destination where CityName = 'LosAngeles'),
	144,
	2159.14,
	'AirBnB'
)

insert into PointOfInterest(PoiName, Description, Type, DestinationID)
values(
	'Los Angeles County Museum of Art',
	'Art Museum',
	'Museum',
	(select DestinationID from Destination where CityName = 'LosAngeles')
)