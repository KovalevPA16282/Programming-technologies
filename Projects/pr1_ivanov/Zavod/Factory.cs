using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;


namespace Zavod
{
    internal class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Factory()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
        }

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