using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    // Интерфейс для генерации случайного числа
    // Оно надо чтобы все классы ,которые его наследуют, должны иметь метод Generate
    public interface IRandomNumberGenerator
    {
        int Generate(int min, int max);
    }
}
