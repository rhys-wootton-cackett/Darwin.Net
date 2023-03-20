using Darwin.Net.Objects;
using Darwin.Net.Requests;
using System.Configuration;

namespace Darwin.Net
{
    /// <summary>
    /// Represents the main class for accessing Darwin API services.
    /// </summary>
    public class Darwin
    {
        private readonly HttpClient _client = new();

        /// <summary>
        /// The collection of request methods that can be used to make requests to the Darwin API.
        /// </summary>
        public IRequests Requests { get; private set; }

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