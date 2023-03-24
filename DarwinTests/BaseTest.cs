using System.Configuration;

namespace DarwinTests
{
    /// <summary>
    /// Used as an extended class to create instances of Darwin when testing.
    /// </summary>
    public class BaseTest
    {
        public DarwinNet.Darwin Darwin { get; set; }

        [SetUp]
        public void Setup()
        {
            var configFile = "app.config";
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            Darwin = new DarwinNet.Darwin(configuration.AppSettings.Settings["DarwinApiKey"].Value);
        }
    }
}