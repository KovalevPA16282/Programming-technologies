using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod
{
    internal class Factory
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }

        public Factory(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}


/*
 
 Factory — представляет завод, у которого есть уникальный Id, название и описание.

Unit — представляет установку на заводе. Каждая установка также имеет уникальный Id, название, описание и ссылается на завод через свойство FactoryId. Это означает, что каждая установка принадлежит конкретному заводу.

Tank — представляет резервуар, который связан с установкой. Каждый резервуар имеет свой уникальный Id, название, описание, объем и максимальный объем. Резервуар ссылается на установку через UnitId.
 
 */