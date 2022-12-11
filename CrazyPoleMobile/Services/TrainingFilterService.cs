using CrazyPoleMobile.MVVM.Models;
using CrazyPoleMobile.Services.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services
{
    public class TrainingFilterService : IFilterService<TrainingData>
    {
        private List<IFilterElement<TrainingData>> _filters = new();
        public List<IFilterElement<TrainingData>> Filters => _filters;

        public IEnumerable<TrainingData> Filtrate(IEnumerable<TrainingData> collection)
        {
            return collection.Where(MatchFilters);
        }

        private bool MatchFilters(TrainingData training)
        {
            foreach(var filter in _filters)
                if(!filter.Match(training))
                    return false;
            
            return true;
        }

        public void AddFilter(IFilterElement<TrainingData> filterElement)
        {
            _filters.Add(filterElement);
        }

        public void AddFilters(IEnumerable<IFilterElement<TrainingData>> filterCollection)
        {
            _filters.AddRange(filterCollection);
        }

        public void RemoveFilter(IFilterElement<TrainingData> filterElement)
        {
            _filters.Remove(filterElement);
        }

        public void ClearFilters()
        {
            _filters.Clear();
        }

         
    }
}
