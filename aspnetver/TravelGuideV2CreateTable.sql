create table ListOfGuides ( 
	GuideID int not null identity(1,1) primary key,
	GuideName nvarchar(250),
	City nvarchar(250),
	DateCreated Date,
)
--
create table Guides(
	GuideID int foreign key references ListOfGuides(GuideID),
	PointOfInterest nvarchar(250),
	PoiAddress nvarchar(250),
	PoiType nvarchar(250),
	ThingsToKnow nvarchar(250),
	Importance nvarchar(250),
)

