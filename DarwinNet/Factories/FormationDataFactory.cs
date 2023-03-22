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
    /// Defines a <see cref="IFactory{FormationData}"/> that can create a <see cref="FormationData"/>
    /// </summary>
    internal class FormationDataFactory : IFactory<FormationData>
    {
        /// <summary>
        /// Returns a static instance of <see cref="FormationDataFactory"/>
        /// </summary>
        public static FormationDataFactory Instance { get; } = new FormationDataFactory();

        /// <summary>
        /// Creates a new <see cref="FormationData"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="FormationData"/></returns>
        public FormationData Create(XmlDocument response)
        {
            var darwinObj = new FormationData
            {
                Coaches = (response.SelectSingleNode("//coaches[1]") ?? throw new InvalidDarwinDataException("coaches")).ChildNodes.OfType<XmlElement>()
                                    .Select(e => FactoryLoader.XmlElementToT(CoachDataFactory.Instance, e)).ToList()
            };

            return darwinObj;
        }
    }
}
