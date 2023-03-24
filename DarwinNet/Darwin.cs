using DarwinNet.Objects;
using DarwinNet.Requests;
using System.Configuration;
using System.Net.Http;

namespace DarwinNet
{
    /// <summary>
    /// Represents the main class for accessing Darwin API services.
    /// </summary>
    public class Darwin
    {
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// The collection of request methods that can be used to make requests to the Darwin API.
        /// </summary>
        public Requests.Requests Requests { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Darwin"/> class with default configurations.
        /// </summary>
        /// <param name="apiKey">Your API key to access the service</param>
        public Darwin(string apiKey)
        {
            this.Requests = new Requests.Requests(this._client, apiKey);
        }
    }
}