using System;

namespace Guess_the_number
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello, World!");
    //    }
    //}



    // Интерфейс для генерации случайного числа
    // Оно надо чтобы все классы ,которые его наследуют, должны иметь метод Generate
    public interface IRandomNumberGenerator
    {
        int Generate(int min, int max);
    }

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


    // Интерфейс взаимодействия с пользователем
    public interface IUserInteraction
    {
        void ShowMessage(string message);
        int GetInput();
    }

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

    // Перечисление сложностей
    // enum — это тип данных, который задает набор (перечисление) именованных значений
    public enum Difficulty
    {
        Easy = 10,
        Medium = 9,
        Hard = 8
    }

    // Основной класс игры
    public class NumberGuessingGame
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IUserInteraction _userInteraction;
        private readonly int _min;
        private readonly int _max;
        private Difficulty _difficulty;

        // Конструктор
        public NumberGuessingGame(IRandomNumberGenerator randomNumberGenerator, IUserInteraction userInteraction, int min = 1, int max = 100)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _userInteraction = userInteraction;
            _min = min;
            _max = max;
            _difficulty = Difficulty.Easy;
        }

        // Метод для работы игры
        public void Play()
        {
            while (true)
            {
                int secretNumber = _randomNumberGenerator.Generate(_min, _max); // создаем случайное число
                int attempts = (int)_difficulty; // задаем сложность (количество попыток)
                _userInteraction.ShowMessage($"Угадайте число от {_min} до {_max}! У вас {attempts} попыток."); //выводим сообщение

                for (int i = 0; i < attempts; i++) // цикл количества попыток
                {
                    _userInteraction.ShowMessage("Введите число:");
                    int guess = _userInteraction.GetInput();

                    if (guess < secretNumber)
                        _userInteraction.ShowMessage("Загаданное число больше!");
                    else if (guess > secretNumber)
                        _userInteraction.ShowMessage("Загаданное число меньше!");
                    else
                    {
                        _userInteraction.ShowMessage("Поздравляю! Вы угадали число!");
                        IncreaseDifficulty();
                        break;
                    }

                    if (i == attempts - 1)
                    {
                        _userInteraction.ShowMessage($"Вы проиграли! Загаданное число было {secretNumber}.");
                        return;
                    }
                }
            }
        }

        // Метод для повышения сложности
        private void IncreaseDifficulty()
        {
            if (_difficulty == Difficulty.Easy)
            {
                _difficulty = Difficulty.Medium;
                _userInteraction.ShowMessage("Сложность увеличена до Среднего уровня!");
            }
            else if (_difficulty == Difficulty.Medium)
            {
                _difficulty = Difficulty.Hard;
                _userInteraction.ShowMessage("Сложность увеличена до Сложного уровня!");
            }
            else
            {
                //_userInteraction.ShowMessage("Вы прошли игру! Поздравляем!");
                Environment.Exit(0); // это вызов метода, который завершает выполнение текущего процесса программы с заданным кодом завершения
            }
        }
    }


    // Запуск игры
    public class Program
    {
        public static void Main()
        {
            var game = new NumberGuessingGame(new RandomNumberGenerator(), new ConsoleUserInteraction());
            game.Play();
        }
    }

}





/*
SOLID — это набор из пяти принципов объектно-ориентированного программирования, направленных на создание гибкого, поддерживаемого и масштабируемого кода.

1) S (Single Responsibility Principle, SRP) – Принцип единственной ответственности

    Каждый класс должен выполнять только одну задачу.

    RandomNumberGenerator, ConsoleUserInteraction и NumberGuessingGame отвечают за отдельные задачи.

2) O (Open/Closed Principle, OCP) – Принцип открытости/закрытости

    Код должен быть открыт для расширения, но закрыт для изменения.

3) L (Liskov Substitution Principle, LSP) – Принцип подстановки Барбары Лисков

    Объекты подклассов должны заменять объекты суперкласса без изменения поведения программы.

4) I (Interface Segregation Principle, ISP) – Принцип разделения интерфейсов

    Лучше несколько узкоспециализированных интерфейсов, чем один большой.

5) D (Dependency Inversion Principle, DIP) – Принцип инверсии зависимостей

    Зависимости должны быть от абстракций, а не от конкретных классов.

*/