using System;
using System.Collections.Generic;
using static FirstLab.Program;

namespace FirstLab
{
    public enum MenuChoices
    {
        EXIT,
        KEYBOARD,
        FILES,
        RANDOM,
    }
    public enum TreeInterface
    {
        ADD,
        DELETE,
        PRINT,
        SAVE
    }
    public enum GAP
    {
        GAP = 1
    }
    public static class Menu
    {
        public static void Greeting()
        {
            Console.WriteLine("Laboratory 1");
            Console.WriteLine("Realization of Splay - tree and its visualization");
            Console.WriteLine("Student of 404 group Zakirov Ilyas, year 2022\n");
        }
        public static void AskForInput()
        {
            Console.WriteLine("How you would like to fill the tree?");
            Console.WriteLine("0 - Exit | 1 - From keyboard | 2 - Random filling | 3 - From file");
            Console.Write("Your choice: ");
        }
        public static void AskForTree(Tree tree)
        {
            Console.WriteLine("What you would like to do?");
            Console.WriteLine("0 - Add more nodes | 1 - Delete a node | 2 - Print the tree | 3 - Save data to file");
            TreeInterface choice = (TreeInterface)Input.GetNumber((Int32)TreeInterface.ADD, (Int32)TreeInterface.SAVE);
            switch (choice)
            {
                case TreeInterface.ADD:
                    Console.WriteLine();
                    break;
                case TreeInterface.DELETE:
                    break;
                case TreeInterface.PRINT:
                    if(!Tree.NullCheck(tree)) PrintTree(tree.root, (Int32)GAP.GAP);
                    else Console.WriteLine("The tree is empty");
                    break;
                case TreeInterface.SAVE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(choice), choice, null);
            }

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
        public static void UserInterface()
        {
            bool toExit = false;
            Menu.Greeting();
            do
            {
                Tree tree = new Tree();
                List<Int32> vs = new List<Int32>();
                Menu.AskForInput();
                MenuChoices inputChoice = (MenuChoices) Input.GetNumber();
                Console.WriteLine();
                
                switch (inputChoice)
                {
                    case MenuChoices.KEYBOARD:
                        Input.KeyboardInput(tree, vs);
                        break;
                    case MenuChoices.FILES:
                        break;
                    case MenuChoices.RANDOM:
                        Input.RandomInput(tree, vs);
                        break;
                    case MenuChoices.EXIT:
                        toExit = true;
                        break;
                    default:
                        Console.WriteLine($"Please, enter a number between {(Int32)MenuChoices.EXIT} and {(Int32)MenuChoices.RANDOM}");
                        continue;
                }
                if (inputChoice != MenuChoices.EXIT)
                {
                    Menu.AskForTree(tree);
                }

            } while (!toExit); 
        }
    }
}