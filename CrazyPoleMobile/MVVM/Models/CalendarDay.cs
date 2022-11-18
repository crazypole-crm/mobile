using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.Models
{
    public class CalendarDay : IEquatable<CalendarDay>
    {
        private DateTime _date;
        
        public CalendarDay(DateTime date) => _date = date;

        public string DayOfWeek
        {
            get
            {
                switch(_date.DayOfWeek)
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
        public int Day => _date.Day;
        public int Month => _date.Month;

        public int Year => _date.Year;

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
            return _date == other._date;
        }
    }
}
