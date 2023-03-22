using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinTests.Requests
{
    [TestFixture]
    internal class GetServiceDetailsAsyncTest : BaseTest
    {
        [Test]
        public async Task GetServiceDetailsAsync_ValidServiceId_ReturnsStationBoardWithValidData()
        {
            // Arrange
            int numRows = 1;
            Station station = Station.LondonStPancrasInternational;
            TimeSpan timeWindow = TimeSpan.FromMinutes(60);
            DateTime requestTimeWindow = DateTime.UtcNow.Add(timeWindow);

            // Act
            var service = await Darwin.Requests.GetArrivalBoardAsync(numRows, station, timeWindow);

            if (service.TrainServices == null || service.TrainServices.Count == 0) Assert.Inconclusive("No services returned from GetArrivalBoardAsync.");

            var result = await Darwin.Requests.GetServiceDetailsAsync(service.TrainServices[0].ServiceId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.GetType(), Is.EqualTo(typeof(ServiceDetails)));
                Assert.That(result.Station, Is.EqualTo(station), "Returned data does not match expected station.");
                Assert.That(result.ScheduledTimeArrival?.Time, Is.LessThanOrEqualTo(requestTimeWindow), "Returned ScheduledTimeArrival?.Time has past the defined time window.");
            });
        }
    }
}
