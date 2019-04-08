using System;
using System.IO;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetterTimer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoisePage : ContentPage
	{
        //Xam.Plugin.SimpleAudioPlayer
        //from-the-docs-https://devblogs.microsoft.com/xamarin/adding-sound-xamarin-forms-app
        public NoisePage ()
		{
			InitializeComponent ();
		}

        public void PlaySound(object sender, EventArgs e)
        {

            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("BetterTimer.Audio.Alarm09.wav");
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);
            player.Play();
        }
	}
}