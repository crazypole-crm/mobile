using CrazyPoleMobile.Services.Filters;

namespace CrazyPoleMobile.Services
{
    public interface IFilterService<T>
    {
        public IEnumerable<T> Filtrate(IEnumerable<T> collection);
        public void AddFilter(IFilterElement<T> filterElement);
        public void AddFilters(IEnumerable<IFilterElement<T>> filterCollection);
        public void RemoveFilter(IFilterElement<T> filterElement);
        public void ClearFilters();

    }
}
