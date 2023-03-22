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
    /// Defines a <see cref="IFactory{CoachData}"/> that can create a <see cref="CoachData"/>
    /// </summary>
    internal class CoachDataFactory : IFactory<CoachData>
    {
        /// <summary>
        /// Returns a static instance of <see cref="CoachDataFactory"/>
        /// </summary>
        public static CoachDataFactory Instance { get; } = new CoachDataFactory();

        /// <summary>
        /// Creates a new <see cref="CoachData"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="CoachData"/></returns>
        public CoachData Create(XmlDocument response)
        {
            var darwinObj = new CoachData
            {
                CoachClass = (response.SelectSingleNode("//coachClass[1]") ?? throw new InvalidDarwinDataException("coachClass")).InnerText.GetEnumFromStringValue<CoachClass>(),
                Loading = response.SelectSingleNode("//loading[1]")?.InnerText.TryParseIntNullable(),
                LoadingSpecified = response.SelectSingleNode("//loadingSpecified[1]")?.InnerText.TryParseBoolNullable(),
                CoachNumber = (response.SelectSingleNode("//coach[1]")?.Attributes["number"] ?? throw new InvalidDarwinDataException("coach.number")).InnerText,
                Toilet = response.SelectSingleNode("//toilet[1]")?.InnerText.GetEnumFromStringValue<Toilet>()
            };

            return darwinObj;
        }
    }
}
