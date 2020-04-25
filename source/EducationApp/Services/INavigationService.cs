using System;
using System.Threading.Tasks;

namespace EducationApp.Services
{
    public interface INavigationService
    {
        Task NavigateToOverviewPageAsync();
        Task NavigateBackAsync();
    }
}
