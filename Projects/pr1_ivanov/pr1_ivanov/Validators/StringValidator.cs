using System;

namespace pr1_ivanov.Validators
{
    internal class StringValidator
    {

        static public bool Validate(string Value)
        {
            
            return String.IsNullOrWhiteSpace(Value) ? true : false ;
        }
    }
}
