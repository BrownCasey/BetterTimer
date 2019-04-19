using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using BetterTimer.Droid;

[assembly: Dependency(typeof(AlarmAndroid))]
namespace BetterTimer.Droid
{
    public class AlarmAndroid : Activity, AlarmMgr
    {

        public int setAlarm(DateTime d)
        {
            AlarmManager manager = (AlarmManager)Android.App.Application.Context.GetSystemService(Context.AlarmService);
            Intent intent;
            PendingIntent pendingIntent;

            intent = new Intent(Android.App.Application.Context, typeof(AlarmReceiver));
            pendingIntent = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, intent, 0);
            //manager.SetExact(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 3000, pendingIntent);
            manager.SetExact(AlarmType.RtcWakeup, new DateTimeOffset(d).ToUnixTimeMilliseconds(), pendingIntent);
            return d.Date.Minute;
        }
    }
}