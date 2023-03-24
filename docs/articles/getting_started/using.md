## Using Darwin.Net

To get started, this single line of code will give you access to all the requests that Darwin.Net can make:

```csharp
Darwin.Net.Darwin darwin = new Darwin.Net.Darwin();
```

From here, you are able to call some of the following requests:

##### Get up to 10 arrivals at a station for the next 90 minutes
```csharp
int maxArrivals = 10;
Station station = Station.LondonBridge;
TimeSpan timeWindow = TimeSpan.FromMinutes(90);

StationBoard response = await darwin.Requests.GetArrivalBoardAsync(maxArrivals, station, timeWindow);
```

##### Get up to 5 departures at a station within the last hour with specific calling points
```csharp
int maxArrivals = 5;
Station station = Station.GlasgowCentral;
TimeSpan timeWindow = TimeSpan.FromMinutes(60);
TimeSpan offset = TimeSpan.FromMinutes(-60);

StationBoardWithDetails response = await darwin.Requests.GetDepartureBoardWithDetailsAsync(maxArrivals, station, timeWindow, timeOffset: offset);
```

##### Get the next fastest services from a station to a list of station within the next 30 minutes
```csharp
Station station = Station.LondonEuston;
List<Station> stationList = new List<Station>() {
  Station.Coventry,
  Station.WatfordJunction,
  Station.MiltonKeynesCentral
};
TimeSpan timeWindow = TimeSpan.FromMinutes(30);

DeparturesBoardWithDetails response = await darwin.Requests.GetFastestDeparturesWithDetailsAsync(station, stationList, timeWindow);
```

##### Get specific services details
```csharp
int maxArrivals = 5;
Station station = Station.GlasgowCentral;
TimeSpan timeWindow = TimeSpan.FromMinutes(60);
TimeSpan offset = TimeSpan.FromMinutes(-60);

StationBoard response = await darwin.Requests.GetArrivalBoardAsync(maxArrivals, station, timeWindow, timeOffset: offset);
ServiceDetails service = await darwin.Requests.GetServiceDetailsAsync(response.TrainServices[0].RetailServiceId);
```