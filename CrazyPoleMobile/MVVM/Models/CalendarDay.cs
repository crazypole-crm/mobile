using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.Models
{
    public class CalendarDay : IEquatable<CalendarDay>
    {
        public DateTime Date { get; }
        
        public CalendarDay(DateTime date) => Date = date;

        public string DayOfWeek
        {
            get
            {
                switch(Date.DayOfWeek)
                {
                    case System.DayOfWeek.Sunday:
                        return "Вс";
                    case System.DayOfWeek.Monday:
                        return "Пн";
                    case System.DayOfWeek.Tuesday:
                        return "Вт";
                    case System.DayOfWeek.Wednesday:
                        return "Ср";
                    case System.DayOfWeek.Thursday:
                        return "Чт";
                    case System.DayOfWeek.Friday:
                        return "Пт";
                    case System.DayOfWeek.Saturday:
                        return "Сб";
                    default: return "Пн";
                }

            }
        }
        public int Day => Date.Day;
        public int Month => Date.Month;

        public int Year => Date.Year;

        public bool IsCurrentDay
        {
            get 
            {
                var dateNow = DateTime.Now;
                return Day == dateNow.Day && Month == dateNow.Month && Year == dateNow.Year;
            }
        }

        public bool Equals(CalendarDay other)
        {
            if (other == null)
                return false;

            return Date == other.Date;
        }
    }
}
