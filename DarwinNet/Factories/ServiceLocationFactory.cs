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
    /// Defines a <see cref="IFactory{ServiceLocation}"/> that can create a <see cref="ServiceLocation"/>
    /// </summary>
    internal class ServiceLocationFactory : IFactory<ServiceLocation>
    {
        /// <summary>
        /// Returns a static instance of <see cref="ServiceLocationFactory"/>
        /// </summary>
        public static ServiceLocationFactory Instance { get; } = new ServiceLocationFactory();

        /// <summary>
        /// Creates a new <see cref="ServiceLocation"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="ServiceLocation"/></returns>
        public ServiceLocation Create(XmlDocument response)
        {
            var darwinObj = new ServiceLocation
            {
                LocationName = (response.SelectSingleNode("//locationName[1]") ?? throw new InvalidDarwinDataException("generatedAt")).InnerText,
                Station = (response.SelectSingleNode("//crs[1]") ?? throw new InvalidDarwinDataException("crs")).InnerText.GetEnumFromStringValue<Station>(),
                Via = response.SelectSingleNode("//via[1]")?.InnerText,
                FutureChangeTo = response.SelectSingleNode("//futureChangeTo[1]")?.InnerText.GetEnumFromStringValue<ServiceType>(),
                AssocIsCancelled = response.SelectSingleNode("//assocIsCancelled")?.InnerText.TryParseBoolNullable()
            };

            return darwinObj;
        }
    }
}
