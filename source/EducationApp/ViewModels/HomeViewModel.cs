using System;
using EducationApp.Models;
using Xamarin.Forms;

namespace EducationApp.ViewModels
{
    public class HomeViewModel
    {
        public UserModel User { get; set; }


        public HomeViewModel()
        {
            User = new UserModel
            {
                Name = "John Wilson",
                Age = 22,
                Position = "Frontend Developer",
                Rating = 3,
            };



        }
    }
}

