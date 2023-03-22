using DarwinNet.Exceptions;
using DarwinNet.Helpers;
using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DarwinNet.Factories
{
    /// <summary>
    /// Defines a <see cref="IFactory{ServiceItemWithCallingPoints}"/> that can create a <see cref="ServiceItemWithCallingPoints"/>
    /// </summary>
    internal class ServiceItemWithCallingPointsFactory : IFactory<ServiceItemWithCallingPoints>
    {
        /// <summary>
        /// Returns a static instance of <see cref="ServiceItemWithCallingPointsFactory"/>
        /// </summary>
        public static ServiceItemWithCallingPointsFactory Instance { get; } = new ServiceItemWithCallingPointsFactory();

        /// <summary>
        /// Creates a new <see cref="ServiceItemWithCallingPoints"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="ServiceItemWithCallingPoints"/></returns>
        public ServiceItemWithCallingPoints Create(XmlDocument response)
        {
            var darwinObj = new ServiceItemWithCallingPoints
            {
                RetailServiceId = response.SelectSingleNode("//rsid[1]")?.InnerText,
                Origin = (response.SelectSingleNode("//origin[1]") ?? throw new InvalidDarwinDataException("origin")).ChildNodes.Cast<XmlNode>()
                        .Select(e => FactoryLoader.XmlElementToT(ServiceLocationFactory.Instance, e)).ToList(),
                Destination = (response.SelectSingleNode("//destination[1]") ?? throw new InvalidDarwinDataException("destination")).ChildNodes.Cast<XmlNode>()
                        .Select(e => FactoryLoader.XmlElementToT(ServiceLocationFactory.Instance, e)).ToList(),
                CurrentOrigins = response.SelectSingleNode("//currentOrigins[1]")?.ChildNodes.Cast<XmlNode>()
                        .Select(e => FactoryLoader.XmlElementToT(ServiceLocationFactory.Instance, e)).ToList(),
                CurrentDestinations = response.SelectSingleNode("//currentDestinations[1]")?.ChildNodes.Cast<XmlNode>()
                        .Select(e => FactoryLoader.XmlElementToT(ServiceLocationFactory.Instance, e)).ToList(),
                ScheduledTimeArrival = response.SelectSingleNode("//sta[1]")?.InnerText.ParseDarwinTime(),
                EstimatedTimeArrival = response.SelectSingleNode("//eta[1]")?.InnerText.ParseDarwinTime(),
                ScheduledTimeDeparture = response.SelectSingleNode("//std[1]")?.InnerText.ParseDarwinTime(),
                EstimatedTimeDeparture = response.SelectSingleNode("//etd[1]")?.InnerText.ParseDarwinTime(),
                Platform = response.SelectSingleNode("//platform[1]")?.InnerText,
                Operator = (response.SelectSingleNode("//operator[1]") ?? throw new InvalidDarwinDataException("operator")).InnerText,
                OperatorCode = (response.SelectSingleNode("//operatorCode[1]") ?? throw new InvalidDarwinDataException("operatorCode")).InnerText,
                IsCircularRoute = response.SelectSingleNode("//isCircularRoute[1]")?.InnerText.TryParseBoolNullable(),
                FilterLocationCancelled = response.SelectSingleNode("//filterLocationCancelled[1]")?.InnerText.TryParseBoolNullable(),
                ServiceType = (response.SelectSingleNode("//serviceType[1]") ?? throw new InvalidDarwinDataException("serviceType")).InnerText.GetEnumFromStringValue<ServiceType>(),
                TrainLength = response.SelectSingleNode("//length[1]")?.InnerText.TryParseIntNullable(),
                DoesTrainDetachAtFront = response.SelectSingleNode("//detachFront[1]")?.InnerText.TryParseBoolNullable(),
                IsReverseFormation = response.SelectSingleNode("//isReverseFormation[1]")?.InnerText.TryParseBoolNullable(),
                CancellationReason = response.SelectSingleNode("//cancelReason[1]")?.InnerText,
                DelayReason = response.SelectSingleNode("//delayReason[1]")?.InnerText,
                ServiceId = (response.SelectSingleNode("//serviceID[1]") ?? throw new InvalidDarwinDataException("serviceID")).InnerText,
                AdhocAlerts = response.SelectSingleNode("//adhocAlerts[1]")?.ChildNodes.Cast<XmlNode>().Select(m => m.InnerText.CleanHtml()).ToList(),
                Formation = (response.SelectSingleNode("//formation[1]") != null ? FactoryLoader.XmlElementToT(FormationDataFactory.Instance, response.SelectSingleNode("//formation[1]").Cast<XmlElement>().First()) : null),
                PreviousCallingPoints = response.SelectSingleNode("//previousCallingPoints[1]/callingPointList[1]")?.ChildNodes.Cast<XmlNode>()
                                                    .Select(e => FactoryLoader.XmlElementToT(CallingPointFactory.Instance, e)).ToList(),
                SubsequentCallingPoints = response.SelectSingleNode("//subsequentCallingPoints[1]/callingPointList[1]")?.ChildNodes.Cast<XmlNode>()
                                                    .Select(e => FactoryLoader.XmlElementToT(CallingPointFactory.Instance, e)).ToList()
            };

            return darwinObj;
        }
    }
}
