using System;
using System.Threading.Tasks;

namespace EducationApp.Services
{
    public interface INavigationService
    {
        Task NavigateToOverviewPageAsync(string courseName);
        Task NavigateBackAsync();
    }
}
