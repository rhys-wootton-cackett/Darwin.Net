using DarwinNet.Factories;
using DarwinNet.Helpers;
using DarwinNet.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DarwinNet.Requests
{
    /// <summary>
    /// Represents a collection of methods for making requests to the Darwin API.
    /// </summary>
    public partial class Requests : IRequests
    {
        private HttpClient _client;
        private readonly Configuration _config;
        private readonly string _darwinUrl;
        private readonly string _darwinActionNameUrl;
        private readonly string _darwinApiKey;
        private readonly string _darwinTokenTypeUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="Requests"/> class.
        /// </summary>
        /// <param name="client">The HTTP client used for making requests to the API.</param>
        /// <param name="config">The configuration for the API.</param>
        public Requests(HttpClient client, Configuration config)
        {
            this._client = client;
            this._config = config;
            this._darwinUrl = this._config.AppSettings.Settings["DarwinUrl"].Value ?? throw new InvalidOperationException("The DarwinUrl app setting is missing or invalid.");
            this._darwinActionNameUrl = this._config.AppSettings.Settings["DarwinActionNameUrl"].Value ?? throw new InvalidOperationException("The DarwinActionNameUrl app setting is missing or invalid.");
            this._darwinApiKey = this._config.AppSettings.Settings["DarwinApiKey"].Value ?? throw new InvalidOperationException("The DarwinApiKey app setting is missing or invalid.");
            this._darwinTokenTypeUrl = this._config.AppSettings.Settings["DarwinTokenTypeUrl"].Value ?? throw new InvalidOperationException("The DarwinTokenTypeUrl app setting is missing or invalid.");
        }

        /// <summary>
        /// Builds a SOAP envelope for a Darwin API request.
        /// </summary>
        /// <param name="methodName">The name of the Darwin API method to call.</param>
        /// <param name="requestParams">A dictionary of parameters to pass to the API method.</param>
        /// <returns>The SOAP envelope as a string.</returns>
        private string BuildDarwinSoapEnvelope(string methodName, Dictionary<string, object> requestParams)
        {
            var soapEnvelopeParams = new StringBuilder();

            foreach (var param in requestParams)
            {
                if (param.Value is List<Station> stations)
                {
                    soapEnvelopeParams.AppendLine($"<ldb:{param.Key}>");
                    stations.ForEach(s => soapEnvelopeParams.AppendLine($"<ldb:crs>{s.GetStringValue()}</ldb:crs>"));
                    soapEnvelopeParams.AppendLine($"</ldb:{param.Key}>");
                    continue;
                }

                soapEnvelopeParams.AppendLine($"<ldb:{param.Key}>{param.Value}</ldb:{param.Key}>");
            }

            return $"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ldb='{_darwinActionNameUrl}' xmlns:typ='{_darwinTokenTypeUrl}'><soapenv:Header><typ:AccessToken><typ:TokenValue>{_darwinApiKey}</typ:TokenValue></typ:AccessToken><soapenv:Action>{_darwinActionNameUrl}{methodName}</soapenv:Action></soapenv:Header><soapenv:Body><ldb:{methodName}Request>{soapEnvelopeParams}</ldb:{methodName}Request></soapenv:Body></soapenv:Envelope>";
        }

        /// <summary>
        /// Sends a SOAP request to the Darwin API and deserializes the response using a factory.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize the response to.</typeparam>
        /// <param name="soapEnvelope">The SOAP envelope containing the request parameters.</param>
        /// <param name="factory">The factory used to deserialize the XML response to an object of type <typeparamref name="T"/>.</param>
        /// <returns>An object of type <typeparamref name="T"/> deserialized from the XML response.</returns>
        private async Task<T> SendDarwinSoapRequestAsync<T>(string soapEnvelope, IFactory<T> factory)
        {
            var content = new StringContent(soapEnvelope.Replace(Environment.NewLine, ""), Encoding.UTF8, "text/xml");
            var response = await this._client.PostAsync(_darwinUrl, content);

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new ArgumentException("The request was invalid. Please contact the developer of Darwin.Net");

                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException("The request requires authentication. Have you provided a valid API token?");

                case HttpStatusCode.Forbidden:
                    throw new UnauthorizedAccessException("The user is not authorized to access the requested resource. Have you provided a valid API token?");

                case HttpStatusCode.NotFound:
                    throw new InvalidOperationException("The requested resource was not found. Please contact the developer of Darwin.Net");

                case HttpStatusCode.InternalServerError:
                    throw new HttpRequestException("An unexpected error occurred on the server. Please try again later. If this issue persists, please contact the developer of Darwin.Net");
            }

            var str = await response.Content.ReadAsStringAsync();

            var xml = new XmlDocument();
            xml.LoadXml(str);            

            return FactoryLoader.LoadFromXml(factory, xml);
        }
    }
}
