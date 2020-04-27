using System;
namespace EducationApp.Models
{
    public class CommentsModel
    {
        public string CommentorName { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public CommentsModel()
        {

        }

        public CommentsModel(string commentorName, string commentText, DateTime commentDate)
        {
            CommentorName = commentorName;
            CommentText = commentText;
            CommentDate = commentDate;
        }
    }
}
