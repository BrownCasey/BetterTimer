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
using System.Diagnostics;

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
        public TimeSpan halfSecond = new TimeSpan(5000000);
        public TimePicker pickr = new TimePicker();
        public ISimpleAudioPlayer player { get; set; }
        public bool play;

        public Timer()
        {
            InitializeComponent();
            CountdownDisplay.Text = String.Format(@"{0:D2}:{1:D2}:{2:D2}", cdHours, cdMinutes, cdSeconds);

            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("BetterTimer.Audio.Alarm09.wav");
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);

        }

        private void OnStart(object sender, EventArgs e)
        {
            if (cdTimer == null)
            {
                countdown = new TimeSpan(cdHours, cdMinutes, cdSeconds);
                cdTimer = new System.Timers.Timer();
                play = true;
                cdTimer.Interval = 500;
                cdTimer.Elapsed += TimerElapsed;
                cdTimer.Enabled = true;
                cdTimer.Start();
            }
            else if (cdTimer.Enabled == false)
            {
                cdTimer.Start();
            }
            else
                Debug.WriteLine("Timer already started");
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            if (countdown < halfSecond)
            {
                CountdownDisplay.Text = halfSecond.ToString(@"hh\:mm\:ss");
                cdTimer.Stop();
                while (play == true)
                {
                    if (!player.IsPlaying)
                        player.Play();
                    else
                        Thread.Sleep(100);
                }
            }
            else
            {
                countdown -= halfSecond;
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => CountdownDisplay.Text = countdown.ToString(@"hh\:mm\:ss"));
            }
        }
        
        private void OnStop(object sender, EventArgs e)
        {
            // in some stop/start scenario still getting state error
            play = false;
            player.Stop();
            cdTimer = null;
            ResetSlider();
        }

        private void OnPause(object sender, EventArgs e)
        {
            if (cdTimer != null)
            {
                cdTimer.Stop();
            }
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

        private void ResetSlider()
        {
            SliderHr.Value = 0;
            SliderMin.Value = 0;
            SliderSec.Value = 0;
        }
    }
}