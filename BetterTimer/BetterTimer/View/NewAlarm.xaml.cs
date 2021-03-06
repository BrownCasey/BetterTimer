﻿using BetterTimer.ViewModel;
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
        public int AlarmManagerId { get; set; }
        public NewAlarm ()
		{
            VM = new AlarmPageViewModel();
            BindingContext = VM;
			InitializeComponent ();
		}

        public void AddAlarm(object sender, EventArgs e)
        {
            Alarm newAlarm = new Alarm
            {
                AlarmTitle = NewTitle.Text,
                AlarmTime = new DateTime(
                    NewDate.Date.Year, NewDate.Date.Month, NewDate.Date.Day,
                    NewTime.Time.Hours, NewTime.Time.Minutes, NewTime.Time.Seconds)
            };
            VM.AddAlarm(newAlarm);
            AlarmManagerId = DependencyService.Get<AlarmMgr>().setAlarm(newAlarm.AlarmTime);
            
            GoAlarm(sender, e);
        }

        public void GoAlarm(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AlarmPage());
        }
	}
}