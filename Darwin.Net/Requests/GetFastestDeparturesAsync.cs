using Darwin.Net.Exceptions;
using Darwin.Net.Factories;
using Darwin.Net.Helpers;
using Darwin.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darwin.Net.Requests
{
    public partial class Requests : IRequests
    {
        public Task<DeparturesBoard> GetFastestDeparturesAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null)
        {
            // Check that params are valid, if not throw exceptions or handle them elsewhere
            if (timeWindow.TotalMinutes <= -120 || timeWindow.TotalMinutes >= 120) throw new ArgumentOutOfRangeException(nameof(timeWindow), "timeWindow has to be between -120 and 120 exclusive.");
            if (filterList.Count <= 0 || filterList.Count > 15) throw new ArgumentOutOfRangeException(nameof(timeWindow), "filter has to be between 1 and 15 inclusive.");
            if (timeOffset != null && (timeOffset?.TotalMinutes <= -120 || timeOffset?.TotalMinutes >= 120)) throw new ArgumentOutOfRangeException(nameof(timeOffset), "timeOffset has to be between -120 and 120 exclusive.");
            if (timeOffset == null) timeOffset = new TimeSpan(0, 0, 0);

            var requestParams = new Dictionary<string, object>()
            {
                { "crs", station.GetStringValue() },
                { "filterList", filterList },
                { "timeOffset", timeOffset?.TotalMinutes },
                { "timeWindow", timeWindow.TotalMinutes }
            };

            return GetFastestDeparturesInternal(requestParams);
        }

        private async Task<DeparturesBoard> GetFastestDeparturesInternal(Dictionary<string, object> requestParams)
        {
            var soapEnvelope = BuildDarwinSoapEnvelope("GetFastestDepartures", requestParams);
            var response = await SendDarwinSoapRequestAsync(soapEnvelope, DeparturesBoardFactory.Instance);
            return response;
        }
    }
}
