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
    /// Defines a <see cref="IFactory{DepartureItemWithCallingPoints}"/> that can create a <see cref="DepartureItemWithCallingPoints"/>
    /// </summary>
    internal class DepartureItemWithCallingPointsFactory : IFactory<DepartureItemWithCallingPoints>
    {
        /// <summary>
        /// Returns a static instance of <see cref="DepartureItemWithCallingPointsFactory"/>
        /// </summary>
        public static DepartureItemWithCallingPointsFactory Instance { get; } = new DepartureItemWithCallingPointsFactory();

        /// <summary>
        /// Creates a new <see cref="DepartureItemWithCallingPoints"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="DepartureItemWithCallingPoints"/></returns>
        public DepartureItemWithCallingPoints Create(XmlDocument response)
        {
            var darwinObj = new DepartureItemWithCallingPoints
            {
                Station = (response.SelectSingleNode("//destination[1]").Attributes["crs"] ?? throw new InvalidDarwinDataException("destination")).InnerText.GetEnumFromStringValue<Station>(),
                Services = (response.SelectSingleNode("//destination[1]") ?? throw new InvalidDarwinDataException("destination")).ChildNodes.OfType<XmlElement>()
                                    .Select(e => FactoryLoader.XmlElementToT(ServiceItemWithCallingPointsFactory.Instance, e)).ToList()
            };

            return darwinObj;
        }
    }
}
