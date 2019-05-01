using BetterTimer.View;
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
        public AlarmPageViewModel VM { get; set; }
        public AlarmPage ()
		{
            
            VM = new AlarmPageViewModel();
            BindingContext = VM;
            InitializeComponent();
        }

        public void AddAlarm(object sender, EventArgs e)
        {
            // probably don't need this VM arg, just get new on NewAlarm
            Navigation.PushAsync(new NewAlarm());
        }

        public void ClearAlarms(object sender, EventArgs e)
        {
            VM.ClearAlarms();

            // Doesn't reload as I hoped
            //Navigation.PushAsync(new NewAlarm(VM));
        }

	}
}