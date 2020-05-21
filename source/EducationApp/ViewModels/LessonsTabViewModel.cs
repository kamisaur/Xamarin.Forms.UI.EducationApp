using System;
using System.Collections.ObjectModel;
using EducationApp.Models;

namespace EducationApp.ViewModels
{
    public class LessonsTabViewModel : TabViewModel
    {
        public ObservableCollection<LessonModel> Lessons { get; set; }

        public LessonsTabViewModel(ObservableCollection<LessonModel> lessons)
        {
            Title = "Lessons";
            Lessons = lessons;
        }
    }
}
