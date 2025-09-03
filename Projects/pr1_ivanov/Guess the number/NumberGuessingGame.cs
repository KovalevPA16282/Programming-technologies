using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
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
                    int guess = _userInteraction.GetInput(_min, _max);

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
}
