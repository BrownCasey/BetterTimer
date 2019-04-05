using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetterTimer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Timer : ContentPage
	{
        public System.Timers.Timer cdTimer = new System.Timers.Timer();
        public TimeSpan countdown;
        public TimeSpan tenthSecond = new TimeSpan(1000000);
		public Timer ()
		{
            countdown = new TimeSpan(100000000);
            cdTimer.Interval = 100;
            cdTimer.Elapsed += TimerElapsed;
			InitializeComponent ();
		}

        private void OnStart(object sender, EventArgs e)
        {
            cdTimer.Enabled = true;
            cdTimer.Start();
        }

        public void TimerElapsed(object sender, EventArgs e)
        {
            if (countdown < tenthSecond)
            {
                CountdownDisplay.Text = tenthSecond.ToString(@"hh\:mm\:ss\:ff");
                cdTimer.Stop();
                AlertMe("Countdown Ended");
            }
            else
            {
                countdown -= tenthSecond;
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => CountdownDisplay.Text = countdown.ToString(@"hh\:mm\:ss\:ff"));
            }
        }

        // This alert doesn't appear, closes app.
        async void AlertMe(string s)
        {
            await DisplayAlert("Countdown", s, "OK");
        }
    }
}