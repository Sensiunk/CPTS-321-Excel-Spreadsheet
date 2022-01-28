using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Node
    {
        static public int counter;
        
        private int data;

        private Node rightNode;

        private Node leftNode;

        public int Data
        {
            get { return data; } // Getter method to return data
        }


        public Node RightNode
        {
            get { return rightNode; } // Getter method to return the rightNode content
            set { rightNode = value; } // Setter method to set the value that is fed to the right node
        }


        public Node LeftNode
        {
            get { return leftNode; } // Getter method to return the leftNode content
            set { leftNode = value; } // Setter method to set the value that is fed to the left node
        }

        // Constructor method
        public Node(int value)
        {
            data = value;
        }

        // This method takes in the input of a value and sets the value into either the right node or left node depending on the parent nodes value
        public void Insert(int value)
        {
            if (value >= data)
            {
                if (rightNode == null)
                {
                    rightNode = new Node(value); // If the right side is empty then make a new node and set it to the right
                }
                else
                {
                    rightNode.Insert(value); // If there is something to the right then keep recursively calling
                }
            }
            else
            {
                if (leftNode == null)
                {
                    leftNode = new Node(value); // If the left side is empty then make a new node and set it to the left
                }
                else
                {
                    leftNode.Insert(value); // If there is something to the left then keep recursively calling
                }
            }
        }

        // This method takes in the value and checks if it is in the tree already or not and returns a true or false
        public bool Find(int val)
        {
            Node curNode = this;

            while (curNode != null)
            {
                if (val == curNode.data)
                {
                    return true; // If we find it then we return true so it doesnt get added in
                }
                else if (val > curNode.data)
                {
                    curNode = curNode.rightNode; // Check again till we get to a null value but for the right side
                }
                else
                {
                    curNode = curNode.leftNode; // Check again till we get to a null value but for the left side
                }
            }
            return false; // Returns false if we never find the value
        }

        // This method recursively prints the tree in order from smallest to greatest
        public void PrintTree()
        {
            if (leftNode != null)
            {
                leftNode.PrintTree(); // Recursive call to go until we hit a null on the left node
            }

            Console.Write(data + " "); // Print the node each time we get into the function

            if (rightNode != null)
            {
                rightNode.PrintTree(); // Recursive call to go until we hit a null on the right node
            }
        }

        // This method calculates the max height in the tree
        public int Height()
        {
            if (this.leftNode == null && this.rightNode == null) // Base case to return back from recursive call
            {
                return 1;
            }

            int rightHeight = 0, leftHeight = 0;

            if (this.leftNode != null)
            {
                leftHeight = this.leftNode.Height(); // Recursive call to keep checking the height
            }
            if (this.rightNode != null)
            {
                rightHeight = this.rightNode.Height(); // Recursive call to keep checking the height
            }

            if (leftHeight > rightHeight)
            {
                return (leftHeight + 1); // If the left side is greater than return the left height plus the root node
            }
            else
            {
                return (rightHeight + 1); // If the right side is greater then return the right height plus the root node
            }
        }

        // This method uses the tree and sets the number of nodes into the counter
        public int CountNode()
        {
            if (leftNode != null)
            {
                leftNode.CountNode(); // Recursive call to go until we hit a null on the left node
            }
            counter++; // Increase the counter for every node we hit
            if (rightNode != null)
            {
                rightNode.CountNode(); // Recursive call to go until we hit a null on the right node
            }
            return counter;
        }

        // This method calculates the mimimum levels with the number of nodes in the tree
        public int GetTheoreticalLevel()
        {

            if (counter != 0)
            {
                return (int)Math.Floor(Math.Log(counter, 2) + 1); // Function that calculates the minimum number of levesl
            }
            return 0;
        }
    }
}
