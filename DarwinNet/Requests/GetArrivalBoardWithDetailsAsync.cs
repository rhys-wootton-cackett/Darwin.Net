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
        public Task<StationBoardWithDetails> GetArrivalBoardWithDetailsAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null)
        {
            // Check that params are valid, if not throw exceptions or handle them elsewhere
            if (numRows <= 0 || numRows >= 10) throw new ArgumentOutOfRangeException(nameof(numRows), "numRows has to be between 0 and 10 exclusive.");
            if (timeWindow.TotalMinutes <= -120 || timeWindow.TotalMinutes >= 120) throw new ArgumentOutOfRangeException(nameof(timeWindow), "timeWindow has to be between -120 and 120 exclusive.");
            if (timeOffset != null && (timeOffset?.TotalMinutes <= -120 || timeOffset?.TotalMinutes >= 120)) throw new ArgumentOutOfRangeException(nameof(timeOffset), "timeOffset has to be between -120 and 120 exclusive.");
            if (timeOffset == null) timeOffset = new TimeSpan(0, 0, 0);

            var requestParams = new Dictionary<string, object>()
            {
                { "numRows", numRows },
                { "crs", station.GetStringValue() },
                { "filterCrs", filterStation?.GetStringValue() },
                { "filterType", filterType.GetStringValue() },
                { "timeOffset", timeOffset?.TotalMinutes },
                { "timeWindow", timeWindow.TotalMinutes }
            };

            return GetArrivalBoardWithDetailsInternal(requestParams);
        }

        private async Task<StationBoardWithDetails> GetArrivalBoardWithDetailsInternal(Dictionary<string, object> requestParams)
        {
            var soapEnvelope = BuildDarwinSoapEnvelope("GetArrBoardWithDetails", requestParams);
            var response = await SendDarwinSoapRequestAsync(soapEnvelope, StationBoardWithDetailsFactory.Instance);
            return response;
        }
    }
}
