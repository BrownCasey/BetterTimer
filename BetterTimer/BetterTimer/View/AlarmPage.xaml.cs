using BetterTimer.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetterTimer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlarmPage : ContentPage
	{
        private AlarmPageViewModel vm;
        public List<Alarm> AlarmItems { get; set; }
        public AlarmPage ()
		{
            vm = new AlarmPageViewModel();
            BindingContext = vm;
            AlarmItems = new List<Alarm> {
                new Alarm
                {
                    AlarmTitle = "First",
                    AlarmTime = new DateTime(2019, 4, 12, 9, 30, 30)
                },
                new Alarm
                {
                    AlarmTitle = "Second",
                    AlarmTime = new DateTime(2019, 4, 12, 9, 30, 30)
                }
            };
            InitializeComponent();
        }

        public void AddAlarm(object sender, EventArgs e)
        {

        }
	}
}