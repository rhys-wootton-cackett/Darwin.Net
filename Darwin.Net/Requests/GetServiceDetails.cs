using Darwin.Net.Exceptions;
using Darwin.Net.Factories;
using Darwin.Net.Helpers;
using Darwin.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darwin.Net.Requests
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
