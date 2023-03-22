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
        public Task<DeparturesBoardWithDetails> GetFastestDeparturesWithDetailsAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null)
        {
            // Check that params are valid, if not throw exceptions or handle them elsewhere
            if (timeWindow.TotalMinutes <= -120 || timeWindow.TotalMinutes >= 120) throw new ArgumentOutOfRangeException(nameof(timeWindow), "timeWindow has to be between -120 and 120 exclusive.");
            if (filterList.Count <= 0 || filterList.Count > 10) throw new ArgumentOutOfRangeException(nameof(timeWindow), "filter has to be between 1 and 10 inclusive.");
            if (timeOffset != null && (timeOffset?.TotalMinutes <= -120 || timeOffset?.TotalMinutes >= 120)) throw new ArgumentOutOfRangeException(nameof(timeOffset), "timeOffset has to be between -120 and 120 exclusive.");
            if (timeOffset == null) timeOffset = new TimeSpan(0, 0, 0);

            var requestParams = new Dictionary<string, object>()
            {
                { "crs", station.GetStringValue() },
                { "filterList", filterList },
                { "timeOffset", timeOffset?.TotalMinutes },
                { "timeWindow", timeWindow.TotalMinutes }
            };

            return GetFastestDeparturesWithDetailsInternal(requestParams);
        }

        private async Task<DeparturesBoardWithDetails> GetFastestDeparturesWithDetailsInternal(Dictionary<string, object> requestParams)
        {
            var soapEnvelope = BuildDarwinSoapEnvelope("GetFastestDeparturesWithDetails", requestParams);
            var response = await SendDarwinSoapRequestAsync(soapEnvelope, DeparturesBoardWithDetailsFactory.Instance);
            return response;
        }
    }
}
