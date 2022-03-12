using System;
using System.Collections.Generic;
using static FirstLab.Program;

namespace FirstLab
{
    public enum MenuChoices
    {
        KEYBOARD,
        RANDOM,
        FILES,
        EXIT
    }
    public enum TreeInterface
    {
        ADD,
        DELETE,
        PRINT,
        SAVEDATA,
        SAVERESULT,
        EXIT
    }
    public enum DualChoice
    {
        YES,
        NO
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
            Console.WriteLine("0 - From keyboard | 1 - Random filling | 2 - From file | 3 - Exit");
            Console.Write("Your choice: ");
        }
        public static void AskForTreeAction()
        {
            Console.WriteLine("What you would like to do?");
            Console.WriteLine("0 - Add more nodes | 1 - Delete a node | 2 - Print the tree | 3 - Save data to file | 4 - Save result to file | 5 - Exit");
            Console.Write("Your choice: ");
        }
        public static void TreeInterface(Tree tree, List<Int32> vs)
        {
            bool toExit = false;
            do
            {
                AskForTreeAction();
                TreeInterface choice = (TreeInterface)Input.GetNumber((Int32)FirstLab.TreeInterface.ADD, (Int32)FirstLab.TreeInterface.EXIT);
                switch (choice)
                {
                    case FirstLab.TreeInterface.ADD:
                        Input.KeyboardInput(tree, vs);
                        break;
                    case FirstLab.TreeInterface.DELETE:
                        Console.WriteLine("Enter the wanted value to delete");
                        tree.DeleteNode(Input.GetNumber());
                        break;
                    case FirstLab.TreeInterface.PRINT:
                        if (!Tree.NullCheck(tree)) PrintTree(tree.root, (Int32)GAP.GAP);
                        else Console.WriteLine("The tree is empty");
                        break;
                    case FirstLab.TreeInterface.SAVEDATA:
                        FileWork.SaveInput(vs);
                        //
                        break;
                    case FirstLab.TreeInterface.SAVERESULT:
                        FileWork.SaveResult(tree.root);
                        break;
                    case FirstLab.TreeInterface.EXIT:
                        toExit = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(choice), choice, null);
                }
            }while (!toExit);
        }

        public static Boolean AskForRewriting()
        {
            Console.WriteLine("File is already exist, do you want to rewrite it?");
            Console.WriteLine("0 - Yes | 1 - No");
            DualChoice choice = (DualChoice)Input.GetNumber((Int32)DualChoice.YES, (Int32)DualChoice.NO);
            switch(choice)
            {
                case DualChoice.YES:
                    return true;
                case DualChoice.NO:
                    return false;
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
                        do {} while (!FileWork.GetFromFile(tree, vs));
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
                    Menu.TreeInterface(tree, vs);
                }

            } while (!toExit); 
        }
    }
}