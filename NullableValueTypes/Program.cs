using System;

namespace NullableValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 10;
            int? number2 = null;

            //number2 = number1;
            number1 = number2.Value;

            if (number2 != null)
            {
                number1 = number2.Value;
            }

            if (number2.HasValue)
            {
                number1 = number2.Value;
            }

            Console.WriteLine("Hello World!");
        }
    }
}
