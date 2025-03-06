using System;

// ДЗ:
// 1. нормально прокоментировать
// 2. в стринг валидатор сделать проверку на числа в имени (чтобы были только буквы)
// 3. сделать провекру на параметры в конструкторе и доделать конструктор
namespace pr1_ivanov
{

    class Program
    {
        static int Sum()        
        {
            int sum_numbers = 0;

            for(int i = 1; i <= 100; i++)
            {
                int tmp = Math.Abs(i);
                while (tmp > 0)
                {
                    if (tmp % 2 == 0)
                    {
                        sum_numbers += tmp % 10;
                    }
                    tmp /= 10;
                }
            }
            return sum_numbers;
        }

        static void Main(string[] args)
        {
            //Human.
            //Console.WriteLine(Sum());
        }
    }
}
