using DarwinNet.Exceptions;
using DarwinNet.Factories;
using DarwinNet.Helpers;
using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinNet.Requests
{
    public partial class Requests : IRequests
    {
        /// <summary>
        /// Returns the public departure for the supplied station a defined time window to the locations specified in the filter with the earliest arrival time at the filtered location.
        /// </summary>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterList">A list of <see cref="Station"/> values of the destinations location to filter. At least 1 but not greater than 15 must be supplied.</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="DeparturesBoard"/> object containing the requested details.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When timeWindow, filterList or timeOffset are out of range.</exception>
        /// <exception cref="StationCrsNullException">When station or filterStation do not have a CRS code associated with them.</exception>
        public Task<DeparturesBoard> GetFastestDeparturesAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null)
        {
            // Check that params are valid, if not throw exceptions or handle them elsewhere
            if (timeWindow.TotalMinutes <= -120 || timeWindow.TotalMinutes >= 120) throw new ArgumentOutOfRangeException(nameof(timeWindow), "timeWindow has to be between -120 and 120 exclusive.");
            if (filterList.Count <= 0 || filterList.Count > 15) throw new ArgumentOutOfRangeException(nameof(timeWindow), "filter has to be between 1 and 15 inclusive.");
            if (timeOffset != null && (timeOffset?.TotalMinutes <= -120 || timeOffset?.TotalMinutes >= 120)) throw new ArgumentOutOfRangeException(nameof(timeOffset), "timeOffset has to be between -120 and 120 exclusive.");

            var requestParams = new Dictionary<string, object?>()
            {
                { "crs", station.GetStringValue() ?? throw new StationCrsNullException(station) },
                { "filterList", filterList },
                { "timeOffset", timeOffset?.TotalMinutes ?? 0 },
                { "timeWindow", timeWindow.TotalMinutes }
            };

            return GetFastestDeparturesInternal(requestParams);
        }

        private async Task<DeparturesBoard> GetFastestDeparturesInternal(Dictionary<string, object?> requestParams)
        {
            var soapEnvelope = BuildDarwinSoapEnvelope("GetFastestDepartures", requestParams);
            var response = await SendDarwinSoapRequestAsync(soapEnvelope, DeparturesBoardFactory.Instance);
            return response;
        }
    }
}
