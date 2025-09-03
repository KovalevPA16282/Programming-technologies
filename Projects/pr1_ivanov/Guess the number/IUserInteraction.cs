using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    // Интерфейс взаимодействия с пользователем
    public interface IUserInteraction
    {
        void ShowMessage(string message);
        int GetInput(int min, int max);
    }
}
