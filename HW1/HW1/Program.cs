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
            BST binaryTree = new BST();

            // #1.1
            string numbers = Console.ReadLine();

            // #1.2
            foreach (var num in numbers.Split(' '))
            {
                if (Convert.ToInt32(num) < 100)
                {
                    if (binaryTree.Find(Convert.ToInt32(num)) == false)
                        binaryTree.Insert(Convert.ToInt32(num));
                }
                    
            }


            /*int a = int.Parse(numbers[0]);
            int b = int.Parse(numbers[1]);
            int c = int.Parse(numbers[2]);
            int d = int.Parse(numbers[3]);
            int e = int.Parse(numbers[4]);*/

            //int numberOfEntries = numbers.Count();

            /*Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);

            

            binaryTree.Insert(a);
            binaryTree.Insert(b);
            binaryTree.Insert(c);
            binaryTree.Insert(d);
            binaryTree.Insert(e);*/

            // #3
            Console.WriteLine("The tree in order is: ");
            binaryTree.PrintTree();

            // #4.2
            Console.WriteLine(binaryTree.Height());

            Console.ReadKey();
        }
    }
}
