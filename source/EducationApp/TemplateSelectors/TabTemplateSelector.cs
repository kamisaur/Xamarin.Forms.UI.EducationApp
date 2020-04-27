using System;
using EducationApp.ViewModels;
using Xamarin.Forms;

namespace EducationApp.TemplateSelectors
{
    public class TabTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OverviewTabDataTemplate { get; set; }
        public DataTemplate SyllabusTabDataTemplate { get; set; }
        public DataTemplate LessonsTabDataTemplate { get; set; }
        public DataTemplate CommentsTabDataTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is SyllabusTabViewModel)
            {
                return SyllabusTabDataTemplate;
            }
            else if (item is OverviewTabViewModel)
            {
                return OverviewTabDataTemplate;
            }
            else if (item is LessonsTabViewModel)
            {
                return LessonsTabDataTemplate;
            }
            else if (item is CommentsTabViewModel)
            {
                return CommentsTabDataTemplate;
            }

            return null;
        }
    }
}
