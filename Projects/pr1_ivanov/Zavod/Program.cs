using System;
using System.Linq;
using System.Threading.Tasks;

namespace Zavod //GOIDA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factories = GetFactories();
            var units = GetUnits();
            var tanks = GetTanks();

            Console.WriteLine("Список резервуаров с их установками и заводами:");
            foreach (var tank in tanks)
            {
                var unit = units.FirstOrDefault(u => u.Id == tank.UnitId);
                var factory = factories.FirstOrDefault(f => f.Id == unit?.FactoryId);
                Console.WriteLine($"{tank.Name} ({tank.Description}): {unit?.Name} -> {factory?.Name}");
            }

            int totalVolume = GetTotalVolume(null);
            Console.WriteLine($"Общий объем резервуаров: {totalVolume}");

            Console.Write("Введите имя резервуара для поиска: ");
            string searchName = Console.ReadLine();
            var foundUnit = FindUnit(units, tanks, searchName);
            var foundFactory = foundUnit != null ? FindFactory(factories, foundUnit) : null;

            if (foundUnit != null && foundFactory != null)
            {
                Console.WriteLine($"{searchName} принадлежит установке {foundUnit.Name} и заводу {foundFactory.Name}");
            }
            else
            {
                Console.WriteLine("Резервуар не найден.");
            }
        }
        /*
        public static Factory[] GetFactories() => new Factory[] :)
        {
        new Factory(1, "НПЗ№1", "Первый нефтеперерабатывающий завод"),
        new Factory(2, "НПЗ№2", "Второй нефтеперерабатывающий завод")
        };
        */

        public static Factory[] GetFactories()
        {
            return new Factory[]
            {
        new Factory(1, "НПЗ№1", "Первый нефтеперерабатывающий завод"),
        new Factory(2, "НПЗ№2", "Второй нефтеперерабатывающий завод")
            };
        }

        public static Unit[] GetUnits()
        {
            return new Unit[]
            {
        new Unit(1, "ГФУ-2", "Газофракционирующая установка", 1),
        new Unit(2, "АВТ-6", "Атмосферно-вакуумная трубчатка", 1),
        new Unit(3, "АВТ-10", "Атмосферно-вакуумная трубчатка", 2)
            };
        }


        public static Tank[] GetTanks()
        {
            return new Tank[]
            {
        new Tank(1, "Резервуар 1", "Наземный - вертикальный", 1500, 2000, 1),
        new Tank(2, "Резервуар 2", "Наземный - горизонтальный", 2500, 3000, 1),
        new Tank(3, "Дополнительный резервуар 24", "Наземный - горизонтальный", 3000, 3000, 2),
        new Tank(4, "Резервуар 35", "Наземный - вертикальный", 3000, 3000, 2),
        new Tank(5, "Резервуар 47", "Подземный - двустенный", 4000, 5000, 2),
        new Tank(6, "Резервуар 256", "Подводный", 500, 500, 3)
            };
        }

        /*
        public static Unit FindUnit(Unit[] units, Tank[] tanks, string tankName)
        {
            var tank = tanks.FirstOrDefault(t => t.Name == tankName);
            return tank != null ? units.FirstOrDefault(u => u.Id == tank.UnitId) : null;
        }
        */

        public static Unit FindUnit(Unit[] units, Tank[] tanks, string tankName)
        {
            var tank = FindFirstOrDefault(tanks, t => t.Name == tankName);

            if (tank != null)
            {
                return FindFirstOrDefault(units, u => u.Id == tank.UnitId);
            }

            return null;
        }

        public static Factory FindFactory(Factory[] factories, Unit unit)
        {
            return FindFirstOrDefault(factories, f => f.Id == unit.FactoryId);
        }

        public static T FindFirstOrDefault<T>(T[] array, Func<T, bool> predicate)
        // Func<T, bool>: это делегат, который принимает один параметр типа T и возвращает bool
        // predicate: это имя переменной, которая будет ссылаться на функцию (или метод)
        // Возвращает default(T) — null для ссылочных типов, 0 для int и т.д.
        // <T> — это обобщённый параметр типа. Это означает, что метод работает с коллекциями элементов любого типа,
        // будь то int, string, пользовательские классы, или другие типы. 


        {
            foreach (var item in array)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }


        public static int GetTotalVolume(Tank[] tanks)
        {
            return tanks.Sum(t => t.Volume);
        }
    }
}
