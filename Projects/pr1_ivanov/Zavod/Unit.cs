using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod
{
    internal class Unit
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public int FactoryId { get; }



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
