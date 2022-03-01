using System;
using static FirstLab.Program;

namespace FirstLab
{
    public static class Menu
    {
        public static void AskForInput()
        {
            Console.WriteLine("How you would like to fill the tree?");
            Console.WriteLine("0 - From keyboard | 1 - Random filling | 2 - From file");
            Console.Write("Your choice: ");
        }
        public static void Greeting()
        {
            Console.WriteLine("Laboratory 1");
            Console.WriteLine("Realization of Splay - tree and its visualization");
            Console.WriteLine("Student of 404 group Zakirov Ilyas, year 2022");
        }
        public static void PrintTree(Node root, int n)
        {
            if (root != null)
            {
                PrintTree(root.left, n + 3);
                for (int i = 0; i < n; i++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(root.key);
                PrintTree(root.right, n + 3);
            }
        }
    }
}