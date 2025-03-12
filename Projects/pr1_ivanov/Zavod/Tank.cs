using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod
{
    internal class Tank
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public int Volume { get; }
        public int MaxVolume { get; }
        public int UnitId { get; }


        // Конструктор по умолчанию
        public Tank()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Volume = 0;
            MaxVolume = 0;
            UnitId = 0;
        }


        public Tank(int id, string name, string description, int volume, int maxVolume, int unitId)
        {
            Id = id;
            Name = name;
            Description = description;
            Volume = volume;
            MaxVolume = maxVolume;
            UnitId = unitId;
        }
    }
}
