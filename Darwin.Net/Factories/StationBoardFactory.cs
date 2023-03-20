using Darwin.Net.Exceptions;
using Darwin.Net.Helpers;
using Darwin.Net.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Darwin.Net.Factories
{
    /// <summary>
    /// Defines a <see cref="IFactory{StationBoard}"/> that can create a <see cref="StationBoard"/>
    /// </summary>
    internal class StationBoardFactory : IFactory<StationBoard>
    {
        /// <summary>
        /// Returns a static instance of <see cref="StationBoardFactory"/>
        /// </summary>
        public static StationBoardFactory Instance { get; } = new StationBoardFactory();

        /// <summary>
        /// Creates a new <see cref="StationBoard"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="StationBoard"/></returns>
        public StationBoard Create(XmlDocument response)
        {
            var darwinObj = new StationBoard
            {
                GeneratedAt = DateTime.Parse((response.SelectSingleNode("//generatedAt[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText),
                LocationName = (response.SelectSingleNode("//locationName[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText,
                Station = (response.SelectSingleNode("//crs[1]") ?? throw new InvalidDarwinDataException("crs")).InnerText.GetEnumFromStringValue<Station>(),
                FilterLocationName = response.SelectSingleNode("//filterLocationName[1]")?.InnerText,
                FilterStation = response.SelectSingleNode("//filtercrs[1]")?.InnerText.GetEnumFromStringValue<Station>(),
                NrccMessages = response.SelectSingleNode("//nrccMessages[1]")?.ChildNodes.Cast<XmlNode>().Select(m => m.InnerText.CleanHtml()).ToList(),
                IsPlatformAvailable = response.SelectSingleNode("//platformAvailable[1]")?.InnerText.TryParseBoolNullable(),
                TrainServices = response.SelectSingleNode("//trainServices[1]")?.ChildNodes.Cast<XmlNode>().Select(e => FactoryLoader.XmlElementToT(ServiceItemFactory.Instance, e)).ToList(),
                BusServices = response.SelectSingleNode("//busServices[1]")?.ChildNodes.Cast<XmlElement>().Select(e => FactoryLoader.XmlElementToT(ServiceItemFactory.Instance, e)).ToList(),
                FerryServices = response.SelectSingleNode("//ferryServices[1]")?.ChildNodes.Cast<XmlElement>().Select(e => FactoryLoader.XmlElementToT(ServiceItemFactory.Instance, e)).ToList()
            };

            return darwinObj;
        }
    }
}
