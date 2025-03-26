using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    // Реализация генератора случайных чисел
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random = new Random();
        public int Generate(int min, int max)
        {
            return _random.Next(min, max);
        }
        //public int Generate(int min, int max) => _random.Next(min, max);
    }

    /*
    Методы генерации случайных чисел

    1)  
    Random random = new Random();
    int num = random.Next(1, 100); //от 1 до 99

    2)
    using System.Security.Cryptography;

    byte[] bytes = new byte[4];
    RandomNumberGenerator.Fill(bytes);
    int randomNum = BitConverter.ToInt32(bytes, 0) & int.MaxValue;
    Console.WriteLine(randomNum);

    3)
    int seed = Environment.TickCount;
    Random random = new Random(seed);
    Console.WriteLine(random.Next(1, 100));

    */
}
