using System;
using System.Collections.Generic;
using System.Text;

namespace BetterTimer
{
    public class Alarm
    {
        public int AlarmId { get; set; }
        public string AlarmTitle { get; set; }
        public DateTime AlarmTime { get; set; }
        public TimeSpan AlarmDuration { get; set; }
    }
}
