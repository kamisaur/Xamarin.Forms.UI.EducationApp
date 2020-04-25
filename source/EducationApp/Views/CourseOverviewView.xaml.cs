using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EducationApp.Views
{
    public partial class CourseOverviewView : ContentPage
    {
        public CourseOverviewView()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
