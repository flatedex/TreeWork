using System;

namespace FirstLab
{
    public class Menu
    {
        public static void AskForInput()
        {
            Console.WriteLine("Как вы желаете заполнить дерево?");
            Console.WriteLine("0 - С клавиатуры | 1 - Случайными значениями | 2 - Из файла");
            Console.Write("Ваш выбор: ");
        }
    }
}