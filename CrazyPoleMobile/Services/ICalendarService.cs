using CrazyPoleMobile.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services
{
    public interface ICalendarService
    {
        public Task<List<CalendarDay>> GetTrainingDays(DateTime currentDay, uint daysBefore, uint daysAfter);
        public Task<List<TrainingData>> GetTrainingForDay(DateTime day);
        public Task<List<TrainingData>> GetTrainingsForPeriod(DateTime start, DateTime end);
        public Task<List<HallData>> GetHalls();
        public Task<List<DirectionData>> GetDirections();
        public Task<List<UserData>> GetTrainersByIds(List<string> TrainerId);
        public Task<List<UserData>> GetTrainers();
        public void ResetСache();
    }
}
