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
        public AlarmPage (AlarmPageViewModel vm)
		{
            
            BindingContext = vm;
            VM = vm;
            InitializeComponent();
        }

        public void AddAlarm(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewAlarm(VM));
        }
	}
}