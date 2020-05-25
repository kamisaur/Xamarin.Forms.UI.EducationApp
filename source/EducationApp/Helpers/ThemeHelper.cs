using System;
using EducationApp.Models;
using EducationApp.Themes;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EducationApp.Helpers
{
    public static class ThemeHelper
    {
        public static Theme CurrentTheme = SharedState.ThemeOption;


        public static void ChangeTheme(Theme theme, bool forceTheme = false)
        {
            // don't change to the same theme
            if (theme == CurrentTheme && !forceTheme)
                return;

            //// clear all the resources
            var applicationResourceDictionary = Application.Current.Resources;
            if (theme == Theme.Default)
            {
                theme = AppInfo.RequestedTheme == AppTheme.Dark
                    ? Theme.Dark
                    : Theme.Light;
            }

            ResourceDictionary newTheme;
            switch (theme)
            {
                case Theme.Light:
                    newTheme = new LightTheme();
                    break;
                case Theme.Dark:
                    newTheme = new DarkTheme();
                    break;
                case Theme.Default:
                default:
                    newTheme = new LightTheme();
                    break;
            }

            CurrentTheme = theme;


            ManuallyCopyThemes(newTheme, applicationResourceDictionary);
            ChangeStatusBarColor(theme);
        }



        static void ManuallyCopyThemes(ResourceDictionary fromResource, ResourceDictionary toResource)
        {
            foreach (var item in fromResource.Keys)
            {
                toResource[item] = fromResource[item];
            }
        }

        static void ChangeStatusBarColor(Theme theme)
        {
            var background = (Color)App.Current.Resources["Background"];

            var environment = DependencyService.Get<IEnvironment>();
            environment?.SetStatusBarColor(background, theme != Theme.Dark);
        }



    }
}
