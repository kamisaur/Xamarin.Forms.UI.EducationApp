using System;
using EducationApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EducationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomeView());
            //MainPage = new NavigationPage(new CourseOverviewView());
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
