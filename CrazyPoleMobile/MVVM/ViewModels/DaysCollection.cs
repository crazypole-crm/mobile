using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public class DaysCollection : ObservableCollection<TrainingData>, INotifyPropertyChanged
    {
        private CalendarDay _date;

        public CalendarDay Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(new(nameof(Date)));
                }
            }
        }

        public DaysCollection(CalendarDay date, ObservableCollection<TrainingData> trainingDatas)
            : base(trainingDatas)
        {
            _date= date;
        }
    }
}
