using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinNet.Requests
{
    internal interface IRequests
    {
        public Task<StationBoardWithDetails> GetArrivalBoardWithDetailsAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        public Task<StationBoardWithDetails> GetArrivalDepartureBoardWithDetailsAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        public Task<StationBoard> GetArrivalBoardAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        public Task<StationBoard> GetArrivalDepartureBoardAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        public Task<StationBoard> GetDepartureBoardAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        public Task<StationBoardWithDetails> GetDepartureBoardWithDetailsAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        public Task<DeparturesBoard> GetFastestDeparturesAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null);

        public Task<DeparturesBoardWithDetails> GetFastestDeparturesWithDetailsAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null);

        public Task<DeparturesBoard> GetNextDeparturesAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null);

        public Task<DeparturesBoardWithDetails> GetNextDeparturesWithDetailsAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null);

        public Task<ServiceDetails> GetServiceDetailsAsync(string serviceId);
    }
}
