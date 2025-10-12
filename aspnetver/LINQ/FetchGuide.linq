<Query Kind="Expression">
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

Guides
	.Where(x => x.GuideID == 1)
	.Select(x => new {
		GuideID = x.GuideID,
		GuideName = x.GuideName,
		POINames = x.PointsOfInterests
							.Select(p => new {
								POIID = p.POIID,
								GuideID = p.GuideID,
								POIName = p.POIName,
								Address = p.POIAddress,
								Type = p.POIType,
								ThingsToKnow = p.ThingsToKnow,
								Importance = p.Importance
							}).ToList()
	})