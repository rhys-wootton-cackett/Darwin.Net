<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <img src=".gitassets/Long Logo.svg" alt="Logo" width="500">
  <div align="center">
    <a href="https://github.com/rhys-wootton/Darwin.Net/blob/master/LICENSE.txt"><img src="https://img.shields.io/github/license/rhys-wootton/Darwin.Net?style=flat-square"></img></a>
    <img src="https://img.shields.io/codefactor/grade/github/rhys-wootton/Darwin.Net/master?style=flat-square"></img>
    <a href="https://github.com/rhys-wootton/Darwin.Net/issues"><img src="https://img.shields.io/github/issues-raw/rhys-wootton/Darwin.Net?style=flat-square"></img></a>
    <a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/-Powered%20by%20.NET-%23512bd4?style=flat-square"></img></a>
    <a href="https://www.linkedin.com/in/rhyswootton2212/"><img src="https://img.shields.io/badge/-Connect%20with%20me!-0077b5?style=flat-square&logo=LinkedIn"></img></a>
  </div>

  <h3 align="center" style="color: #003366">Darwin.Net</h3>

  <p align="center">
    A powerful and user-friendly C# wrapper for the National Rail Darwin OpenLDBWS API.
    <br />
    <a href="https://rhys-wootton.github.io/Darwin.Net/"><strong>Explore the docs »</strong></a>
  </p>
</div>

<!-- ABOUT THE PROJECT -->
## About The Project

**Darwin.Net** is a versatile and efficient C# wrapper for the UK's National Rail Darwin OpenLDBWS API, specifically designed to simplify railway data integration tasks. 

Its features include:

- **Asynchronous Requests**: Leverage the power of async/await to make non-blocking requests.
- **HttpClient**: By using HttpClient instead of SOAP/WCF, Darwin.Net benefits from improved performance, better resource management, and modern networking capabilities. HttpClient is lighter, faster, and more flexible than its alternatives, making it the ideal choice for a contemporary C# wrapper.
- **Multi-platform Support**: Harness the cross-platform capabilities of .NET to deploy applications using Darwin.Net on a wide range of operating systems, including Windows, macOS, and Linux.
- **Zero Dependencies**: Darwin.Net library is self-contained and does not rely on any external packages, making it easy to integrate and maintain in your projects."

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- GETTING STARTED -->
## Getting Started

To get a local copy built, follow these simple example steps.

### Installation

1. Obtain an API key from [National Rail Enquiries](http://realtime.nationalrail.co.uk/OpenLDBWSRegistration/)
2. Clone the repository
   ```sh
   git clone https://github.com/rhys-wootton/Darwin.Net.git
   ```
3. Create an `app.config` file within the Darwin.Net project and add the following
   ```xml
   <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <appSettings>
            <add key="DarwinApiKey" value="YOUR_API_KEY" />
            <add key="DarwinUrl" value="https://lite.realtime.nationalrail.co.uk/OpenLDBWS/ldb12.asmx"/>
            <add key="DarwinActionNameUrl" value="http://thalesgroup.com/RTTI/2021-11-01/ldb/"/>
            <add key="DarwinTokenTypeUrl" value="http://thalesgroup.com/RTTI/2013-11-28/Token/types"/>
        </appSettings>
    </configuration>
   ```
4. Build  the project
<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage

To get started, this single line of code will give you access to all the requests that Darwin.Net can make:

```c#
Darwin.Net.Darwin darwin = new Darwin.Net.Darwin();
```

From here, you are able to call some of the following requests:

##### Get up to 10 arrivals at a station for the next 90 minutes
```c#
int maxArrivals = 10;
Station station = Station.LondonBridge;
TimeSpan timeWindow = TimeSpan.FromMinutes(90);

StationBoard response = await darwin.Requests.GetArrivalBoardAsync(maxArrivals, station, timeWindow);
```

##### Get up to 5 departures at a station within the last hour with specific calling points
```c#
int maxArrivals = 5;
Station station = Station.GlasgowCentral;
TimeSpan timeWindow = TimeSpan.FromMinutes(60);
TimeSpan offset = TimeSpan.FromMinutes(-60);

StationBoardWithDetails response = await darwin.Requests.GetDepartureBoardWithDetailsAsync(maxArrivals, station, timeWindow, timeOffset = offset);
```

##### Get the next fastest services from a station to a list of station within the next 30 minutes
```c#
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
```c#
int maxArrivals = 5;
Station station = Station.GlasgowCentral;
TimeSpan timeWindow = TimeSpan.FromMinutes(60);
TimeSpan offset = TimeSpan.FromMinutes(-60);

StationBoard response = await darwin.Requests.GetArrivalBoardAsync(maxArrivals, station, timeWindow, timeOffset = offset);
ServiceDetails service = await darwin.Requests.GetServiceDetailsAsync(response.TrainServices[0].RetailServiceId);
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the GNU AGPLv3 License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>