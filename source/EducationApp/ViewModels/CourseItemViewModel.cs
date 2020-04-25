using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using EducationApp.Services;
using Xamarin.Forms;

namespace EducationApp.ViewModels
{
    public class CourseItemViewModel : INotifyPropertyChanged
    {
        private INavigationService _navigation;


        public string CourseName { get; set; }

        private int _totalLessons;
        public int TotalLessons
        {
            get => _totalLessons;
            set
            {
                _totalLessons = value;
                Progress = GetProgress();
            }
        }

        private int _completedLessons;
        public int CompletedLessons
        {
            get => _completedLessons;
            set
            {
                _completedLessons = value;
                Progress = GetProgress();
            }
        }

        public string CourseImageSource { get; set; }

        public string PrimaryColor { get; set;  }

        public string SecondaryColor { get; set; }

        private double _progress;
        public double Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                NotifyPropertyChanged();
            }
        }

        private double GetProgress()
        {
            if(TotalLessons == 0)
            {
                return 0;
            }

            if(CompletedLessons == 0)
            {
                return 0;
            }

            double val = Convert.ToDouble(CompletedLessons) / Convert.ToDouble(TotalLessons);
            return val;
        }


        public CourseItemViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            ShowCourseOverviewCommand = new Command(async () => await ShowCourseOverviewAsync());
        }


        public ICommand ShowCourseOverviewCommand { get; private set; }
        private async Task ShowCourseOverviewAsync()
        {
            await _navigation.NavigateToOverviewPageAsync();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
