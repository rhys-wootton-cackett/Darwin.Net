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
    /// Defines a <see cref="IFactory{DepartureItem}"/> that can create a <see cref="DepartureItem"/>
    /// </summary>
    internal class DepartureItemFactory : IFactory<DepartureItem>
    {
        /// <summary>
        /// Returns a static instance of <see cref="DepartureItemFactory"/>
        /// </summary>
        public static DepartureItemFactory Instance { get; } = new DepartureItemFactory();

        /// <summary>
        /// Creates a new <see cref="DepartureItem"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="DepartureItem"/></returns>
        public DepartureItem Create(XmlDocument response)
        {
            var darwinObj = new DepartureItem
            {
                Station = (response.SelectSingleNode("//destination[1]").Attributes["crs"] ?? throw new InvalidDarwinDataException("destination")).InnerText.GetEnumFromStringValue<Station>(),
                Services = (response.SelectSingleNode("//destination[1]") ?? throw new InvalidDarwinDataException("destination")).ChildNodes.OfType<XmlElement>()
                                    .Select(e => FactoryLoader.XmlElementToT(ServiceItemFactory.Instance, e)).ToList()
            };

            return darwinObj;
        }
    }
}
