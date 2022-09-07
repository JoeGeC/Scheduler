using System.Collections.Generic;
using NUnit.Framework;
using Scheduler.Source;

namespace Scheduler.Tests
{
    [TestFixture]
    public class ConfigConverterShould
    {
        private readonly ConfigConverter _configConverter = new ConfigConverter("16", "10");
        
        [Test]
        public void ConvertOneCommand()
        {
            const string expected = "1:30 tomorrow - /bin/run_me_daily";
            var result = _configConverter.Convert("30 1 /bin/run_me_daily");
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void CatchInvalidCommandOneInt()
        {
            var result = _configConverter.Convert("1 /bin/run_me_daily");
            Assert.AreEqual(ConfigConverter.ErrorMessage, result);
        }
        
        [Test]
        public void CatchInvalidCommandHourTooBig()
        {
            var result = _configConverter.Convert("30 24 /bin/run_me_daily");
            Assert.AreEqual(ConfigConverter.ErrorMessage, result);
        }
        
        [Test]
        public void CatchInvalidCommandMinuteTooBig()
        {
            var result = _configConverter.Convert("60 1 /bin/run_me_daily");
            Assert.AreEqual(ConfigConverter.ErrorMessage, result);
        }
        
        [Test]
        public void ConvertMultipleCommands()
        {
            var commands = new[]
            {
                "30 1 /bin/run_me_daily",
                "45 * /bin/run_me_hourly",
            };
            var expected = new List<string>
            {
                "1:30 tomorrow - /bin/run_me_daily",
                "16:45 today - /bin/run_me_hourly"
            };
            var result = _configConverter.Convert(commands);
            Assert.AreEqual(expected, result);
        }
    }
}