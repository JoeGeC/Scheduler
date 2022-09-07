namespace Scheduler
{
    public class Scheduler
    {
        private int HourResult { get; set; }
        private int CurrentHour { get; }
        private int CurrentMinute { get; }

        public Scheduler(int currentHour, int currentMinute)
        {
            CurrentHour = currentHour;
            CurrentMinute = currentMinute;
        }

        public string GetNextTimeOf(int scheduledHour, int scheduledMinutes)
        {
            HourResult = HandleAnyHour(scheduledHour, scheduledMinutes);
            var minuteResult = HandleAnyMinute(scheduledHour, scheduledMinutes);
            if (HourResult < CurrentHour || (HourResult == CurrentHour && minuteResult <= CurrentMinute))
                return $"{FormatTime(HourResult, minuteResult)} tomorrow";
            return $"{FormatTime(HourResult, minuteResult)} today";
        }

        private int HandleAnyHour(int scheduledHour, int scheduledMinutes)
        {
            if (scheduledHour != -1) return scheduledHour;
            if (scheduledMinutes > CurrentMinute || scheduledMinutes == -1)
                return CurrentHour;
            return IncrementHour();
        }

        private int IncrementHour()
        {
            var result = CurrentHour + 1;
            return result >= 24 ? 0 : result;
        }

        private int HandleAnyMinute(int scheduledHour, int scheduledMinutes)
        {
            if (scheduledMinutes != -1) return scheduledMinutes;
            if (scheduledHour == CurrentHour || scheduledHour == -1) 
                return IncrementMinute();
            return 0;
        }

        private int IncrementMinute()
        {
            var result = CurrentMinute + 1;
            if (result < 60) 
                return result;
            IncrementHourResult();
            return 0;
        }

        private void IncrementHourResult()
        {
            HourResult++;
            if (HourResult >= 24)
                HourResult = 0;
        }

        private static string FormatTime(int hour, int minutes)
        {
            return $"{hour}:{minutes:00}";
        }
    }
}