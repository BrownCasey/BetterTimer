using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetterTimer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmList : ContentPage
    {
        public ObservableCollection<Alarm> Items { get; set; }

        public AlarmList()
        {
            InitializeComponent();

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
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        
    }
}
