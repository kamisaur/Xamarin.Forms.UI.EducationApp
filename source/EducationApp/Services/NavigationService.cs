using System;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.Views;
using Xamarin.Forms;

namespace EducationApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToOverviewPageAsync(string courseName)
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PushAsync(new CourseOverviewView(courseName));
        }

        public async Task NavigateBackAsync()
        {
            var currentPage = GetCurrentPage();

            await currentPage.Navigation.PopAsync();
        }

        private Page GetCurrentPage()
        {
            var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

            return currentPage;
        }
    }
}
