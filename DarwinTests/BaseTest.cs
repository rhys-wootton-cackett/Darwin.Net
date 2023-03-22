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
            Darwin = new DarwinNet.Darwin();
        }
    }
}