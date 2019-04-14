using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BetterTimer.ViewModel
{
    public class AlarmPageViewModel
    {
        private SQLiteConnection database;
        private static object locker = new object();
        public List<Alarm> AlarmItems { get; set; }

        public AlarmPageViewModel()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Alarm>();
            this.AlarmItems = new List<Alarm>(database.Table<Alarm>());
            if (!database.Table<Alarm>().Any())
                AddNewAlarm();

            AlarmItems = GetAlarms();
        }

        public void AddNewAlarm()
        {
            AlarmItems.Add(
            new Alarm
            {
                AlarmTitle = "Wake up, Neo...",
                AlarmTime = new DateTime(2019, 4, 14, 9, 30, 30)
            });
        }

        public void AddAlarm(Alarm al)
        {
            AlarmItems.Add(al);
            SaveAlarm(al);
        }

        public int SaveAlarm(Alarm al)
        {
            lock (locker)
            {
                if(al.AlarmId != 0)
                {
                    database.Update(al);
                    return al.AlarmId;
                }
                else
                {
                    database.Insert(al);
                    return al.AlarmId;
                }
            }
        }

        public List<Alarm> GetAlarms()
        {
            lock (locker)
            {
                return (from r in database.Table<Alarm>()
                            select r).ToList();
            }
        }
    }

}
