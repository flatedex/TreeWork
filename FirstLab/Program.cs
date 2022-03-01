/*Program.cs
Лабораторная работа номер 1
Необходимо реализовать Splay-дерево и визуализировать его работу
Студент группы 404 Закиров Ильяс Денисович 2022 год*/
using System;
using System.Collections.Generic;
using static FirstLab.Menu;

namespace FirstLab
{
    public class Program
    {
        static void PreOrder(Node root) //вывод обхода в ширину
        {
            if (root != null)
            {
                Console.Write(root.key + " ");
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }

        public static class Printer
        {
            class NodeInfo
            {
                public Node node;
                public string text;
                public int startPos;
                public int size { get { return text.Length; } }
                public int endPos { get { return startPos + size; } set { endPos = startPos + size; } }

                public NodeInfo parent, left, right;
            }
            static void AnotherPrint(Node root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2)
            {
                if (root == null) return;
                int rootTop = Console.CursorTop + topMargin;
                var last = new List<NodeInfo>();
                var next = root;
                for (int level = 0; next != null; level++)
                {
                    var item = new NodeInfo { node = next, text = next.key.ToString() };
                    if (level < last.Count)
                    {
                        item.startPos = last[level].endPos + spacing;
                        last[level] = item;
                    }
                    else
                    {
                        item.startPos = leftMargin;
                        last.Add(item);
                    }
                    if (level > 0)
                    {
                        item.parent = last[level - 1];
                        if (next == item.parent.node.left)
                        {
                            item.parent.left = item;
                            item.endPos = Math.Max(item.endPos, item.parent.startPos - 1);
                        }
                        if (next == item.parent.node.right)
                        {
                            item.parent.left = item;
                            item.startPos = Math.Max(item.startPos, item.parent.endPos + 1);
                        }
                    }
                }
            }
        }
        
        static void Main()
        {
            Menu.Greeting();
            Menu.AskForInput();

            Console.WriteLine();

            Tree tree = new Tree();
            tree.InsertNode(9);
            tree.InsertNode(3);
            tree.InsertNode(7);
            tree.InsertNode(20);
            tree.InsertNode(13);
            tree.InsertNode(32);
            tree.InsertNode(1);
            tree.InsertNode(4);

            Menu.PrintTree(tree.GetRoot(), 1);

            Console.WriteLine("____________________________");

            tree.DeleteNode(3);

            Menu.PrintTree(tree.GetRoot(), 1);
        }
    }
}
