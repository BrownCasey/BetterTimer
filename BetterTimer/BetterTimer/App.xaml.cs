using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BetterTimer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // cast MainPage as NavigationPage go navigate pages
            MainPage = new NavigationPage( new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
