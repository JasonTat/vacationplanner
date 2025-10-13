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
	//display all guides fetch
	IEnumerable<Guide> guideList = null;
	//IEnumerable because i only need to read/display it , not manipulate the list.
	
	try {
		guideList = FetchGuideLists();
		guideList.Dump();
	}
	catch(Exception ex) {
		GetInnerException(ex).Message.Dump();
	}

}

// You can define other methods, fields, classes and namespaces here



public class Guide {
   public int GuideID {get;set;}
   public string GuideName {get;set;}
   public string Description {get;set;}
   public int POICount {get;set;}
   public DateTime? DateCreated {get;set;}
   public DateTime? DateModified {get;set;}
}


public List<Guide> FetchGuideLists() {
	
	IEnumerable<Guide> guideList = null;
	
	guideList = Guides
					.Where(x => x.GuideID == 1)
					.Select(x => new Guide { 
						GuideID = x.GuideID,
						GuideName = x.GuideName,
						Description = x.GuideDescription,
						POICount = Guides
										.Where(x => x.GuideID == 1)
										.Count(),
						DateCreated = x.DateCreated,
						DateModified = x.DateModified

					});

	
	if(guideList == null){
		throw new AggregateException("No guides to display.");
	}
	else{
		return guideList.ToList();
	}
}



private Exception GetInnerException (Exception ex) {
	while(ex.InnerException != null){
		ex = ex.InnerException;
	}
	return ex;
}