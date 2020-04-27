using System;
using System.Collections.ObjectModel;
using EducationApp.Models;
using Xamarin.Forms;

namespace EducationApp.ViewModels
{
    public class HomeViewModel
    {
        public UserModel User { get; set; }

        public ObservableCollection<CourseItemViewModel> Courses { get; set; } 

        public ObservableCollection<LessonModel> TodaysLessons { get; set; } 

        public HomeViewModel()
        {
            User = SharedState.GetUser();
            Courses = SharedState.GetCourses();
            TodaysLessons = SharedState.GetTodaysLessons();
        }
    }
}

