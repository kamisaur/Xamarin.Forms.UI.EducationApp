using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EducationApp.Helpers;
using EducationApp.Models;
using EducationApp.Services;
using Xamarin.Forms;

namespace EducationApp.ViewModels
{
    public class HomeViewModel : IUpdatable, INotifyPropertyChanged
    {
        public UserModel User { get; set; }

        private ObservableCollection<CourseItemViewModel> _courses;
        public ObservableCollection<CourseItemViewModel> Courses
        {
            get => _courses;
            set { _courses = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<LessonModel> _todaysLessons;
        public ObservableCollection<LessonModel> TodaysLessons
        {
            get => _todaysLessons;
            set { _todaysLessons = value; NotifyPropertyChanged(); }
        }

        public HomeViewModel()
        {
            User = SharedState.GetUser();
            UpdateLists();
        }

        public void UpdateLists()
        {
            Courses = new ObservableCollection<CourseItemViewModel>(SharedState.GetCourses());
            TodaysLessons = new ObservableCollection<LessonModel>(SharedState.GetTodaysLessons());
        }

        public void Update(bool hasAppResumed = false)
        {
            UpdateLists();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

