using System;
using System.Collections.Generic;

namespace FirstLab
{
    class Input
    {
        public static int GetNumber()
        {
            int num = 0;
            while (true)
            {

                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    break;
                }

                Console.WriteLine("Некорректное число");
            }

            return num;
        }

        public static int GetNumber(int a, int b)
        {
            int num = GetNumber();
            while (num < a || num > b)
            {
                Console.WriteLine($"Пожалуйста, введите число между {a} и {b}");
                num = GetNumber();
            }

            return num;
        }


        public List<Int32> GetArray(String str)
        {
            String[] subs = str.Split(' ');
            List<Int32> numbers = new List<int>();
            if (subs != null)
            {
                foreach (String sub in subs)
                {
                    if (Int32.TryParse(sub, out int number))
                    {
                        numbers.Add(number);
                    }
                }
            }
            return numbers;
        }
    }
}