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
        public int GetInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;
                Console.WriteLine("Введите корректное число!");
            }
        }
    }
}
