using System;
using System.Linq;
using EducationApp.Helpers;
using EducationApp.Models;
using EducationApp.Services;
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

            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                if(a.RequestedTheme == OSAppTheme.Dark)
                    ThemeHelper.ChangeTheme(Theme.Dark, true);
                else
                    ThemeHelper.ChangeTheme(Theme.Light, true);
            };
        }

        protected override void OnStart()
        {
            UpdateTheme();
        }

        protected override void OnSleep()
        {
            UpdateTheme();

        }

        protected override void OnResume()
        {
            UpdateTheme();

            //// in iOS the view members such as lists are not reevaluated on resume. In that case
            //// colors that are defined in model or from code wouldn't get updated. Need to reassign the list
            //// so the os sees the update and redraws ui for collections
            var bindingContext = (IUpdatable)Current.MainPage.Navigation.NavigationStack.LastOrDefault().BindingContext;
            bindingContext.Update(true);
        }


        private void UpdateTheme()
        {
            if (Current.RequestedTheme == OSAppTheme.Dark)
                SharedState.ThemeOption = Theme.Dark;
            else
                SharedState.ThemeOption = Theme.Light;

            ThemeHelper.ChangeTheme(SharedState.ThemeOption, true);
        }
    }
}
