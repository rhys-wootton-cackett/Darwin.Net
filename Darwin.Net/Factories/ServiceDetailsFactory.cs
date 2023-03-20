using Darwin.Net.Exceptions;
using Darwin.Net.Helpers;
using Darwin.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Darwin.Net.Factories
{
    /// <summary>
    /// Defines a <see cref="IFactory{ServiceDetails}"/> that can create a <see cref="ServiceDetails"/>
    /// </summary>
    internal class ServiceDetailsFactory : IFactory<ServiceDetails>
    {
        /// <summary>
        /// Returns a static instance of <see cref="ServiceDetailsFactory"/>
        /// </summary>
        public static ServiceDetailsFactory Instance { get; } = new ServiceDetailsFactory();

        /// <summary>
        /// Creates a new <see cref="ServiceDetails"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="ServiceDetails"/></returns>
        public ServiceDetails Create(XmlDocument response)
        {
            List<IList<CallingPoint>> prev = new() {
                response.SelectSingleNode("//previousCallingPoints[1]/callingPointList[1]")?.ChildNodes
                    .Cast<XmlNode>()
                    .Select(e => FactoryLoader.XmlElementToT(CallingPointFactory.Instance, e))
                    .ToList() ?? new List<CallingPoint>()
            };

            List<IList<CallingPoint>> sub = new() {
                response.SelectSingleNode("//subsequentCallingPoints[1]/callingPointList[1]")?.ChildNodes
                    .Cast<XmlNode>()
                    .Select(e => FactoryLoader.XmlElementToT(CallingPointFactory.Instance, e))
                    .ToList() ?? new List<CallingPoint>()
            };

            var darwinObj = new ServiceDetails
            {
                GeneratedAt = DateTime.Parse((response.SelectSingleNode("//generatedAt[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText),
                RetailServiceId = response.SelectSingleNode("//rsid[1]")?.InnerText,
                ServiceType = (response.SelectSingleNode("//serviceType[1]") ?? throw new InvalidDarwinDataException("serviceType")).InnerText.GetEnumFromStringValue<ServiceType>(),
                LocationName = (response.SelectSingleNode("//locationName[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText,
                Station = (response.SelectSingleNode("//crs[1]") ?? throw new InvalidDarwinDataException("crs")).InnerText.GetEnumFromStringValue<Station>(),
                Operator = (response.SelectSingleNode("//operator[1]") ?? throw new InvalidDarwinDataException("operator")).InnerText,
                OperatorCode = (response.SelectSingleNode("//operatorCode[1]") ?? throw new InvalidDarwinDataException("operatorCode")).InnerText,
                CancellationReason = response.SelectSingleNode("//cancelReason[1]")?.InnerText,
                DelayReason = response.SelectSingleNode("//delayReason[1]")?.InnerText,
                DoesTrainDetachAtFront = response.SelectSingleNode("//detachFront[1]")?.InnerText.TryParseBoolNullable(),
                DiversionReason = response.SelectSingleNode("//diversionReason[1]")?.InnerText,
                DivertedVia = response.SelectSingleNode("//divertedVia[1]")?.InnerText,
                OverdueMessage = response.SelectSingleNode("//overdueMessage[1]")?.InnerText,
                TrainLength = response.SelectSingleNode("//length[1]")?.InnerText.TryParseIntNullable(),
                IsReverseFormation = response.SelectSingleNode("//isReverseFormation[1]")?.InnerText.TryParseBoolNullable(),
                Platform = response.SelectSingleNode("//platform[1]")?.InnerText,
                ScheduledTimeArrival = response.SelectSingleNode("//sta[1]")?.InnerText.ParseDarwinTime(),
                ActualTimeArrival = response.SelectSingleNode("//ata[1]")?.InnerText.ParseDarwinTime(),
                EstimatedTimeArrival = response.SelectSingleNode("//eta[1]")?.InnerText.ParseDarwinTime(),
                ScheduledTimeDeparture = response.SelectSingleNode("//std[1]")?.InnerText.ParseDarwinTime(),
                EstimatedTimeDeparture = response.SelectSingleNode("//etd[1]")?.InnerText.ParseDarwinTime(),
                ActualTimeDeparture = response.SelectSingleNode("//atd[1]")?.InnerText.ParseDarwinTime(),
                AdhocAlerts = response.SelectSingleNode("//adhocAlerts[1]")?.ChildNodes.Cast<XmlNode>().Select(m => m.InnerText.CleanHtml()).ToList(),
                PreviousCallingPoints = prev,
                SubsequentCallingPoints = sub,
                Formation = (response.SelectSingleNode("//formation[1]") != null ? FactoryLoader.XmlElementToT(FormationDataFactory.Instance, response.SelectSingleNode("//formation[1]")
                                .Cast<XmlElement>().First()) : null)
            };

            return darwinObj;
        }
    }
}
