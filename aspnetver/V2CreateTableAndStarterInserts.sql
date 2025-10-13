create table Guides (
	GuideID int not null identity(1,1) primary key,
	GuideName nvarchar(250),
	GuideDescription nvarchar(250)
)

create table PointsOfInterest(
	POIID int not null identity(1,1) primary key,
	GuideID int foreign key references Guides(GuideID),
	POIName nvarchar(250),
	POIAddress nvarchar(250),
	POIType nvarchar(250),
	ThingsToKnow nvarchar(1000),
	Importance nvarchar(250)
)


insert into Guides (GuideName,  GuideDescription)
values('Tokyo', 'Trip to Tokyo')
insert into Guides (GuideName,  GuideDescription)
values('Mexico City', 'Trip to Mexico')


insert into PointsOfInterest(GuideID, POIName, POIAddress, POIType, ThingsToKnow, Importance)
values ((select GuideID from guides where guidename = 'Tokyo'), 'Skytree', '123 Address', 'Sightseeing/Attraction', 'filler', 'Must see')

insert into PointsOfInterest(GuideID, POIName, POIAddress, POIType, ThingsToKnow, Importance)
values ((select GuideID from guides where guidename = 'Mexico City'),'MexicoPOI', '123 Address', 'Sightseeing/Attraction', 'filler', 'Must see')

select * from guides
select * from pointsofinterest

alter table Guides
add DateCreated DateTime

alter table Guides
add DateModified DateTime