using CrazyPoleMobile.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services.Filters
{
    public class TrainerFilter : IFilterElement<TrainingData>
    {
        public string Trainer { get; set; }

        public TrainerFilter(string direction)
        {
            Trainer = direction;
        }

        public TrainerFilter()
        {
            Trainer = string.Empty;
        }

        public bool Match(TrainingData element)
        {
            var trainerFullName = $"{element.Trainer.LastName} {element.Trainer.FirstName} {element.Trainer.MiddleName}";
            return trainerFullName.ToLower().Contains(Trainer.ToLower());
        }
    }
}
