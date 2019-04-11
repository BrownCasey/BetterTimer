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
        public ObservableCollection<Alarm> Items { get; set; }

        public AlarmPage ()
		{
			InitializeComponent ();

            Label header = new Label()
            {
                Text = "A List of Alarms",
                FontSize = 20
            };

            ListView MyListView = new ListView();
            Items = new ObservableCollection<Alarm>
            {
                new Alarm {AlarmTitle = "First",
                            AlarmTime = new DateTime(2019, 04, 10, 06, 10, 10),
                            AlarmDuration = new TimeSpan(1000000)},
                new Alarm {AlarmTitle = "Second",
                            AlarmTime = new DateTime(2019, 04, 10, 06, 10, 10),
                            AlarmDuration = new TimeSpan(1000000)}
            };

            MyListView.ItemsSource = Items;
            //MyListView.ItemTemplate =

            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    MyListView
                }
            };
        }
	}
}