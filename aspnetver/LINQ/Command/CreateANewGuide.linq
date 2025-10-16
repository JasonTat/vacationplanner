<Query Kind="Program">
  <Connection>
    <ID>f4cf9ec9-9a90-44db-85b9-596f0dcdc017</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>localhost</Server>
    <Database>TravelGuideV2</Database>
    <AlphabetizeColumns>true</AlphabetizeColumns>
    <DisplayName>TravelGuideV2</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	//create a new guide
	
	
	string guideName = "Vietnam";
	string guideDescr = "A trip to Vietnam";
	
	CreateANewGuide(guideName, guideDescr);
	
	
}

// You can define other methods, fields, classes and namespaces here



public void CreateANewGuide (string guideName, string guideDescr) {
	
	Guides newGuideToBeCreated = new Guides();
	newGuideToBeCreated.GuideName = guideName;
	newGuideToBeCreated.GuideDescription = guideDescr;
	newGuideToBeCreated.DateCreated = DateTime.Now;
	Guides.Add(newGuideToBeCreated);
	
	Guides.Dump();
	SaveChanges();
	Guides.Dump();
}