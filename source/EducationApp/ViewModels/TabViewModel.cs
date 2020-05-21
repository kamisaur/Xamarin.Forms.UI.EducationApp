using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EducationApp.ViewModels
{
    public abstract class TabViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }


        private bool _isSelectedTab;
        public bool IsSelectedTab
        {
            get => _isSelectedTab;
            set
            {
                _isSelectedTab = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
