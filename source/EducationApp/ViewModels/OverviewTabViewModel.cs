using System;
namespace EducationApp.ViewModels
{
    public class OverviewTabViewModel : TabViewModel
    {
        public string OverviewSummary { get; set; }

        public string PrimaryColor { get; set; }


        public OverviewTabViewModel(string summary, string color)
        {
            Title = "Overview";
            OverviewSummary = summary;
            PrimaryColor = color;
        }
    }
}
