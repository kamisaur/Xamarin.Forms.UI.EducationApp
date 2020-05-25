using System;
namespace EducationApp.Services
{
    public interface IUpdatable
    {
        void Update(bool hasAppResumed = false);
    }
}
