using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace EducationApp.Controls
{
    public partial class RatingControl : Grid, INotifyPropertyChanged
    {
        private ObservableCollection<bool> _ratings;
        public ObservableCollection<bool> Ratings
        {
            get => _ratings;
            set { _ratings = value; OnPropertyChanged(); }
        }


        public RatingControl()
        {
            InitializeComponent();
            BindingContext = this;

        }


        public int MaxRating { get; set; }

        public static readonly BindableProperty MaxRatingProperty = BindableProperty.Create(
            "MaxRating", typeof(int), typeof(RatingControl), 0, propertyChanged: MaxRatingChanged);

        private static void MaxRatingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //var control = bindable as RatingControl;
            //var max = int.Parse(string.Format("{0}", newValue));



            //if (control.Ratings == null)
            //{
            //    control.Ratings = new ObservableCollection<bool>();
            //}

            //for (var i = 0; i < max; i++)
            //{
            //    control.Ratings.Add(false);
            //}
        }



        public int Rating { get; set; }

        public static readonly BindableProperty RatingProperty = BindableProperty.Create(
            "Rating", typeof(int), typeof(RatingControl), 0, propertyChanged: RatingChanged);

        private static void RatingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //var control = bindable as RatingControl;

        }
    }
}
