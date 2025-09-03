using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Zavod
{
    internal class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FactoryId { get; set; }



        // Конструктор по умолчанию
        public Unit()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            FactoryId = 0;
        }


        public Unit(int id, string name, string description, int factoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            FactoryId = factoryId;
        }
    }
}
