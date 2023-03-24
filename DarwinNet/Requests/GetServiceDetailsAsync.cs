using DarwinNet.Exceptions;
using DarwinNet.Factories;
using DarwinNet.Helpers;
using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinNet.Requests
{
    public partial class Requests : IRequests
    {
        /// <summary>
        /// Returns service details for a specific service identified by a station board. These details are supplied relative to the station board from which the serviceID field value was generated. 
        /// Service details are only available while the service appears on the station board from which it was obtained. This is normally for two minutes after it is expected to have departed, 
        /// or after a terminal arrival. 
        /// </summary>
        /// <param name="serviceId">The service ID of the service to request the details of. The service ID is obtained from a service listed in a StationBoard object returned from any other request.</param>
        /// <returns>A <see cref="ServiceDetails"/> object containing the requested details.</returns>
        public Task<ServiceDetails> GetServiceDetailsAsync(string serviceId)
        {
            var requestParams = new Dictionary<string, object>()
            {
                { "serviceID", serviceId }
            };

            return GetServiceDetailsInternal(requestParams);
        }

        private async Task<ServiceDetails> GetServiceDetailsInternal(Dictionary<string, object> requestParams)
        {
            var soapEnvelope = BuildDarwinSoapEnvelope("GetServiceDetails", requestParams);
            var response = await SendDarwinSoapRequestAsync(soapEnvelope, ServiceDetailsFactory.Instance);
            return response;
        }
    }
}
