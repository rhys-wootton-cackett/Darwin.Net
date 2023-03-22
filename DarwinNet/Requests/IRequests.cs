using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinNet.Requests
{
    public interface IRequests
    {
        /// <summary>
        /// Returns all public arrivals for the supplied station within a defined time window, including service details.
        /// </summary>
        /// <param name="numRows">The number of services to return in the resulting station board. Has to be between 0 and 10 exclusive.</param>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterStation">The <see cref="Station"/> of either an origin or destination location to filter in.</param>
        /// <param name="filterType">The <see cref="FilterType"/> to apply. Filters services to include only those originating or terminating at the <paramref name="filterStation"/>. Defaults to "<see cref="FilterType.To"/>".</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="StationBoardWithDetails"/> object containing the requested details.</returns>
        public Task<StationBoardWithDetails> GetArrivalBoardWithDetailsAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns all public arrivals and departures for the supplied station within a defined time window, including service details.
        /// </summary>
        /// <param name="numRows">The number of services to return in the resulting station board. Has to be between 0 and 10 exclusive.</param>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterStation">The <see cref="Station"/> of either an origin or destination location to filter in.</param>
        /// <param name="filterType">The <see cref="FilterType"/> to apply. Filters services to include only those originating or terminating at the <paramref name="filterStation"/>. Defaults to "<see cref="FilterType.To"/>".</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="StationBoardWithDetails"/> object containing the requested details.</returns>
        public Task<StationBoardWithDetails> GetArrivalDepartureBoardWithDetailsAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns all public arrivals for the supplied station within a defined time window.
        /// </summary>
        /// <param name="numRows">The number of services to return in the resulting station board. Has to be between 0 and 150 exclusive.</param>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterStation">The <see cref="Station"/> of either an origin or destination location to filter in.</param>
        /// <param name="filterType">The <see cref="FilterType"/> to apply. Filters services to include only those originating or terminating at the <paramref name="filterStation"/>. Defaults to "<see cref="FilterType.To"/>".</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="StationBoard"/> object containing the requested details.</returns>
        public Task<StationBoard> GetArrivalBoardAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns all public arrivals and departures for a supplied station within a defined time window.
        /// </summary>
        /// <param name="numRows">The number of services to return in the resulting station board. Has to be between 0 and 150 exclusive.</param>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterStation">The <see cref="Station"/> of either an origin or destination location to filter in.</param>
        /// <param name="filterType">The <see cref="FilterType"/> to apply. Filters services to include only those originating or terminating at the <paramref name="filterStation"/>. Defaults to "<see cref="FilterType.To"/>".</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="StationBoard"/> object containing the requested details.</returns>
        public Task<StationBoard> GetArrivalDepartureBoardAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns all public departures for the supplied station within a defined time window.
        /// </summary>
        /// <param name="numRows">The number of services to return in the resulting station board. Has to be between 0 and 150 exclusive.</param>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterStation">The <see cref="Station"/> of either an origin or destination location to filter in.</param>
        /// <param name="filterType">The <see cref="FilterType"/> to apply. Filters services to include only those originating or terminating at the <paramref name="filterStation"/>. Defaults to "<see cref="FilterType.To"/>".</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="StationBoard"/> object containing the requested details.</returns>
        public Task<StationBoard> GetDepartureBoardAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns all public departures for the supplied station within a defined time window, including service details.
        /// </summary>
        /// <param name="numRows">The number of services to return in the resulting station board. Has to be between 0 and 10 exclusive.</param>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterStation">The <see cref="Station"/> of either an origin or destination location to filter in.</param>
        /// <param name="filterType">The <see cref="FilterType"/> to apply. Filters services to include only those originating or terminating at the <paramref name="filterStation"/>. Defaults to "<see cref="FilterType.To"/>".</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="StationBoardWithDetails"/> object containing the requested details.</returns>
        public Task<StationBoardWithDetails> GetDepartureBoardWithDetailsAsync(int numRows, Station station, TimeSpan timeWindow, Station? filterStation = null, FilterType filterType = FilterType.To, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns the public departure for the supplied station a defined time window to the locations specified in the filter with the earliest arrival time at the filtered location.
        /// </summary>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterList">A list of <see cref="Station"/> values of the destinations location to filter. At least 1 but not greater than 15 must be supplied.</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="DeparturesBoard"/> object containing the requested details.</returns>
        public Task<DeparturesBoard> GetFastestDeparturesAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns the public departure for the supplied station a defined time window to the locations specified in the filter with the earliest arrival time at the filtered location, including service details.
        /// </summary>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterList">A list of <see cref="Station"/> values of the destinations location to filter. At least 1 but not greater than 10 must be supplied.</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="DeparturesBoardWithDetails"/> object containing the requested details.</returns>
        public Task<DeparturesBoardWithDetails> GetFastestDeparturesWithDetailsAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns the next public departure for the supplied station within a defined time window to the locations specified in the filter.
        /// </summary>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterList">A list of <see cref="Station"/> values of the destinations location to filter. At least 1 but not greater than 15 must be supplied.</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="DeparturesBoard"/> object containing the requested details.</returns>
        public Task<DeparturesBoard> GetNextDeparturesAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns the next public departure for the supplied station within a defined time window to the locations specified in the filter, including service details.
        /// </summary>
        /// <param name="station">The <see cref="Station"/> for which the request is being made.</param>
        /// <param name="timeWindow">How far into the past or future, in minutes (relative to <paramref name="timeOffset"/>), to return services for. Has to be between -120 and 120 minutes exclusive.</param>
        /// <param name="filterList">A list of <see cref="Station"/> values of the destinations location to filter. At least 1 but not greater than 15 must be supplied.</param>
        /// <param name="timeOffset">An offset in minutes against the current time to provide the station board for. Has to be between -120 and 120 minutes exclusive. </param>
        /// <returns>A <see cref="DeparturesBoardWithDetails"/> object containing the requested details.</returns>
        public Task<DeparturesBoardWithDetails> GetNextDeparturesWithDetailsAsync(Station station, IList<Station> filterList, TimeSpan timeWindow, TimeSpan? timeOffset = null);

        /// <summary>
        /// Returns service details for a specific service identified by a station board. These details are supplied relative to the station board from which the serviceID field value was generated. 
        /// Service details are only available while the service appears on the station board from which it was obtained. This is normally for two minutes after it is expected to have departed, 
        /// or after a terminal arrival. 
        /// </summary>
        /// <param name="serviceId">The service ID of the service to request the details of. The service ID is obtained from a service listed in a StationBoard object returned from any other request.</param>
        /// <returns>A <see cref="ServiceDetails"/> object containing the requested details.</returns>
        public Task<ServiceDetails> GetServiceDetailsAsync(string serviceId);
    }
}
