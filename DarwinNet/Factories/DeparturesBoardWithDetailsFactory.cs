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
    /// Defines a <see cref="IFactory{DeparturesBoardWithDetails}"/> that can create a <see cref="DeparturesBoardWithDetails"/>
    /// </summary>
    internal class DeparturesBoardWithDetailsFactory : IFactory<DeparturesBoardWithDetails>
    {
        /// <summary>
        /// Returns a static instance of <see cref="DeparturesBoardWithDetailsFactory"/>
        /// </summary>
        public static DeparturesBoardWithDetailsFactory Instance { get; } = new DeparturesBoardWithDetailsFactory();

        /// <summary>
        /// Creates a new <see cref="DeparturesBoardWithDetails"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="DeparturesBoardWithDetails"/></returns>
        public DeparturesBoardWithDetails Create(XmlDocument response)
        {
            var darwinObj = new DeparturesBoardWithDetails
            {
                GeneratedAt = DateTime.Parse((response.SelectSingleNode("//generatedAt[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText),
                LocationName = (response.SelectSingleNode("//locationName[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText,
                Station = (response.SelectSingleNode("//crs[1]") ?? throw new InvalidDarwinDataException("crs")).InnerText.GetEnumFromStringValue<Station>(),
                FilterLocationName = response.SelectSingleNode("//filterLocationName[1]")?.InnerText,
                FilterStation = response.SelectSingleNode("//filtercrs[1]")?.InnerText.GetEnumFromStringValue<Station>(),
                NrccMessages = response.SelectSingleNode("//nrccMessages[1]")?.ChildNodes.Cast<XmlNode>().Select(m => m.InnerText.CleanHtml()).ToList(),
                IsPlatformAvailable = response.SelectSingleNode("//platformAvailable[1]")?.InnerText.TryParseBoolNullable(),
                Departures = (response.SelectSingleNode("//departures[1]") ?? throw new InvalidDarwinDataException("departures")).ChildNodes.OfType<XmlElement>()
                                    .Select(e => FactoryLoader.XmlElementToT(DepartureItemWithCallingPointsFactory.Instance, e)).ToList()
            };


            return darwinObj;
        }
    }
}
