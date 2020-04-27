using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EducationApp.Models;

namespace EducationApp.ViewModels
{
    public class CourseOverviewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CourseItemViewModel> Courses { get; set; }


        private ObservableCollection<TabViewModel> _tabs;
        public ObservableCollection<TabViewModel> Tabs
        {
            get => _tabs;
            set { _tabs = value; NotifyPropertyChanged(); }
        }


        private CourseItemViewModel _curentCourseItem;
        public CourseItemViewModel CurentCourseItem
        {
            get => _curentCourseItem;
            set
            {
                _curentCourseItem = value;
                NotifyPropertyChanged();
                UpdateTabs();
            }
        }



        public CourseOverviewViewModel(string courseName)
        {
            Courses = SharedState.GetCourses();
            CurentCourseItem = Courses.Where(x => x.CourseName == courseName).First();
        }



        private void UpdateTabs()
        {
            var overview = new OverviewTabViewModel(CurentCourseItem.Summary, CurentCourseItem.PrimaryColor);

            var syllabus = new SyllabusTabViewModel
            {
                SyllabusCollection = new ObservableCollection<SyllabusModel>(CurentCourseItem.Syllabus),
            };

            var lessons = new LessonsTabViewModel
            {
                Lessons = new ObservableCollection<LessonModel>(CurentCourseItem.Lessons),
            };

            var comments = new CommentsTabViewModel
            {
                Comments = new ObservableCollection<CommentsModel>(CurentCourseItem.Comments),
            };


            Tabs = new ObservableCollection<TabViewModel>
            {
                overview,
                syllabus,
                lessons,
                comments
            };
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
