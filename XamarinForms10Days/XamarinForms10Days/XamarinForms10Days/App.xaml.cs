using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms10Days.Views;

namespace XamarinForms10Days
{
    public partial class App : Application
    {
        public static string DatabasePath;
        public App()
        {
            InitializeComponent();
            MainPage = new ExperiencesPage();
        }

        public App(string databasePath) {
            InitializeComponent();
            MainPage = new ExperiencesPage(); // added using TenDaysOfXamarin.Views;
            DatabasePath = databasePath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
