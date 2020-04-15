using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EducationApp.Models;

namespace EducationApp
{
    public static class SharedState
    {
        /// <summary>
        /// This can be set from the server side
        /// </summary>
        private static Dictionary<string, string> _appColorsLight = new Dictionary<string, string>
        {
            { "Primary1", "#A6BD54" } ,
            { "Secondary1", "#C8D98D" } ,


            { "Primary2", "#00987F" } ,
            { "Secondary2", "#81BBB2" } ,


            { "Primary3", "#006998" } ,
            { "Secondary3", "#81A2BB" } ,
        };
        private static string ErrorColor = "#FF0000";

        public static string GetColor(string colorName)
        {
            if (_appColorsLight.TryGetValue(colorName, out string value))
            {
                return value;
            }
            else
            {
                return ErrorColor;
            }
        }


        private static UserModel _user = new UserModel
        {
            Name = "John Wilson",
            Age = 22,
            Position = "Frontend Developer",
            Rating = 3,
        };
        public static UserModel GetUser() => _user;


        private static ObservableCollection<CourseModel> _courses = new ObservableCollection<CourseModel>
        {
            new CourseModel
            {
                CourseName ="English Vocabulary (Full)",
                CompletedLessons = 35,
                TotalLessons = 210,
                CourseImageSource = "",
                PrimaryColor = "Primary1",
                SecondaryColor = "Secondary1",
            },
            new CourseModel
            {
                CourseName ="Python",
                CompletedLessons = 472,
                TotalLessons = 730,
                CourseImageSource = "",
                PrimaryColor = "Primary2",
                SecondaryColor = "Secondary2",
            },
            new CourseModel
            {
                CourseName ="Russian",
                CompletedLessons = 21,
                TotalLessons = 112,
                CourseImageSource = "",
                PrimaryColor = "Primary3",
                SecondaryColor = "Secondary3",
            }
        };
        public static ObservableCollection<CourseModel> GetCourses() => _courses;


        private static ObservableCollection<LessonModel> _todayLessons = new ObservableCollection<LessonModel>
        {
            new LessonModel
            {
                LessonNumber = 35,
                LessonTitle = "The Present Perfect",
                Color = "Primary1",
                LessonDuration = TimeSpan.FromMinutes(80)
            },
            new LessonModel
            {
                LessonNumber = 473,
                LessonTitle = "Advanced Topics",
                Color = "Primary2",
                LessonDuration = TimeSpan.FromMinutes(120)
            },
            new LessonModel
            {
                LessonNumber = 36,
                LessonTitle = "Vocabulary",
                Color = "Primary1",
                LessonDuration = TimeSpan.FromMinutes(30)
            },
            new LessonModel
            {
                LessonNumber = 474,
                LessonTitle = "Revision",
                Color = "Primary2",
                LessonDuration = TimeSpan.FromMinutes(20)
            },
            new LessonModel
            {
                LessonNumber = 1,
                LessonTitle = "Alphabet",
                Color = "Primary3",
                LessonDuration = TimeSpan.FromMinutes(45)
            },
        };
        public static ObservableCollection<LessonModel> GetTodaysLessons() => _todayLessons;
    }
}
