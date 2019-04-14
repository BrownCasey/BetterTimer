using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace BetterTimer
{
    public class Alarm
    {
        [PrimaryKey, AutoIncrement]
        public int AlarmId { get; set; }
        [NotNull, MaxLength(50)]
        public string AlarmTitle { get; set; }
        [NotNull]
        public DateTime AlarmTime { get; set; }
    }
}
