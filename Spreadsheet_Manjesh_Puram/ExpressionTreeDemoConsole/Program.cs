// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that runs our code to do the demo to see if our expression tree works as intended.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function that runs the program.
        /// </summary>
        /// <param name="args"> Total number of arguments. </param>
        private static void Main(string[] args)
        {
            bool runSimulation = true;
            string varName = string.Empty, varVal = string.Empty;
            string userExp = "A1+B2+C1";
            ExpressionTree ourNewTree = new ExpressionTree(string.Empty);

            while (runSimulation == true)
            {
                Console.WriteLine("Menu (current expression=\"" + userExp + "\")");
                Console.WriteLine("1 = Enter a new expression");
                Console.WriteLine("2 = Set a variable value");
                Console.WriteLine("3 = Evaluate tree");
                Console.WriteLine("4 = Quit");

                string userResponse = Console.ReadLine();

                try
                {
                    switch (Convert.ToInt32(userResponse))
                    {
                        // Need the option to grab the entered expression
                        case 1:
                            Console.WriteLine("Enter a new expression: ");
                            userExp = Console.ReadLine();
                            ourNewTree = new ExpressionTree(userExp);
                            break;

                        // Need the option to set a variables value in the expression. Must ask for both the variable name and value
                        case 2:
                            Console.WriteLine("Enter the name of the variable: ");
                            string variableName = Console.ReadLine();
                            Console.WriteLine("Enter the value of the variable: ");
                            string variableValue = Console.ReadLine();
                            ourNewTree.SetVariable(variableName, Convert.ToDouble(variableValue));
                            break;

                        // Need the option to evaluate the expression to a numerical value
                        case 3:
                            Console.WriteLine(ourNewTree.Evaluate());
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
