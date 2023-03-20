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
    /// Defines a <see cref="IFactory{CallingPoint}"/> that can create a <see cref="CallingPoint"/>
    /// </summary>
    internal class CallingPointFactory : IFactory<CallingPoint>
    {
        /// <summary>
        /// Returns a static instance of <see cref="CallingPointFactory"/>
        /// </summary>
        public static CallingPointFactory Instance { get; } = new CallingPointFactory();

        /// <summary>
        /// Creates a new <see cref="CallingPoint"/> object.
        /// </summary>
        /// <param name="response">A <see cref="XmlDocument"/> containing data to be put into the object.</param>
        /// <returns>An instance of <see cref="CallingPoint"/></returns>
        public CallingPoint Create(XmlDocument response)
        {
            var darwinObj = new CallingPoint
            {
                LocationName = (response.SelectSingleNode("//locationName[1]") ?? throw new InvalidDarwinDataException("locationName")).InnerText,
                Station = (response.SelectSingleNode("//crs[1]") ?? throw new InvalidDarwinDataException("crs")).InnerText.GetEnumFromStringValue<Station>(),
                ScheduleTime = response.SelectSingleNode("//st[1]")?.InnerText.ParseDarwinTime(),
                EstimatedTime = response.SelectSingleNode("//et[1]")?.InnerText.ParseDarwinTime(),
                ActualTime = response.SelectSingleNode("//at[1]")?.InnerText.ParseDarwinTime(),
                IsCancelled = response.SelectSingleNode("//isCancelled[1]")?.InnerText.TryParseBoolNullable(),
                TrainLength = response.SelectSingleNode("//length[1]")?.InnerText.TryParseIntNullable(),
                DoesTrainDetachAtFront = response.SelectSingleNode("//detachFront[1]")?.InnerText.TryParseBoolNullable(),
                AdhocAlerts = response.SelectSingleNode("//adhocAlerts[1]")?.ChildNodes.Cast<XmlNode>().Select(m => m.InnerText.CleanHtml()).ToList()
            };

            return darwinObj;
        }
    }
}
