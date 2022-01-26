using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();

            int a = int.Parse(numbers[0]);
            int b = int.Parse(numbers[1]);
            int c = int.Parse(numbers[2]);
            int d = int.Parse(numbers[3]);
            int e = int.Parse(numbers[4]);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);

            BST binaryTree = new BST();

            binaryTree.Insert(a);
            binaryTree.Insert(b);
            binaryTree.Insert(c);
            binaryTree.Insert(d);
            binaryTree.Insert(e);

            Console.WriteLine("In Order Traversal (Left->Root->Right)");
            binaryTree.PrintTree();

            Console.ReadKey();
        }
    }
}
