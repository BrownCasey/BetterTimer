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
        public TimePicker pickr = new TimePicker();

		public Timer ()
		{
            cdTimer.Interval = 100;
            cdTimer.Elapsed += TimerElapsed;
			InitializeComponent ();
		}

        private void OnStart(object sender, EventArgs e)
        {
            countdown = TimePicked.Time;
            cdTimer.Enabled = true;
            cdTimer.Start();
        }

        public void TimerElapsed(object sender, EventArgs e)
        {
            if (countdown < tenthSecond)
            {
                CountdownDisplay.Text = tenthSecond.ToString(@"hh\:mm\:ss");
                cdTimer.Stop();
                // TODO
                // Make noise
            }
            else
            {
                countdown -= tenthSecond;
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => CountdownDisplay.Text = countdown.ToString(@"hh\:mm\:ss"));
            }
        }

        async void AlertMe(string s)
        {
            await DisplayAlert("Countdown", s, "OK");
        }
    }
}