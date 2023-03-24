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
        public Darwin()
        {
            var configFile = "app.config";
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            this.Requests = new Requests.Requests(this._client, configuration);
        }
    }
}