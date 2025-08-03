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
	string name = "Tokyo";
	string country = "Japan";
	string timeZone = "JST";
	decimal? latitude = 35.6764m;
	decimal? longitude = 139.6500m;
	
	AddDestination(name, country, latitude, longitude, timeZone);
	Destinations.Dump();	
	
}

// You can define other methods, fields, classes and namespaces here


public void AddDestination(string cityName, string country, decimal? latitude, decimal? longitude, string timeZone) { 
	
	Destination newDest = new Destination();


	try {
		newDest.CityName = cityName;
		newDest.Country = country;
		newDest.Latitude = latitude;
		newDest.Longitude = longitude;
		newDest.TimeZone = timeZone;
		
		Destinations.Add(newDest);
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