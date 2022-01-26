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

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
