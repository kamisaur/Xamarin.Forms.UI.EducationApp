using System;
using System.Collections.ObjectModel;
using EducationApp.Models;
using Xamarin.Forms;

namespace EducationApp.ViewModels
{
    public class HomeViewModel
    {
        public UserModel User { get; set; }

        public ObservableCollection<CourseModel> Courses { get; set; } 

        public ObservableCollection<LessonModel> TodaysLessons { get; set; } 

        public HomeViewModel()
        {
            User = SharedState.GetUser();
            Courses = SharedState.GetCourses();
            TodaysLessons = SharedState.GetTodaysLessons();

            //TodaysLessons = new ObservableCollection<LessonModel>
            //{
            //    new LessonModel
            //    {
            //        LessonNumber = 36,
            //        LessonTitle = "The Present Perfect",
            //        LessonDuration = TimeSpan.FromMinutes(80)
            //    }
            //};


        }
    }
}

