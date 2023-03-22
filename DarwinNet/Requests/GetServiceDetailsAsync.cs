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
