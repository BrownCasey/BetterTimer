using BetterTimer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetterTimer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewAlarm : ContentPage
	{
        public AlarmPageViewModel VM { get; set; }
        public NewAlarm (AlarmPageViewModel vm)
		{
            VM = vm;
            BindingContext = vm;
			InitializeComponent ();
		}

        public void AddAlarm(object sender, EventArgs e)
        {
            VM.AddAlarm(new Alarm {
                AlarmTitle = NewTitle.Text,
                AlarmTime = new DateTime(
                    NewDate.Date.Year, NewDate.Date.Month, NewDate.Date.Day, 
                    NewTime.Time.Hours, NewTime.Time.Minutes, NewTime.Time.Seconds)
            });
        }

        public void GoAlarm(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlarmPage(VM));
        }
	}
}