using BetterTimer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BetterTimer
{
    public partial class MainPage : ContentPage
    {
        public AlarmPageViewModel VM { get; set; }
        public DateTime timeNow { get; set; }
        public MainPage()
        {
            VM = new AlarmPageViewModel();
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(5.0), OnTimer);
        }

        public void GoTimer(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Timer());
        }

        public void GoStopwatch(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Stopwatch());
        }

        public void GoAlarm(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlarmPage(VM));
        }

        private bool OnTimer()
        {
            timeNow = DateTime.Now;
            ClockTime.Text = timeNow.ToString(@"HH:mm tt");
            TodaysDate.Text = timeNow.ToString(@"ddd, MMM dd, yyyy");
            return true;
        }
        
    }
}
