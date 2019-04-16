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
            // there's no bundle savedInstanceState because I'm not treating this Activity like a Page, which I should
            //requires <uses-permission android:name="com.android.alarm.permission.SET_ALARM" />
            //Java.Lang.IllegalStateException: System services not available to Activities before onCreate()
            StartActivity(typeof(MainActivity));
            var context = MainActivity.Instance;
            Intent intent;
            PendingIntent pendingIntent;

            intent = new Intent(this, typeof(AlarmReceiver));
            pendingIntent = PendingIntent.GetBroadcast(this, 0, intent, 0);
            AlarmManager manager = (AlarmManager)GetSystemService(MainActivity.AlarmService);
            manager.Set(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 3000, pendingIntent);
            return d.Date.Minute;
        }
    }
}