using System;
namespace EducationApp.Models
{
    public class LessonModel
    {
        public int LessonNumber { get; set; }

        public string LessonTitle { get; set; }

        public TimeSpan LessonDuration { get; set; }

        public string Color { get; set; }

        public LessonModel()
        {

        }

        public LessonModel(
            int lessonNumber
            , string lessonTitle
            , TimeSpan lessonduration
            , string color)
        {
            LessonNumber = lessonNumber;
            LessonTitle = lessonTitle;
            LessonDuration = lessonduration;
            Color = color;
        }
    }
}
