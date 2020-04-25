using System;
using System.Collections.Generic;
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
    }
}
