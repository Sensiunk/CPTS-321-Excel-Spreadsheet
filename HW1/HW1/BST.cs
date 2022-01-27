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
            get { return root; }
        }

        public void Insert (int data)
        {
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {
                root = new Node(data);
            }
        }

        public bool Find(int data)
        {
            if (root != null)
            {
                return root.Find(data);
            }
            else
            {
                return false;
            }
        }

        public void PrintTree()
        {
            if (root != null)
            {
                root.PrintTree();
            }
        }

        public int Height()
        {
            if (root == null)
            {
                return 0;
            }
            return root.Height();
        }

        public int countNode()
        {
            if (root == null)
            {
                return 0;
            }
            return root.countNode();
        }
    }
}
