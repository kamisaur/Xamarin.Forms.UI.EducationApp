using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EducationApp.Templates
{
    public partial class LessonTemplate : Grid
    {
        public LessonTemplate()
        {
            InitializeComponent();
        }

        void TouchEff_Completed(Xamarin.Forms.VisualElement sender, TouchEffect.EventArgs.TouchCompletedEventArgs args)
        {
            // needed for tap animation
        }
    }
}
