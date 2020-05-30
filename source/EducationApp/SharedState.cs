using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EducationApp.Models;
using EducationApp.Services;
using EducationApp.ViewModels;
using Xamarin.Essentials;

namespace EducationApp
{
    public static class SharedState
    {

        public static Theme ThemeOption
        {
            get => (Theme)Preferences.Get(nameof(ThemeOption),
                HasDefaultThemeOption
                    ? (int)Theme.Default
                    : (int)Theme.Light);

            set => Preferences.Set(nameof(ThemeOption), (int)value);
        }


        public static bool HasDefaultThemeOption
        {
            get
            {
                var minDefaultVersion = new Version(10, 0);
                return DeviceInfo.Version >= minDefaultVersion;
            }
        }


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
        private static string ErrorColorLight = "#FF0000";

        private static Dictionary<string, string> _appColorsDark = new Dictionary<string, string>
        {
            { "Primary1", "#59A6BD54" } ,
            { "Secondary1", "#99C8D98D" } ,


            { "Primary2", "#5900987F" } ,
            { "Secondary2", "#9981BBB2" } ,


            { "Primary3", "#59006998" } ,
            { "Secondary3", "#9981A2BB" } ,
        };
        private static string ErrorColorDark = "#99FF0000";


        public static string GetColor(string colorName)
        {
            if (ThemeOption == Theme.Dark)
            {
                if (_appColorsDark.TryGetValue(colorName, out string value))
                    return value;
                else
                    return ErrorColorLight;
            }
            else 
            {
                if (_appColorsLight.TryGetValue(colorName, out string value))
                    return value;
                else
                    return ErrorColorDark;
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


        static NavigationService _navigation = new NavigationService();



        private static List<CommentsModel> Comments { get; } = new List<CommentsModel>
        {
            new CommentsModel(
                "Mochi"
                , "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam dapibus fringilla ultrices." +
                " Nulla mi libero, pretium nec vestibulum at, bibendum eu nunc. Fusce vitae enim molestie nibh vulputate efficitur." +
                " Praesent ac condimentum massa, a fermentum velit. Suspendisse potenti. Curabitur non velit et sapien tempor elementum. "
                , new DateTime(20,3,15)),
            new CommentsModel(
                "Filipe"
                , "Phasellus vitae odio consectetur, bibendum nisi nec, fermentum mauris. Sed posuere vehicula nunc at finibus. " +
                "Nam tellus purus, egestas ut massa nec, rhoncus fermentum orci. Phasellus at lacinia sem. Pellentesque iaculis " +
                "quam quis arcu fringilla pellentesque. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per " +
                "inceptos himenaeos."
                , new DateTime(20,3,13)),
            new CommentsModel("Drago Alfredo", $"I learn in the youtube : 90% I learn in my school : 10%", new DateTime(20,3,12)),
            new CommentsModel(
                "April O'Neal"
                , $"This is a great course. I really learned a lot of things. " +
                $"And the instructions and teaching methods are easy to follow. I recommend it everyone " +
                $"who wants to improve their professional English skills."
                , new DateTime(20,3,11)),
            new CommentsModel(
                "Charles Counterbottom"
                , $"really I'm very enthusiastic in this course , " +
                $"the instructor gives me an important information which I didn't heard before , " +
                $"I'm very glade to this . thank to my instructor and thanks coursera <3"
                , new DateTime(20,3,10)),
        };




        private static ObservableCollection<CourseItemViewModel> _courses = new ObservableCollection<CourseItemViewModel>
        {
            new CourseItemViewModel(_navigation)
            {
                CourseName ="English Vocabulary (Full)",
                CompletedLessons = 35,
                TotalLessons = 210,
                CourseImageSource = "dictionary",
                PrimaryColor = "Primary1",
                SecondaryColor = "Secondary1",
                Comments = Comments,
                Syllabus = new List<SyllabusModel>
                {
                    new SyllabusModel(1, "Introductions", TimeSpan.FromMinutes(80), "Primary1", 1f),
                    new SyllabusModel(2, "Holidays / travel ", TimeSpan.FromMinutes(80), "Primary1", 0.9f),
                    new SyllabusModel(3, "House Items", TimeSpan.FromMinutes(80), "Primary1", 1f),
                    new SyllabusModel(4, "Car Parts", TimeSpan.FromMinutes(80), "Primary1", 1f),
                },
                Lessons = new List<LessonModel>
                {
                    new LessonModel(1, "English Phrases With Never", TimeSpan.FromMinutes(45), "Primary1" , 1f),
                    new LessonModel(2, "Phone Collocations in English", TimeSpan.FromMinutes(45), "Primary1" , 0.4f),
                    new LessonModel(3, "Learn 10 Telephoning Phrasal Verbs", TimeSpan.FromMinutes(45), "Primary1", 0.6f ),
                    new LessonModel(4, "English Expressions with You", TimeSpan.FromMinutes(45), "Primary1", 0.9f ),
                    new LessonModel(5, "Memory and Vocabulary Collocations", TimeSpan.FromMinutes(45), "Primary1", 0.8f ),
                    new LessonModel(6, "Compound nouns – Clothing", TimeSpan.FromMinutes(45), "Primary1", 0.4f ),
                    new LessonModel(7, "Summer holidays", TimeSpan.FromMinutes(45), "Primary1", 1f ),
                },
                Summary =
                    "This Comprehensive English: Overview & Practice " +
                    "course helps students complete their English homework and " +
                    "earn better grades. This homework help resource teaches all " +
                    "the important English concepts in a simple and fun video format." +
                    " Each of the video lessons is about five minutes long and is " +
                    "sequenced and organized just like a standard English curriculum."
            },
            new CourseItemViewModel(_navigation)
            {
                CourseName ="Learn Python",
                CompletedLessons = 472,
                TotalLessons = 730,
                CourseImageSource = "python",
                PrimaryColor = "Primary2",
                SecondaryColor = "Secondary2",
                Comments = Comments,
                Syllabus = new List<SyllabusModel>
                {
                    new SyllabusModel(1, "Python Syntax", TimeSpan.FromMinutes(90), "Primary2", 1f),
                    new SyllabusModel(2, "Console Output", TimeSpan.FromMinutes(87), "Primary2", 0.1f),
                    new SyllabusModel(3, "Conditional Flows", TimeSpan.FromMinutes(75), "Primary2", 0.0f),
                    new SyllabusModel(4, "Functions", TimeSpan.FromMinutes(80), "Primary2", 0.0f),
                },
                Lessons = new List<LessonModel>
                {
                    new LessonModel(1, "Wetting Your Appetite", TimeSpan.FromMinutes(90), "Primary2", 1f ),
                    new LessonModel(2, "Using the Python Interpreter", TimeSpan.FromMinutes(90), "Primary2", 0.2f ),
                    new LessonModel(3, "Invoking the Interpreter", TimeSpan.FromMinutes(90), "Primary2", 0.3f ),
                    new LessonModel(4, "Argument Passing", TimeSpan.FromMinutes(90), "Primary2", 0.4f ),
                    new LessonModel(5, "Interactive Mode", TimeSpan.FromMinutes(90), "Primary2" , 0.5f),
                    new LessonModel(6, "The Interpreter and Its Environment", TimeSpan.FromMinutes(90), "Primary2", 0.6f ),
                },
                Summary =
                    "Python is a general-purpose interpreted, interactive, object-oriented, and high-level" +
                    " programming language. It was created by Guido van Rossum during 1985- 1990. Like Perl," +
                    " Python source code is also available under the GNU General Public License (GPL). " +
                    "This tutorial gives enough understanding on Python programming language."
            },
            new CourseItemViewModel(_navigation)
            {
                CourseName ="Learn Russian",
                CompletedLessons = 21,
                TotalLessons = 112,
                CourseImageSource = "russian_flag",
                PrimaryColor = "Primary3",
                SecondaryColor = "Secondary3",
                Comments = Comments,
                Syllabus = new List<SyllabusModel>
                {
                    new SyllabusModel(1, "Learn to Read", TimeSpan.FromMinutes(356), "Primary3", 1f),
                    new SyllabusModel(2, "The Wrold Around", TimeSpan.FromMinutes(268), "Primary3", 0.4f),
                    new SyllabusModel(3, "Let's Get Acquainted!" ,TimeSpan.FromMinutes(145), "Primary3", 0.5f),
                    new SyllabusModel(4, "About yourself, your family and friends", TimeSpan.FromMinutes(20), "Primary3", 0.6f),
                    new SyllabusModel(5, "My day", TimeSpan.FromMinutes(20), "Primary3", 0.7f),
                },
                Lessons = new List<LessonModel>
                {
                    new LessonModel(1, "Russian Alphabet", TimeSpan.FromMinutes(45), "Primary3", 1f ),
                    new LessonModel(2, "Russian Handwriting", TimeSpan.FromMinutes(45), "Primary3", 0.3f),
                    new LessonModel(3, "Numbers", TimeSpan.FromMinutes(45), "Primary3", 0.5f ),
                    new LessonModel(4, "Basic Phrases", TimeSpan.FromMinutes(45), "Primary3", 0.3f ),
                    new LessonModel(5, "In a Bar/Cafe", TimeSpan.FromMinutes(45), "Primary3", 0.1f ),
                    new LessonModel(6, "Verbs / Pronouns", TimeSpan.FromMinutes(45), "Primary3" , 0.7f),
                },
                Summary =
                    "For those who are new to Russian language. A grammar-based course that focuses on" +
                    " pronunciation, listening and writing. This course on fundamentals prepares students" +
                    " to learn the more complex lessons in the more advanced courses. Completion of this" +
                    " level will enable the student to master common phrases and read basic Russian."
            }
        };
        public static ObservableCollection<CourseItemViewModel> GetCourses() => _courses;


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
