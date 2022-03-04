using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Hello World!");
            bool runSimulation = true;
            
            
            
            string ans = string.Empty, varName = string.Empty, varVal = string.Empty;
            string userExp = "A1+B2+C1";
            ExpressionTree tree = new ExpressionTree(string.Empty);
            while (runSimulation == true)
            {
                Console.WriteLine("Menu (current expression=\"" + userExp + "\")");
                Console.WriteLine("1 = Enter a new expression");
                Console.WriteLine("2 = Set a variable value");
                Console.WriteLine("3 = Evaluate tree");
                Console.WriteLine("4 = Quit");

                ans = Console.ReadLine();

                try
                {
                    switch (Convert.ToInt32(ans))
                    {
                        // Need the option to grab the entered expression
                        case 1:
                            Console.WriteLine("Enter a new expression: ");
                            userExp = Console.ReadLine();
                            tree = new ExpressionTree(userExp);
                            break;

                        // Need the option to set a variables value in the expression. Must ask for both the variable name and value
                        case 2:
                            Console.WriteLine("Enter the name of the variable: ");
                            varName = Console.ReadLine();
                            Console.WriteLine("Enter the value of the variable: ");
                            varVal = Console.ReadLine();
                            tree.SetVariable(varName, Convert.ToDouble(varVal));
                            break;

                        // Need the option to evaluate the expression to a numerical value
                        case 3:
                            Console.WriteLine(tree.Evaluate());
                            break;

                        // Need the option to quit
                        case 4:
                            runSimulation = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Done");
        }
    }
}
