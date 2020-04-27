using System;
namespace EducationApp.Models
{
    public class SyllabusModel
    {

        public int SyllabusNumber { get; set; }

        public string SyllabusTitle { get; set; }

        public TimeSpan SyllabusDuration { get; set; }

        public string PrimaryColor { get; set; }



        public SyllabusModel()
        {
        }


        public SyllabusModel(int syllabusNumber, string syllabusTitle, TimeSpan syllabusDuration, string primaryColor)
        {
            SyllabusNumber = syllabusNumber;
            SyllabusTitle = syllabusTitle;
            SyllabusDuration = syllabusDuration;
            PrimaryColor = primaryColor;
        }
    }
}
