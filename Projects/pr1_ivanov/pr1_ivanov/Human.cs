using pr1_ivanov.Validators;
using System;
namespace pr1_ivanov
{
    class Human
    {
        public Human(int Heght, int Weight, DateTime Birthday, string FirstName, string LastName) 
        {
            //дз
        }
        // если нужно изменить объеты в классе нужна static
        // { get; private set; } - автоматическое свойство
        // get - можно получить | private set - изменить
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public DateTime Birthday { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        // this. - ссылка на объект в классе
        public bool ChangeHeight(int Height)
        {
            bool flag = IntValidator.Validate(Height);
            if (flag)
            {
                this.Height = Height;
            }
            return flag;

        }

        public bool ChangeWeight(int weight)
        {
            bool flag = IntValidator.Validate(weight);
            if (flag)
            {
                this.Weight = weight;
            }
            return flag;
        }

        public bool ChangeFirstName(string FirstName)
        {
            bool flag = StringValidator.Validate(FirstName);
            if (flag)
            {
                this.FirstName = FirstName;
            }
            return flag;
        }
        public bool ChangeLastName(string LastName)
        {
            bool flag = StringValidator.Validate(LastName);
            if (flag)
            {
                this.LastName = LastName;
            }
            return flag;
        }

    }
}
