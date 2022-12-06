using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.Models
{
    public readonly struct HallData
    {

        public string Id { get; }
        public string Name { get; }
        public int Capacity { get; }
        public HallData(string id, string name, int capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }
    }
}
