using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EducationApp.Templates
{
    public partial class CourseTemplate : Grid
    {
        public CourseTemplate()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            contentFrame.WidthRequest = Application.Current.MainPage.Width - (38 * 3);
        }

        void TouchEff_Completed(Xamarin.Forms.VisualElement sender, TouchEffect.EventArgs.TouchCompletedEventArgs args)
        {
        }
    }
}
