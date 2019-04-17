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

namespace BetterTimer.Droid
{
    [BroadcastReceiver(Enabled = true)]
    class AlarmReceiver : BroadcastReceiver
    { 
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Time's up!", ToastLength.Long).Show();
        }
    }
}