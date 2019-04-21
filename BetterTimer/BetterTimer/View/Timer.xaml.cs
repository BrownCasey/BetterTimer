using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using System.Threading;

namespace BetterTimer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Timer : ContentPage
	{
        public int cdHours = 0;
        public int cdMinutes = 0;
        public int cdSeconds = 0;
        public System.Timers.Timer cdTimer { get; set; }
        public TimeSpan countdown;
        public TimeSpan tenthSecond = new TimeSpan(1000000);
        public TimePicker pickr = new TimePicker();
        public ISimpleAudioPlayer player { get; set; }
        public bool play;

        public Timer ()
		{
			InitializeComponent ();
            CountdownDisplay.Text = String.Format(@"{0:D2}:{1:D2}:{2:D2}", cdHours, cdMinutes, cdSeconds);

            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("BetterTimer.Audio.Alarm09.wav");
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);

		}

        private void OnStart(object sender, EventArgs e)
        {
            countdown = new TimeSpan(cdHours, cdMinutes, cdSeconds);
            cdTimer = new System.Timers.Timer();
            cdTimer.Interval = 100;
            cdTimer.Elapsed += TimerElapsed;
            cdTimer.Enabled = true;
            cdTimer.Start();
            play = true;
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            if (countdown < tenthSecond)
            {
                CountdownDisplay.Text = tenthSecond.ToString(@"hh\:mm\:ss");
                cdTimer.Stop();
                // sleep allows this while to be triggered again if user quick hits stop then start
                while (play == true)
                {
                    player.Play();
                    //TODO Sleep the length of alarm
                    Thread.Sleep(6000);
                }
            }
            else
            {
                countdown -= tenthSecond;
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => CountdownDisplay.Text = countdown.ToString(@"hh\:mm\:ss"));
            }
        }

        private void OnStop(object sender, EventArgs e)
        {
            play = false;
            player.Stop();
            cdTimer = null;
        }

        private void OnPause(object sender, EventArgs e)
        {
            cdTimer.Stop();
        }

        async void AlertMe(string s)
        {
            await DisplayAlert("Countdown", s, "OK");
        }

        private void OnHourChanged(object sender, ValueChangedEventArgs e)
        {
            cdHours = (int)e.NewValue;
            CountdownDisplay.Text = String.Format(@"{0:D2}:{1:D2}:{2:D2}", cdHours, cdMinutes, cdSeconds);
        }

        private void OnMinuteChanged(object sender, ValueChangedEventArgs e)
        {
            cdMinutes = (int)e.NewValue;
            CountdownDisplay.Text = String.Format(@"{0:D2}:{1:D2}:{2:D2}", cdHours, cdMinutes, cdSeconds);
        }

        private void OnSecondChanged(object sender, ValueChangedEventArgs e)
        {
            cdSeconds = (int)e.NewValue;
            CountdownDisplay.Text = String.Format(@"{0:D2}:{1:D2}:{2:D2}", cdHours, cdMinutes, cdSeconds);
        }

    }
}