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
    }
}
