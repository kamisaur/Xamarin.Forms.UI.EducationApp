using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EducationApp.Models;
using Xamarin.Forms;

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

        
        private TabViewModel _currentTabItem;
        public TabViewModel CurrentTabItem
        {
            get => _currentTabItem;
            set
            {
                _currentTabItem = value;
                NotifyPropertyChanged();
                UpdateSelectedTabsIndicators();
            }
        }


        public CourseOverviewViewModel(string courseName)
        {
            Courses = SharedState.GetCourses();
            CurentCourseItem = Courses.Where(x => x.CourseName == courseName).First();

            MessagingCenter.Subscribe<TabMessage>(this, "tab_clicked", (tab) =>
            {
                CurrentTabItem = tab.Tab;
            });
        }


        private void UpdateTabs()
        {
            Tabs = new ObservableCollection<TabViewModel>
            {
                new OverviewTabViewModel(CurentCourseItem.Summary, CurentCourseItem.PrimaryColor),
                new SyllabusTabViewModel(new ObservableCollection<SyllabusModel>(CurentCourseItem.Syllabus)),
                new LessonsTabViewModel (new ObservableCollection<LessonModel>(CurentCourseItem.Lessons)),
                new CommentsTabViewModel(new ObservableCollection<CommentsModel>(CurentCourseItem.Comments))
            };

            // when "Course" is changed, selected tab still hold value for previous course
            // need to manually update the current tab
            if (CurrentTabItem != null)
                CurrentTabItem = Tabs?.Where(x => x.Title == CurrentTabItem.Title)?.First();

            UpdateSelectedTabsIndicators();
        }


        private void UpdateSelectedTabsIndicators()
        {
            foreach (var t in Tabs)
            {
                if (t == CurrentTabItem)
                    t.IsSelectedTab = true;
                else
                    t.IsSelectedTab = false;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
