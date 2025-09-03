using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    // Реализация взаимодействия с консолью
    public class ConsoleUserInteraction : IUserInteraction
    {
        // Вывод сообщения
        public void ShowMessage(string message) => Console.WriteLine(message);

        // Ввод сообщения
        public int GetInput(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result)) 
                    if ((result >= min) && (result <= max))
                    {
                        return result;
                    }
                else
                    {
                        Console.WriteLine($"Ошибка! Число должно быть в диапозоне от {min} до {max}");
                    }
                        
                Console.WriteLine("Введите корректное число!");
            }
        }
    }
}
