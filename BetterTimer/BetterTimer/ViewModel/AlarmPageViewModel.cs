using System;
using System.Collections.Generic;
using System.Text;

namespace BetterTimer.ViewModel
{
    public class AlarmPageViewModel
    {
        public List<Alarm> AlarmItems { get; set; }

        public AlarmPageViewModel()
        {
            AlarmItems = new List<Alarm> {
                new Alarm
                {
                    AlarmTitle = "First",
                    AlarmTime = new DateTime(2019, 4, 12, 9, 30, 30)
                },
                new Alarm
                {
                    AlarmTitle = "Second",
                    AlarmTime = new DateTime(2019, 4, 12, 9, 30, 30)
                }
            };
        }

        public void AddAlarm(Alarm al)
        {
            AlarmItems.Add(al);
        }
    }

}
