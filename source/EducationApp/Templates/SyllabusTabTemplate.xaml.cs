using System;
using System.Collections.Generic;
using EducationApp.ViewModels;
using Xamarin.Forms;

namespace EducationApp.Templates
{
    public partial class SyllabusTabTemplate : Grid
    {
        public SyllabusTabTemplate()
        {
            InitializeComponent();
            BindingContext = this;

        }
    }
}
