using System;
using EducationApp.ViewModels;

namespace EducationApp.Models
{
    public class TabMessage
    {
        public TabViewModel Tab { get; set; }

        public TabMessage(TabViewModel tab)
        {
            Tab = tab;
        }

        public TabMessage()
        {
        }
    }
}
