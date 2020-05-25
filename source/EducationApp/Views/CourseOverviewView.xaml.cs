using System;
using System.Collections.Generic;
using EducationApp.Services;
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


        public void Back_Tapped(Xamarin.Forms.VisualElement sender, TouchEffect.EventArgs.TouchCompletedEventArgs args)
        {
            Navigation.PopAsync();
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
    }
}
