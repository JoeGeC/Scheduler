using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Source
{
    public class ConfigConverter
    {
        internal const string ErrorMessage = "Please enter a valid command";
        private Scheduler Scheduler { get; }

        public ConfigConverter(string currentHourString, string currentMinuteString)
        {
            int.TryParse(currentHourString, out var currentHour);
            int.TryParse(currentMinuteString, out var currentMinute);
            Scheduler = new Scheduler(currentHour, currentMinute);
        }

        public IEnumerable<string> Convert(string[] commands)
        {
            return commands.Select(Convert);
        }

        public string Convert(string config)
        {
            try
            {
                var split = config.Split(' ');
                var command = split[2];
                var hour = ConvertHourMinute(split[1]);
                var minutes = ConvertHourMinute(split[0]);
                if (hour > 23 || minutes > 59) throw new Exception();
                return $"{Scheduler.GetNextTimeOf(hour, minutes)} - {command}";
            }
            catch (Exception e)
            {
                return ErrorMessage;
            }
        }

        private static int ConvertHourMinute(string hour)
        {
            if (hour == "*") return -1;
            return int.Parse(hour);
        }
    }
}