using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Scheduler.Tests
{
    [TestFixture]
    public class FileReaderShould
    {
        [Test]
        public void ReadFromFile()
        {
            var expected = new[]
            {
                "30 1 /bin/run_me_daily",
                "45 * /bin/run_me_hourly",
                "* * /bin/run_me_every_minute",
                "* 19 /bin/run_me_sixty_times"
            };
            var textFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "../../ExampleConfig.txt");
            Assert.AreEqual(expected, FileReader.ReadFile(textFilePath));
        }
    }
}