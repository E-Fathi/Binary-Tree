using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_tree
{
    class Program
    {
        public static void PrintMenu()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|                  Main menu                |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1: Add a Node\t2: Remove a Node");
            Console.WriteLine("3: Get The Depth of Tree");
            Console.WriteLine("4: Get Number of Nodes");
            Console.WriteLine("5: Get Number of leaf");
            Console.WriteLine("6: Sum of Tree");
            Console.WriteLine("7: PosOrder Traversal");
            Console.WriteLine("8: InOrder Traversal");
            Console.WriteLine("9: PreOrder traversal");
            Console.WriteLine("10: The Max Node");
            Console.WriteLine("11: The Min Node");
            Console.WriteLine("12: Test");
            Console.WriteLine("13: Quit");
        }
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            try
            {
                while (true)
                {
                    PrintMenu();
                    string selection = Console.ReadLine();
                    int selectionNum = Convert.ToInt16(selection);
                    if (selectionNum <= 12 && selectionNum >= 1)// doing task
                    {
                        switch (selectionNum)
                        {
                            case 1:
                                Console.WriteLine("Enter a Number");
                                string node = Console.ReadLine();
                                int nodeinfo = Convert.ToInt32(node);
                                bt.Add(nodeinfo);
                                break;
                            case 2:
                                Console.WriteLine("Enter a Number");
                                string node2 = Console.ReadLine();
                                int nodeinfo2 = Convert.ToInt32(node2);
                                bt.Remove(nodeinfo2);
                                break;
                            case 3:
                                bt.GetDepth();
                                break;
                            case 4:
                                bt.Number();
                                break;
                            case 5:
                                bt.LeafCount();
                                break;
                            case 6:
                                bt.Sum();
                                break;
                            case 7:
                                bt.PostOrder();
                                break;
                            case 8:
                                bt.InOrder();
                                break;
                            case 9:
                                bt.PreOrder();
                                break;
                            case 10:
                                bt.Max();
                                break;
                            case 11:
                                bt.Min();
                                break;
                            case 12:
                                bt.Add(25);
                                bt.Add(70);
                                bt.Add(50);
                                bt.Add(13);
                                bt.Add(30);
                                bt.Add(35);
                                bt.Add(33);
                                bt.Add(65);
                                bt.Add(60);
                                bt.Add(62);
                                bt.Add(68);
                                bt.Add(61);
                                bt.Add(64);
                                bt.PostOrder();
                                bt.PreOrder();
                                bt.InOrder();
                                bt.GetDepth();
                                bt.Number();
                                bt.LeafCount();
                                bt.Min();
                                bt.Max();
                                bt.Sum();
                                break;
                        }
                    }
                    else if (selectionNum == 13)
                        break;
                    else
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("|      Invalis selection, try again :(      |");
                        Console.WriteLine("--------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
    class Node
    {
        public Node Left;
        public Node Right;
        public int data;
        public Node(int value = 0)
        {
            this.data = value;
            this.Left = null;
            this.Right = null;
        }
    }
    class BinaryTree
    {

        public Node Root;
        public bool Add(int value)
        {
            Node before = null;
            Node after = this.Root;
            while (after != null)
            {
                before = after;
                if (value < after.data)
                    after = after.Left;
                else if (value > after.data)
                    after = after.Right;
                else
                {
                    Console.WriteLine("Same Value Exist");
                    return false;
                }
            }
            Node newNode = new Node();
            newNode.data = value;
            if (this.Root == null)//Tree is Empty
                this.Root = newNode;
            else
            {
                if (value < before.data)
                    before.Left = newNode;
                else
                    before.Right = newNode;
            }
            return true;
        }
        public void GetDepth()
        {
            int depth = GetTreeDepth(this.Root);
            Console.WriteLine("Tree depth is :" + depth);
            Console.WriteLine("--------------------------------------------");
        }
        int GetTreeDepth(Node parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.Left), GetTreeDepth(parent.Right)) + 1;
        }
        public void PreOrder()
        {
            Console.Write("PreOrder Traversal :"); TraversePreOrder(this.Root);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }
        void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.data + " ");
                TraversePreOrder(parent.Left);
                TraversePreOrder(parent.Right);
            }
        }
        public void InOrder()
        {
            Console.Write("InOrder Traversal :"); TraverseInOrder(this.Root);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }
        void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.Left);
                Console.Write(parent.data + " ");
                TraverseInOrder(parent.Right);
            }

        }
        public void PostOrder()
        {
            Console.Write("PostOrder Traversal :"); TraversePostOrder(this.Root);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }
        void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.Left);
                TraversePostOrder(parent.Right);
                Console.Write(parent.data + " ");
            }
        }
        public void Number()
        {
            Console.WriteLine("Number of Nodes :" + NodeNumber(this.Root));
            Console.WriteLine("--------------------------------------------");
        }
        int NodeNumber(Node parent)
        {
            if (parent == null)
                return 0;
            return NodeNumber(parent.Left) + NodeNumber(parent.Right) + 1;
        }
        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }
        Node Remove(Node parent, int a)
        {
            if (parent == null) return parent;
            if (a < parent.data) parent.Left = Remove(parent.Left, a);
            else if (a > parent.data)
                parent.Right = Remove(parent.Right, a);
            else if (!(a < parent.data && a > parent.data && a == parent.data))
                Console.WriteLine("The Value Does Not Exist");

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.Left == null)
                    return parent.Right;
                else if (parent.Right == null)
                    return parent.Left;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.data = MinValue(parent.Right);

                // Delete the inorder successor  
                parent.Right = Remove(parent.Right, parent.data);
            }

            return parent;
        }
        public void Sum()
        {
            int sum = SumNode(this.Root);
            Console.WriteLine("Sum of all the elements is: " + sum);
            Console.WriteLine("--------------------------------------------");
        }
        int SumNode(Node parent)
        {
            if (parent == null)
            {
                return 0;
            }
            return (parent.data + SumNode(parent.Left) + SumNode(parent.Right));
        }
        public void Min()
        {
            Console.WriteLine("Min Node is :" + MinValue(this.Root));
            Console.WriteLine("--------------------------------------------");
        }
        int MinValue(Node node)
        {
            int min = node.data;

            while (node.Left != null)
            {
                min = node.Left.data;
                node = node.Left;
            }

            return min;
        }
        public void Max()
        {
            Console.WriteLine("Max Node is:" + MaxValue(this.Root));
            Console.WriteLine("--------------------------------------------");
        }
        int MaxValue(Node node)
        {
            int max = node.data;
            while (node.Right != null)
            {
                max = node.Right.data;
                node = node.Right;
            }
            return max;
        }
        public void LeafCount()
        {
            Console.WriteLine("Leaf Count is :" + GetLeafCount(this.Root));
            Console.WriteLine("--------------------------------------------");
        }
        int GetLeafCount(Node node)
        {
            if (node == null)
                return 0;
            if (node.Left == null && node.Right == null)
                return 1;
            else
                return GetLeafCount(node.Left) + GetLeafCount(node.Right);
        }
    }
}
