using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services.Api;
using CrazyPoleMobile.Services.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services
{
    public class CalendarService : ICalendarService
    {
        private CalendarApi _calendarApi = new();
        private HashSet<HallData> _halls = new();
        private HashSet<DirectionData> _directions = new();
        private HashSet<UserData> _trainers = new();
        private HashSet<string> _trainersId = new();
        private HashSet<TrainingData> _trainings = new();

        private void ClearTrainings()
        {
            if(_trainings.Count > 50)
                _trainings.Clear();
        }

        public async Task<List<CalendarDay>> GetTrainingDays(DateTime currentDay, uint daysBefore, uint daysAfter)
        {
            var daySeporator = TimeSpan.FromDays(1);
            var daysList = new List<CalendarDay>();
            int daysBeforeInt = 0 - (int)daysBefore; 
            await Task.Run(() =>
            {
                for (int i = daysBeforeInt; i <= daysAfter; ++i)
                {
                    daysList.Add(new(currentDay + daySeporator * i));
                }

            });

            return daysList;
        }

        public async Task<List<DirectionData>> GetDirections()
        {
            if (_directions.Count > 0)
                return _directions.ToList();

            var apiDirections = await _calendarApi.GetDirections();

            foreach (var apiDirection in apiDirections)
                _directions.Add(new(apiDirection.Id, apiDirection.Name));

            return _directions.ToList();
        }

        public async Task<List<HallData>> GetHalls()
        {
            if(_halls.Count > 0)
                return _halls.ToList();

            var apiHalls = await _calendarApi.GetHalls();
            
            foreach (var apiHall in apiHalls)
                _halls.Add(new(apiHall.Id, apiHall.Name, apiHall.Capacity));

            return _halls.ToList();
        }

        public async Task<List<UserData>> GetTrainers()
        {
            if (_trainers.Count > 0)
                return _trainers.ToList();
            await Task.Delay(100);

            var apiTrainers = await _calendarApi.GetTrainers();

            foreach (var apiTrainer in apiTrainers)
                _trainers.Add(new(apiTrainer.Id,
                                  apiTrainer.Email,
                                  apiTrainer.AvatarUrl,
                                  apiTrainer.Phone,
                                  apiTrainer.FirstName,
                                  apiTrainer.LastName,
                                  apiTrainer.MiddleName,
                                  apiTrainer.Role,
                                  apiTrainer.Birthday,
                                  apiTrainer.LastVisit));
                
            return _trainers.ToList();
        }

        public async Task<List<TrainingData>> GetTrainingForDay(DateTime day)
        {
            var currentDayTrainings = _trainings.Where(
                (training) => { return training.DateStart.Date == day.Date; }).ToList();

            if(currentDayTrainings.Count > 0)
                return currentDayTrainings;

            ClearTrainings();

            var endOfDay = day.Date.Add(TimeSpan.FromDays(1));
            currentDayTrainings = await GetTrainingsForPeriod(day.Date, endOfDay);
            
            foreach(var training in currentDayTrainings)
                _trainings.Add(training);

            return currentDayTrainings;
        }

        public async Task<List<TrainingData>> GetTrainingsForPeriod(DateTime start, DateTime end)
        {
            var apiTrainings = await _calendarApi.GetTrainingsForPeriod(start, end);

            var trainings = new List<TrainingData>();
            
            if(apiTrainings.Count == 0)
                return trainings;

            var halls = await GetHalls();
            var directions = await GetDirections();
            var trainersId = GetTrainersId(apiTrainings);
            var trainers = await GetTrainersByIds(trainersId);

            foreach (var apiTraining in apiTrainings)
            {
                var hall = halls.Where((hall) => { return apiTraining.HallId == hall.Id; }).FirstOrDefault();
                var direction = directions.Where((direction) => { return apiTraining.CourseId == direction.Id; }).FirstOrDefault();
                var trainer = trainers.Where((trainer) => { return apiTraining.TrainerId == trainer.Id; }).FirstOrDefault();
                var startDate = DateTimeOffset.FromUnixTimeSeconds(apiTraining.StartDate).DateTime.ToLocalTime();
                var endDate = DateTimeOffset.FromUnixTimeSeconds(apiTraining.EndDate).DateTime.ToLocalTime();

                trainings.Add(new(apiTraining.BaseTrainingId,
                                  apiTraining.TrainingId,
                                  direction,
                                  trainer,
                                  hall,
                                  startDate,
                                  endDate,
                                  apiTraining.Description,
                                  3,
                                  apiTraining.IsCanceled,
                                  apiTraining.IsMoved,
                                  apiTraining.IsTrainerChanged));
            }

            return trainings;
        }

        private List<string> GetTrainersId(List<ApiTrainingData> apiTrainings)
        {
            var trainersId = new HashSet<string>();

            foreach (var apiTraining in apiTrainings)
                trainersId.Add(apiTraining.TrainerId);

            return trainersId.ToList();
        }

        public async Task<List<UserData>> GetTrainersByIds(List<string> trainersId)
        {
            List<string> newIds;
            if (_trainersId.Count != 0)
            {
                newIds = new();
                foreach (var trainerId in trainersId)
                    if (!_trainersId.Add(trainerId))
                        newIds.Add(trainerId);
            }
            else 
                newIds = trainersId;

            if(newIds.Count == 0)
                return _trainers.ToList();

            var apiTrainers = await _calendarApi.GetUsersDataByIds(newIds);

            foreach (var apiTrainer in apiTrainers)
                _trainers.Add(new(apiTrainer.Id,
                                  apiTrainer.Email,
                                  apiTrainer.AvatarUrl,
                                  apiTrainer.Phone,
                                  apiTrainer.FirstName,
                                  apiTrainer.LastName,
                                  apiTrainer.MiddleName,
                                  apiTrainer.Role,
                                  apiTrainer.Birthday,
                                  apiTrainer.LastVisit));

            return _trainers.ToList();
        }

        public void ResetСache()
        {
            _directions.Clear();
            _halls.Clear();
            _trainers.Clear();
            _trainersId.Clear();
            _trainings.Clear();
        }
    }
}
