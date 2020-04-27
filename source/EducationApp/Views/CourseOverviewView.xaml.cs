using System;
using System.Collections.Generic;
using EducationApp.ViewModels;
using Xamarin.Forms;

namespace EducationApp.Views
{
    public partial class CourseOverviewView : ContentPage
    {
        public CourseOverviewView(string courseName)
        {
            InitializeComponent();
            this.BindingContext = new CourseOverviewViewModel(courseName);
        }

        void Back_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void TouchEff_Completed(Xamarin.Forms.VisualElement sender, TouchEffect.EventArgs.TouchCompletedEventArgs args)
        {
        }
    }
}
