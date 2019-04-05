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
	public partial class Stopwatch : ContentPage
	{
        public System.Timers.Timer swTimer;
        public TimeSpan counter { get; set; }
        public TimeSpan tenthSecond = new TimeSpan(1000000);
		public Stopwatch ()
		{
            counter = new TimeSpan(0);
            swTimer = new System.Timers.Timer();
            swTimer.Interval = 100;
            swTimer.Elapsed += TimerLoop;
			InitializeComponent ();
		}
        
        public void OnStart(object sender, EventArgs e)
        {
            swTimer.Enabled = true;
            swTimer.Start();
        }
        public void OnPause(object sender, EventArgs e)
        {
            swTimer.Stop();
        }
        public void OnReset(object sender, EventArgs e)
        {
            AlertMe("Stopwatch Reset");
            counter = new TimeSpan(0);
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => ClockDisplay.Text = counter.ToString(@"hh\:mm\:ss\:f"));
        }

        private void TimerLoop(object sender, EventArgs e)
        {
            counter += tenthSecond;
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => ClockDisplay.Text = counter.ToString(@"hh\:mm\:ss\:f"));
        }

        async void AlertMe(string s)
        {
            await DisplayAlert("Stopwatch", s, "OK");
        }
    }
}