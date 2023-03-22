using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTests.Requests
{
    [TestFixture]
    internal class GetFastestDeparturesWithDetailsAsyncTest : BaseTest
    {
        [Test]
        public async Task GetFastestDeparturesWithDetailsAsync_ValidParams_ReturnsDeparturesBoardWithDetailsWithValidData()
        {
            // Arrange
            Station station = Station.LondonStPancrasInternational;
            List<Station> stationList = new() { Station.LondonBridge, Station.WestHampsteadThameslink };
            TimeSpan timeWindow = TimeSpan.FromMinutes(60);
            DateTime requestTimeWindow = DateTime.UtcNow.Add(timeWindow);

            // Act
            var result = await Darwin.Requests.GetFastestDeparturesWithDetailsAsync(station, stationList, timeWindow);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.GetType(), Is.EqualTo(typeof(DeparturesBoardWithDetails)));
                Assert.That(result.Station, Is.EqualTo(station), "Returned data does not match expected station.");
                Assert.That(result.Departures?.All(departure => stationList.Contains(departure.Station)), Is.True, "Returned Departues? does not contain all the stations in stationList.");
                Assert.That(result.Departures?.All(departure => departure.Services.All(service => service.ScheduledTimeDeparture?.Time <= requestTimeWindow)), Is.True, "Returned TrainServices? have services past the defined time window.");
            });
        }

        [Test]
        public void GetFastestDeparturesWithDetailsAsync_InvalidFilterList_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Station station = Station.LondonStPancrasInternational;
            List<Station> stationList = new();
            TimeSpan timeWindow = TimeSpan.FromMinutes(60);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => Darwin.Requests.GetFastestDeparturesWithDetailsAsync(station, stationList, timeWindow));
        }

        [Test]
        public void GetFastestDeparturesWithDetailsAsync_InvalidTimeWindow_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Station station = Station.LondonStPancrasInternational;
            List<Station> stationList = new();
            TimeSpan timeWindow = TimeSpan.FromMinutes(-150);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => Darwin.Requests.GetFastestDeparturesWithDetailsAsync(station, stationList, timeWindow));
        }

        [Test]
        public async Task GetFastestDeparturesWithDetailsAsync_TimeOffset_ReturnsDeparturesBoardWithDetailsWithValidData()
        {
            // Arrange
            Station station = Station.LondonStPancrasInternational;
            List<Station> stationList = new() { Station.LondonBridge, Station.WestHampsteadThameslink };
            TimeSpan timeWindow = TimeSpan.FromMinutes(60);
            TimeSpan timeOffset = TimeSpan.FromMinutes(-30);
            DateTime requestTimeWindow = DateTime.UtcNow.Add(timeWindow).Add(timeOffset);

            // Act
            var result = await Darwin.Requests.GetFastestDeparturesWithDetailsAsync(station, stationList, timeWindow);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.GetType(), Is.EqualTo(typeof(DeparturesBoardWithDetails)));
                Assert.That(result.Station, Is.EqualTo(station), "Returned data does not match expected station.");
                Assert.That(result.Departures?.All(departure => stationList.Contains(departure.Station)), Is.True, "Returned Departues? does not contain all the stations in stationList.");
                Assert.That(result.Departures?.All(departure => departure.Services.All(service => service.ScheduledTimeDeparture?.Time <= requestTimeWindow)), Is.True, "Returned TrainServices? have services past the defined time window.");
            });
        }
    }
}
