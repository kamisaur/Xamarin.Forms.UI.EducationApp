using System;
using System.Collections.ObjectModel;
using EducationApp.Models;

namespace EducationApp.ViewModels
{
    public class CommentsTabViewModel : TabViewModel
    {
        public ObservableCollection<CommentsModel> Comments { get; set; }

        public CommentsTabViewModel()
        {
            Title = "Comments";
        }
    }
}
