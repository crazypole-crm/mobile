
namespace CrazyPoleMobile.MVVM.Models
{
    public readonly struct DirectionData
    {

        public string Id { get; }
        public string Name { get; }
        public DirectionData(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
