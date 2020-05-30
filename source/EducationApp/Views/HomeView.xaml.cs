using System;
using System.Collections.Generic;
using EducationApp.Helpers;
using EducationApp.Models;
using EducationApp.Services;
using EducationApp.ViewModels;
using Xamarin.Forms;

namespace EducationApp.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }

        void TouchEff_Completed(Xamarin.Forms.VisualElement sender, TouchEffect.EventArgs.TouchCompletedEventArgs args)
        {
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();


            // in iOS the view members such as lists are not reevaluated on resume. In that case
            // colors that are defined in model or from code wouldn't get updated. Need to reassign the list
            // so the os sees the update and redraws ui for collections
            var bindingContext = (IUpdatable)this.BindingContext;
            bindingContext.Update();
        }

        void ThemeIcon_Pressed(Xamarin.Forms.VisualElement sender, TouchEffect.EventArgs.TouchCompletedEventArgs args)
        {
            UpdateTheme();
            ((IUpdatable)this.BindingContext).Update();
        }



        public static void UpdateTheme()
        {
            if (SharedState.ThemeOption == Theme.Light)
                SharedState.ThemeOption = Theme.Dark;
            else
                SharedState.ThemeOption = Theme.Light;

            ThemeHelper.ChangeTheme(SharedState.ThemeOption, true);
        }


    }
}
