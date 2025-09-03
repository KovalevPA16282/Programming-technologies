using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Zavod
{
    public class Tank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Volume { get; set; }
        public int MaxVolume { get; set; }
        public int UnitId { get; set; }


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
