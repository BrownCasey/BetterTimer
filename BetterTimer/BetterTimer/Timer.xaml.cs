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
        public System.Timers.Timer cdTimer = new System.Timers.Timer();
        public TimeSpan countdown;
        public TimeSpan tenthSecond = new TimeSpan(1000000);
        public TimePicker pickr = new TimePicker();
        public ISimpleAudioPlayer player { get; set; }
        public bool play;

        public Timer ()
		{
			InitializeComponent ();
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("BetterTimer.Audio.Alarm09.wav");
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);
            cdTimer.Interval = 100;
            cdTimer.Elapsed += TimerElapsed;
		}

        private void OnStart(object sender, EventArgs e)
        {
            countdown = TimePicked.Time;
            cdTimer.Enabled = true;
            cdTimer.Start();
            play = true;
        }

        public void TimerElapsed(object sender, EventArgs e)
        {
            if (countdown < tenthSecond)
            {
                CountdownDisplay.Text = tenthSecond.ToString(@"hh\:mm\:ss");
                cdTimer.Stop();
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

        public void OnStop(object sender, EventArgs e)
        {
            play = false;
        }

        async void AlertMe(string s)
        {
            await DisplayAlert("Countdown", s, "OK");
        }
    }
}