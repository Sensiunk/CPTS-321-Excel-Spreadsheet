using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class BST
    {
        
        private Node root;
        public Node Root
        {
            get { return root; } // Getter method to return the root value
        }

        // Check to see if the tree exists or not and inserts into the tree if it does exist
        public void Insert (int data)
        {
            if (root != null)
            {
                root.Insert(data); // Calls the insert function to insert in the tree
            }
            else
            {
                root = new Node(data); // Makes a new node for the tree if the tree hasnt been made yet
            }
        }

        // Check to see if the tree exists or not and checks if a value is in the tree or not
        public bool Find(int data)
        {
            if (root != null)
            {
                return root.Find(data); // Returns the value of a boolean to see if the value was found or not
            }
            else
            {
                return false;
            }
        }

        // Checks to see if the tree exists or not and prints the tree if it does exist
        public void PrintTree()
        {
            if (root != null)
            {
                root.PrintTree(); // Calls the print function from the tree node
            }
        }

        // Checks to see if the tree exists or not and returns the height the tree if it does exist
        public int Height()
        {
            if (root != null)
            {
                return root.Height(); // Calls the height function from the tree node
            }
            return 0;
        }

        // Checks to see if the tree exists or not and gets the number of nodes in the tree if it does exist
        public int CountNode()
        {
            if (root != null)
            {
                return root.CountNode(); // Calls the count node function from the tree node
            }
            return 0;
        }

        // Checks to see if the tree exists or not and calculates the minimum number of levels the tree if it does exist
        public int GetTheoreticalLevel()
        {
            if (root != null)
            {
                return root.GetTheoreticalLevel(); // Calls the theoretical level function from the tree node
            }
            return 0;
        }
    }
}
