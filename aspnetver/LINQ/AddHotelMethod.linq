<Query Kind="Program">
  <Connection>
    <ID>a379cd13-5206-42dd-9f87-c29822f29958</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>localhost</Server>
    <Database>TravelGuideV1</Database>
    <AlphabetizeColumns>true</AlphabetizeColumns>
    <DisplayName>TravelGuideV1</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{

	string hotelName = "Shinjuku Granbell Hotel";
	string address = "2 Chome-14-5 Kabukicho, Shinjuku City, Tokyo 160-0021, Japan";
	string hotelType = "Hotel";
	string notes = "preferred hotel, long stay discount";
	decimal pricePerNight = 200;
	decimal totalPriceOfStay = 4500;
	string city = "Tokyo";
	
	AddHotel(hotelName, address, hotelType, notes, pricePerNight, totalPriceOfStay, city);
	Destinations.Dump();
	Hotels.Dump();
		
	
}



public void AddHotel(string hotelName, string address, string hotelType, string notes, decimal pricePerNight, decimal totalPriceOfStay, string city){

	try{
		Hotel newHotel = new Hotel();
		newHotel.HotelName = hotelName;
		newHotel.HotelAddress = address;
		newHotel.HotelType = hotelType;
		newHotel.Notes = notes;
		newHotel.PricePerNight = pricePerNight;
		newHotel.TotalPriceOfStay = totalPriceOfStay;
		newHotel.DestinationID = Destinations.Where(x => x.CityName == "Tokyo")
									.Select(x => x.DestinationID)
									.FirstOrDefault();
		Hotels.Add(newHotel);
		SaveChanges();	
	}
	catch(Exception ex) {
		GetInnerException(ex).Message.Dump();
	}
}


public Exception GetInnerException (Exception ex) {
		while(ex.InnerException != null){
			ex = ex.InnerException;
		}
		return ex;
}