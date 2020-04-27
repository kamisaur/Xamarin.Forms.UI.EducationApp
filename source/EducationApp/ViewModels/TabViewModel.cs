using System;
using System.Collections.ObjectModel;

namespace EducationApp.ViewModels
{
    public abstract class TabViewModel
    {
        public string Title { get; set; }

        public bool IsSelectedTab { get; set; }


    }
}
