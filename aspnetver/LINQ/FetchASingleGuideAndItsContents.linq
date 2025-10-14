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
	
	//display a single guide w/ its list of poi
	
	try{
		Guide displayGuide = null;
		displayGuide = FetchASingleGuideAndItsContents(1);
		displayGuide.Dump();
	
	
	}
	catch(Exception ex){
		GetInnerException(ex).Message.Dump();
	}
	
}

// You can define other methods, fields, classes and namespaces here


public class Guide { 
   public int GuideID {get;set;}
   public string GuideName {get;set;} 
   public string Description {get;set;}
   public List<PointsOfInterest> PointsOfInterestList {get;set;}
} 

public class PointsOfInterest {
   public int POIID {get;set;}
   public int GuideID {get;set;}
   public string POIName {get;set;}
   public string POIAddress {get;set;}
   public string Type {get;set;} 
   public string ThingsToKnow {get;set;}
   public string Importance {get;set;} 
}

public Guide FetchASingleGuideAndItsContents(int guideID) {

	Guide fetchGuide = null;
	List<PointsOfInterest> poiListForASingleGuide = null;
	//poiListForASingleGuide = PointsOfInterests
	//							.Where(x => x.GuideID == guideID)
	//							.Select(x => new PointsOfInterest {
	//								POIID = x.POIID,
	//								GuideID = guideID,
	//								POIName = x.POIName,
	//								POIAddress = x.POIAddress,
	//								Type = x.POIType,
	//								ThingsToKnow = x.ThingsToKnow,
	//								Importance = x.Importance
	//							
	//							}).ToList();
	fetchGuide = Guides
					.Where(x => x.GuideID == guideID)
					.Select(x => new Guide{
						GuideID = guideID,
						GuideName = x.GuideName,
						Description = x.GuideDescription,
						PointsOfInterestList = PointsOfInterests
													.Where(x => x.GuideID == guideID)
													.Select(x => new PointsOfInterest {
														POIID = x.POIID,
														GuideID = guideID,
														POIName = x.POIName,
														POIAddress = x.POIAddress,
														Type = x.POIType,
														ThingsToKnow = x.ThingsToKnow,
														Importance = x.Importance
													
													}).ToList()
					}).FirstOrDefault();

	
	
	
	return fetchGuide;

	

}







private Exception GetInnerException (Exception ex) {
	while(ex.InnerException != null){
		ex = ex.InnerException;
	}
	return ex;
}