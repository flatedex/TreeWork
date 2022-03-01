using System;
using System.Collections.Generic;

public class Node
{
    public int key;
    public Node left, right, parent;
    public Node(int key)
    {
        this.key = key;
        this.left = this.right = this.parent = null;
    }
}
public class Tree
{
    public Node root;

    public Tree()
    {
        this.root = null;
    }
    public Node GetRoot()
    {
        return this.root;
    }
    public static bool NullCheck(Tree tree)
    {
        return (tree.root == null) ? true : false;
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
    public static Node Search(Tree tree, int key)
    {
        return Splay(tree.GetRoot(), key);
    }
    /*public Node AddLeftNode(Node root, int key)
    {
    root.left = NewNode(key);
    return root;
    }
    public Node AddRightNode(Node root, int key)
    {
    root.right = NewNode(key);
    return root;
    }*/
    public void Zig(Node node)
    {
        // Get the parent node
        var parent = node.parent;
        // Change left subtree of parent node
        // (This new subtree is right-subtree of given current node)
        parent.left = node.right;
        if (node.right != null)
        {
            // When add subtree not empty then change parent value
            node.right.parent = parent;
        }
        // Change parent node value
        node.right = parent;
        node.parent = parent.parent;
        parent.parent = node;
    }
    // zag rotation
    public void Zag(Node node)
    {
        // Get the parent node
        var parent = node.parent;
        parent.right = node.left;
        if (parent.right != null)
        {
            // When add subtree not empty
            // then change parent value
            parent.right.parent = parent;
        }
        // Change parent node value
        node.left = parent;
        node.parent = parent.parent;
        parent.parent = node;
    }
    // zig zig rotation
    public void ZigZig(Node node)
    {
        // Get the parent node
        var parent = node.parent;
        var grandParent = node.parent.parent;
        parent.left = node.right;
        if (node.right != null)
        {
            // When add subtree not empty
            // then change parent value.
            node.right.parent = parent;
        }
        node.right = parent;
        parent.parent = node;
        grandParent.left = parent.right;
        if (parent.right != null)
        {
            parent.right.parent = grandParent;
        }
        parent.right = grandParent;
        node.parent = grandParent.parent;
        if (grandParent.parent != null)
        {
            if (grandParent.parent.left != null &&
                grandParent.parent.left == grandParent)
            {
                grandParent.parent.left = node;
            }
            else
            {
                grandParent.parent.right = node;
            }
        }
        grandParent.parent = parent;
    }
    // zag zag rotation
    public void ZagZag(Node node)
    {
        // Get the parent node
        Node parent = node.parent;
        Node grandParent = node.parent.parent;
        parent.right = node.left;
        if (node.left != null)
        {
            // When add subtree not empty then change parent value
            node.left.parent = parent;
        }
        node.left = parent;
        node.parent = grandParent.parent;
        if (grandParent.parent != null)
        {
            if (grandParent.parent.left != null && grandParent.parent.left == grandParent)
            {
                grandParent.parent.left = node;
            }
            else
            {
                grandParent.parent.right = node;
            }
        }
        parent.parent = node;
        grandParent.right = parent.left;
        if (parent.left != null)
        {
            parent.left.parent = grandParent;
        }
        parent.left = grandParent;
        grandParent.parent = parent;
    }
    // Zag zig rotation
    public void ZagZig(Node node)
    {
        // Get the parent node
        Node parent = node.parent;
        Node grandParent = node.parent.parent;
        parent.left = node.right;
        if (node.right != null)
        {
            // When add subtree not empty then change parent value
            node.right.parent = parent;
        }
        grandParent.right = node;
        node.parent = grandParent;
        node.right = parent;
        parent.parent = node;
    }
    // Zig zag rotation
    public void ZigZag(Node node)
    {
        // Get the parent node
        Node parent = node.parent;
        Node grandParent = node.parent.parent;
        parent.right = node.left;
        if (node.left != null)
        {
            // When add subtree not empty then change parent value
            node.left.parent = parent;
        }
        grandParent.left = node;
        node.parent = grandParent;
        node.left = parent;
        parent.parent = node;
    }
    public void ApplyRotation(Node node)
    {
        if (node.parent != null)
        {
            // Zig rotation condition
            if (node.parent.left != null && node.parent.left == node && node.parent.parent == null)
            {
                this.Zig(node);
            }
            else if (node.parent.right != null && node.parent.right == node && node.parent.parent == null)
            {
                this.Zag(node);
            }
            else if (node.parent.left != null && node.parent.left == node && node.parent.parent.left != null && node.parent.parent.left == node.parent)
            {
                this.ZigZig(node);
            }
            else if (node.parent.right != null && node.parent.right == node && node.parent.parent.right != null && node.parent.parent.right == node.parent)
            {
                this.ZagZag(node);
            }
            else if (node.parent.right != null && node.parent.right == node && node.parent.parent != null && node.parent.parent.left != null && node.parent.parent.left == node.parent)
            {
                this.ZigZag(node);
            }
            else if (node.parent.left != null && node.parent.left == node && node.parent.parent != null && node.parent.parent.right != null && node.parent.parent.right == node.parent)
            {
                this.ZagZig(node);
            }
            else
            {
                return;
            }
            this.ApplyRotation(node);
        }
    }
    public void InsertNode(int data)
    {
        // Get new node of tree
        Node node = new Node(data);
        Node temp = null;
        if (this.root == null)
        {
            // When splay tree empty then this is first node
            this.root = node;
        }
        else
        {
            temp = this.root;
            // Insert new node at proper position this is similar to BST
            while (temp != null)
            {
                // Check whether inserted value is greater than
                // tree current node data.
                if (data > temp.key)
                {
                    // if insert value are greater to current node value
                    if (temp.right == null)
                    {
                        // If current node Right child is null.
                        // insert new node to this position
                        temp.right = node;
                        node.parent = temp;
                        temp = null;
                    }
                    else
                    {
                        // Visit right child
                        temp = temp.right;
                    }
                }
                else
                {
                    if (temp.left == null)
                    {
                        // If current node left child is null.
                        // insert new node to this position
                        temp.left = node;
                        node.parent = temp;
                        temp = null;
                    }
                    else
                    {
                        // Visit left child
                        temp = temp.left;
                    }
                }
            }
            // Make this newly node as root node of tree
            this.ApplyRotation(node);
        }
        this.root = node;
    }
    public void DeleteNode(int value)
    {
        if (this.root != null)
        {
            Node node = this.root;
            Node rightChild = null;
            Node leftChild = null;
            // First find deleted node in Splay tree
            while (node != null && node.key != value)
            {
                if (value > node.key)
                {
                    node = node.right;
                }
                else
                {
                    node = node.left;
                }
            }
            if (node != null)
            {
                // Make root of this delete node
                this.ApplyRotation(node);
                this.root = node;
                if (node.left == null)
                {
                    // When no left side subtree of root node
                    this.root = node.right;
                }
                else if (node.right == null)
                {
                    // When no right side subtree of root node
                    this.root = node.left;
                }
                else
                {
                    if (node.left != null)
                    {
                        node.left.parent = null;
                    }
                    if (node.right != null)
                    {
                        node.right.parent = null;
                    }
                    rightChild = node.right;
                    leftChild = node.left;
                    this.root = null;
                    // Remove node
                    node.right = null;
                    node.left = null;
                    node = leftChild;
                    // Find inorder predecessor
                    while (node.right != null)
                    {
                        node = node.right;
                    }
                    this.ApplyRotation(node);
                    node.right = rightChild;
                    rightChild.parent = node;
                    this.root = node;
                }
            }
            else
            {
                Console.WriteLine($"\nNode {value} is not existing");
            }
            if (this.root != null)
            {
                this.root.parent = null;
            }
        }
    }
}