using System;
using EducationApp.Models;
using Xamarin.Forms;

namespace EducationApp.Helpers
{
    public static class ThemeHelper
    {
        public static void ChangeTheme(Theme theme, bool forceTheme = false)
        {

            var background = (Color)App.Current.Resources["Background"];

            var environment = DependencyService.Get<IEnvironment>();
            environment?.SetStatusBarColor(background, true);
            //environment?.SetStatusBarColor(background, theme != Theme.Dark);
        }

    }
}
