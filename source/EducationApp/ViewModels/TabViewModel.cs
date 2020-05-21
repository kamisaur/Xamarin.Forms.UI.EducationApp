using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EducationApp.Models;
using Xamarin.Forms;

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


        public ICommand SelectTabCommand { get; private set; }
        private void SelectTab()
        {
            MessagingCenter.Send(new TabMessage(this), "tab_clicked");
        }

        public TabViewModel()
        {
            SelectTabCommand = new Command(() => SelectTab());
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
