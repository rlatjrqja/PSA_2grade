using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLib
{
    public class BinarySearchTree
    {
        Node? Root;
        int Count = 0;

        public BinarySearchTree()
        {
            Root = null;
            Count = 0;
        }

        public void Insert(char data)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            Node temp = new Node(data);
            Count++;

            Node? currentNode = Root;

            if (Root == null)
            {
                Root = temp;
            }
            else
            {
                while(queue.Count > 0) 
                {
                    currentNode = queue.Dequeue();

                    if (temp.Value < currentNode.Value)
                    {
                        if (currentNode.LeftLink == null)
                        {
                            currentNode.UpdateLeftLink(temp);
                        }
                        else
                        {
                            queue.Enqueue(currentNode.LeftLink);
                        }
                    }
                    else if (temp.Value >= currentNode.Value)
                    {
                        if (currentNode.RightLink == null)
                        {
                            currentNode.UpdateRightLink(temp);
                        }
                        else
                        {
                            queue.Enqueue(currentNode.RightLink);
                        }
                    }
                }
            }
        }

        public void PrintTree()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);
            Node currentNode;

            while (queue.Count > 0) 
            {
                currentNode = queue.Dequeue();
                if(currentNode.LeftLink != null) queue.Enqueue(currentNode.LeftLink);
                if(currentNode.RightLink!=null) queue.Enqueue(currentNode.RightLink);

                Console.Write(currentNode.Value);
            }
        }
    }
}
