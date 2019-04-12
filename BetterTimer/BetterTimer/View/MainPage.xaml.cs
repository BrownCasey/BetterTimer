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
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnSend(object sender, EventArgs e)
        {
            Message.Text = "Welcome to Better Timer, " + MyName.Text;
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
            Navigation.PushAsync(new AlarmPage());
        }

        private void ClearForm()
        {
            MyName.Text = String.Empty;
        }
    }
}
