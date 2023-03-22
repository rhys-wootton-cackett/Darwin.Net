using DarwinNet.Exceptions;
using DarwinNet.Helpers;
using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DarwinNet.Factories
{
    /// <summary>
    /// Defines a <see cref="IFactory{StationBoardWithDetails}"/> that can create a <see cref="StationBoardWithDetails"/>
    /// </summary>
    internal class StationBoardWithDetailsFactory : IFactory<StationBoardWithDetails>
    {
        /// <summary>
        /// Returns a static instance of <see cref="StationBoardWithDetailsFactory"/>
        /// </summary>
        public static StationBoardWithDetailsFactory Instance { get; } = new StationBoardWithDetailsFactory();

        /// <summary>
        /// Creates a new <see cref="StationBoardWithDetails"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="StationBoardWithDetails"/></returns>
        public StationBoardWithDetails Create(XmlDocument response)
        {
            var darwinObj = new StationBoardWithDetails
            {
                GeneratedAt = DateTime.Parse((response.SelectSingleNode("//generatedAt[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText),
                LocationName = (response.SelectSingleNode("//locationName[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText,
                Station = (response.SelectSingleNode("//crs[1]") ?? throw new InvalidDarwinDataException("crs")).InnerText.GetEnumFromStringValue<Station>(),
                FilterLocationName = response.SelectSingleNode("//filterLocationName[1]")?.InnerText,
                FilterStation = response.SelectSingleNode("//filtercrs[1]")?.InnerText.GetEnumFromStringValue<Station>(),
                NrccMessages = response.SelectSingleNode("//nrccMessages[1]")?.ChildNodes.Cast<XmlNode>().Select(m => m.InnerText.CleanHtml()).ToList(),
                IsPlatformAvailable = response.SelectSingleNode("//platformAvailable[1]")?.InnerText.TryParseBoolNullable(),
                TrainServices = response.SelectSingleNode("//trainServices[1]")?.ChildNodes.Cast<XmlNode>().Select(e => FactoryLoader.XmlElementToT(ServiceItemWithCallingPointsFactory.Instance, e)).ToList(),
                BusServices = response.SelectSingleNode("//busServices[1]")?.ChildNodes.Cast<XmlElement>().Select(e => FactoryLoader.XmlElementToT(ServiceItemWithCallingPointsFactory.Instance, e)).ToList(),
                FerryServices = response.SelectSingleNode("//ferryServices[1]")?.ChildNodes.Cast<XmlElement>().Select(e => FactoryLoader.XmlElementToT(ServiceItemWithCallingPointsFactory.Instance, e)).ToList()
            };

            return darwinObj;
        }
    }
}
