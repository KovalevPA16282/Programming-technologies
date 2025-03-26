using System;

namespace Guess_the_number
{

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