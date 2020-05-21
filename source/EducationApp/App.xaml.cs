using System;
using EducationApp.Helpers;
using EducationApp.Models;
using EducationApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EducationApp
{
    public partial class App : Application
    {
        public App()
        {

            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });


            InitializeComponent();

            MainPage = new NavigationPage(new HomeView());
            //MainPage = new NavigationPage(new CourseOverviewView());
        }

        protected override void OnStart()
        {
            ThemeHelper.ChangeTheme(Theme.Light, true);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            ThemeHelper.ChangeTheme(Theme.Light, true);
        }
    }
}
