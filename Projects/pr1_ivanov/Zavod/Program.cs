using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;


namespace Zavod //GOooool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var factories = GetFactories();
            var units = GetUnits();
            var tanks = GetTanks();*/

            string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
            string dataDir = Path.Combine(projectDir, "Data");

            var factories = JsonLoader.LoadFromJson<Factory>(Path.Combine(dataDir, "Factory.json"));
            var units = JsonLoader.LoadFromJson<Unit>(Path.Combine(dataDir, "Unit.json"));
            var tanks = JsonLoader.LoadFromJson<Tank>(Path.Combine(dataDir, "Tanks.json"));



            //---------------------------------------------------------------------------------------------------------------
            // ----- Синтаксис запросов -----
            /*
            var query = from t in tanks
                        join u in units on t.UnitId equals u.Id
                        join f in factories on u.FactoryId equals f.Id
                        select new { Tank = t, Unit = u, Factory = f };

            foreach (var item in query)
                Console.WriteLine($"{item.Tank.Name} ({item.Tank.Description}): {item.Unit.Name} -> {item.Factory.Name}");
            */

            // ----- Синтаксис методов -----
            var query2 = tanks
                .Join(units, t => t.UnitId, u => u.Id, (t, u) => new { t, u })
                .Join(factories, tu => tu.u.FactoryId, f => f.Id, (tu, f) => new { tu.t, tu.u, f });

            foreach (var item in query2)
                Console.WriteLine($"{item.t.Name} ({item.t.Description}): {item.u.Name} -> {item.f.Name}");
            //------------------------------------------------------------------------------------------------------------


            int totalVolume = GetTotalVolume(tanks);
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

            JsonLoader.SaveToJson("factories_out.json", factories);
            JsonLoader.SaveToJson("units_out.json", units);
            JsonLoader.SaveToJson("tanks_out.json", tanks);
        }
        /*
        public static Factory[] GetFactories() => new Factory[] :)
        {
        new Factory(1, "НПЗ№1", "Первый нефтеперерабатывающий завод"),
        new Factory(2, "НПЗ№2", "Второй нефтеперерабатывающий завод")
        };*/


        public static Factory[] GetFactories()
        {
            try
            {
                return new Factory[]
            {
                new Factory(1, "НПЗ№1", "Первый нефтеперерабатывающий завод"),
                new Factory(2, "НПЗ№2", "Второй нефтеперерабатывающий завод")
            };
            }

            catch (Exception ex1)
            {
                Console.WriteLine($"{ex1.Message}");
                return new Factory[0];
            }

        }

        public static Unit[] GetUnits()
        {
            try
            {
                return new Unit[]
                {
                new Unit(1, "ГФУ-2", "Газофракционирующая установка", 1),
                new Unit(2, "АВТ-6", "Атмосферно-вакуумная трубчатка", 1),
                new Unit(3, "АВТ-10", "Атмосферно-вакуумная трубчатка", 2)
                };
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return new Unit[0];
            }

        }


        public static Tank[] GetTanks()
        {
            try
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

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return new Tank[0];
            }
        }

        /*
        public static Unit FindUnit(Unit[] units, Tank[] tanks, string tankName)
        {
            var tank = tanks.FirstOrDefault(t => t.Name == tankName);
            return tank != null ? units.FirstOrDefault(u => u.Id == tank.UnitId) : null;
        }
        */

        /*
        public static Unit FindUnit(Unit[] units, Tank[] tanks, string tankName)
        {
            try
            {
                var tank = FindFirstOrDefault(tanks, t => t.Name == tankName);

                if (tank != null)
                {
                    return FindFirstOrDefault(units, u => u.Id == tank.UnitId);
                }

                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }
        */

        public static Unit FindUnit(Unit[] units, Tank[] tanks, string tankName)
        {
            try
            {
                // ----- Синтаксис запросов -----
                /*
                var query = from t in tanks
                            where t.Name == tankName
                            join u in units on t.UnitId equals u.Id
                            select u;

                return query.FirstOrDefault();
                */

                // ----- Синтаксис методов -----
                return tanks
                    .Where(t => t.Name == tankName)
                    .Join(units, t => t.UnitId, u => u.Id, (t, u) => u)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }

        /*
        public static Factory FindFactory(Factory[] factories, Unit unit)
        {
            try
            {
                if (factories is null)
                    throw new ArgumentNullException(nameof(factories));

                return FindFirstOrDefault(factories, f => f.Id == unit.FactoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }
        */

        public static Factory FindFactory(Factory[] factories, Unit unit)
        {
            try
            {
                if (factories is null)
                    throw new ArgumentNullException(nameof(factories));

                // ----- Синтаксис запросов -----
                /*
                var query = from f in factories
                            where f.Id == unit.FactoryId
                            select f;

                return query.FirstOrDefault();
                */

                // ----- Синтаксис методов -----
                return factories.FirstOrDefault(f => f.Id == unit.FactoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }



        public static T FindFirstOrDefault<T>(T[] array, Func<T, bool> predicate)
        // Func<T, bool>: это делегат, который принимает один параметр типа T и возвращает bool
        // predicate: это имя переменной, которая будет ссылаться на функцию (или метод)
        // Возвращает default(T) — null для ссылочных типов, 0 для int и т.д.
        // <T> — это обобщённый параметр типа. Это означает, что метод работает с коллекциями элементов любого типа,
        // будь то int, string, пользовательские классы, или другие типы. 


        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return default(T);
            }

        }


        public static int GetTotalVolume(Tank[] tanks)
        {
            try
            {
                return tanks.Sum(t => t.Volume);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 0;
            }

        }
    }
}


