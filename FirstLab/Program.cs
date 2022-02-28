/*FirstLab.cs
Лабораторная работа номер 1
Необходимо реализовать Splay-дерево и визуализировать его работу
Студент группы 404 Закиров Ильяс Денисович 2022 год*/
using System;
using System.Collections.Generic;


namespace FirstLab
{
    class Program
    {
        public class Node
        {
            public int key;
            public Node left, right;
            public static Node NewNode(int key)
            {
                Node node = new Node();
                node.key = key;
                node.left = node.right = null;
                return node;
            }
            public static Node RightRotate(Node x)
            {
                Node y = x.left;
                x.left = y.right;
                y.right = x;
                return y;
            }
            public static Node LeftRotate(Node x)
            {
                Node y = x.right;
                x.right = y.left;
                y.left = x;
                return y;
            }
            public static Node Splay(Node root, int key)
            {
                if (root == null || root.key == key)
                {
                    return root;
                }
                if (root.key > key)
                {
                    if (root.left == null) return root;
                    if (root.left.key > key)
                    {
                        root.left.left = Splay(root.left.left, key);
                        root = RightRotate(root);
                    }
                    else if (root.left.key < key)
                    {
                        root.left.right = Splay(root.left.right, key);
                        if (root.left.right != null) root.left = LeftRotate(root.left);
                    }
                    return (root.left == null) ? root : RightRotate(root);
                }
                else
                {
                    if (root.right == null) return root;
                    if (root.right.key > key)
                    {
                        root.right.left = Splay(root.right.left, key);
                        if (root.right.left != null) root.right = RightRotate(root.right);
                    }
                    else if (root.right.key < key)
                    {
                        root.right.right = Splay(root.right.right, key);
                        root = LeftRotate(root);
                    }
                    return (root.right == null) ? root : LeftRotate(root);
                }
            }
            public static Node Search(Node root, int key)
            {
                return Splay(root, key);
            }
            public Node AddLeftNode(Node root, int key)
            {
                root.left = NewNode(key);
                return root;
            }
            public Node AddRightNode(Node root, int key)
            {
                root.right = NewNode(key);
                return root;
            }
        }
        
        
        static void PreOrder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.key + " ");
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }
        static void PrintTree(Node root, int n)
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
        class FFa
        {
            
        }
        class Menu
        {
            public static void AskForInput()
            {
                Console.WriteLine("Как вы желаете заполнить дерево?");
                Console.WriteLine("0 - С клавиатуры | 1 - Случайными значениями | 2 - Из файла");
                Console.Write("Ваш выбор: ");
            }
        }
        
        static void Main()
        {
            Node root = Node.NewNode(100);
            root.AddLeftNode(root, 40);
            root.left.AddLeftNode(root.left, 30);
            root.left.left.AddLeftNode(root.left.left, 10);
            root.left.left.AddRightNode(root.left.left, 35);
            root.AddRightNode(root, 150);
            root.right.AddLeftNode(root.right, 50);
            Menu.AskForInput();
            PrintTree(root, 3);
            Console.WriteLine("____________________________");

            root = Node.Search(root, 35);

            PrintTree(root, 3);
            //PreOrder(root);
        }
    }
}
