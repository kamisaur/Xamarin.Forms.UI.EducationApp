using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EducationApp.Models;

namespace EducationApp.ViewModels
{
    public class SyllabusTabViewModel : TabViewModel
    {
        public ObservableCollection<SyllabusModel> SyllabusCollection { get; set; }

        public SyllabusTabViewModel(ObservableCollection<SyllabusModel> syllabusCollection)
        {
            Title = "Syllabus";
            SyllabusCollection = syllabusCollection;
        }

    }
}
