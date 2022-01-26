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

        public int Data
        {
            get { return data; }
        }

        private Node rightNode;

        public Node RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        private Node leftNode;

        public Node LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        public Node(int value)
        {
            data = value;
        }

        public void Insert(int value)
        {
            if (value >= data)
            {
                if (rightNode == null)
                {
                    rightNode = new Node(value);
                }
                else
                {
                    rightNode.Insert(value);
                }
            }
            else
            {
                if (leftNode == null)
                {
                    leftNode = new Node(value);
                }
                else
                {
                    leftNode.Insert(value);
                }
            }
        }

        public bool Find(int val)
        {
            Node curNode = this;

            while (curNode != null)
            {
                if (val == curNode.data)
                {
                    return true;
                }
                else if (val > curNode.data)
                {
                    curNode = curNode.rightNode;
                }
                else
                {
                    curNode = curNode.leftNode;
                }
            }
            return false;
        }

        public void PrintTree()
        {
            if (leftNode != null)
            {
                leftNode.PrintTree();
            }

            Console.Write(data + " ");

            if (rightNode != null)
            {
                rightNode.PrintTree();
            }
        }

        public int Height()
        {
            if (this.leftNode == null && this.rightNode == null)
            {
                return 0;
            }

            int rightHeight = 0, leftHeight = 0;

            if (this.leftNode != null)
            {
                leftHeight = this.leftNode.Height();
            }
            if (this.rightNode != null)
            {
                rightHeight = this.rightNode.Height();
            }

            if (leftHeight > rightHeight)
            {
                return (leftHeight + 1);
            }
            else
            {
                return (rightHeight + 1);
            }
        }
    }
}
