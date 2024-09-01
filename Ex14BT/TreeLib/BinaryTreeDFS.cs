using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLib
{
    public class BinaryTreeDFS
    {
        public Node? Root;
        public int count;
        public int level;

        public BinaryTreeDFS()
        {
            Root = null;
            count = 0;
            level = 0;
        }

        public void Insert(char data)
        {
            Node temp = new Node(data);
            count++;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);
            Node EmptyLink;

            if (Root == null)
            {
                Root = temp;
                return;
            }
            while (true)
            {
                EmptyLink = queue.Dequeue();

                if (EmptyLink.LeftLink != null) queue.Enqueue(EmptyLink.LeftLink);
                else
                {
                    EmptyLink.UpdateLeftLink(temp);
                    break;
                }
                if (EmptyLink.RightLink != null) queue.Enqueue(EmptyLink.RightLink);
                else
                {
                    EmptyLink.UpdateRightLink(temp);
                    break;
                }
            }
        }

        public void Remove(char data)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(Root);
            Node? lastPath = Root;

            Node? targetParent = null;
            Node? targetNode = null;

            Node? rightLeafParent = null;
            Node? rightLeaf=Root;

            while (stack.Count > 0) 
            {
                Node currentNode = stack.Peek();

                if(currentNode.Value == data)
                {
                    targetNode = stack.Pop();
                    targetParent = stack.Pop();
                    break;
                }
                
                if(currentNode.RightLink == lastPath)
                {
                    lastPath = stack.Pop();
                    continue;
                }
                else if(currentNode.LeftLink != null && currentNode.LeftLink != lastPath) 
                {
                    stack.Push(currentNode.LeftLink);
                    continue;
                }
                else if(currentNode.RightLink != null && currentNode.RightLink != lastPath) 
                {
                    stack.Push(currentNode.RightLink);
                    continue;
                }
                else
                {
                    lastPath = stack.Pop();
                    continue;
                }
            }

            stack.Clear();
            stack.Push(Root);

            while (stack.Count > 0)
            {

                rightLeaf = stack.Peek();

                if(rightLeaf.LeftLink!=null || rightLeaf.RightLink != null) 
                {
                    if(rightLeaf.RightLink != null)
                    {
                        stack.Push(rightLeaf.RightLink);
                        continue;
                    }
                    else
                    {
                        stack.Push(rightLeaf.LeftLink);
                        continue;
                    }
                }
                else
                {
                    rightLeaf = stack.Pop() ;
                    rightLeafParent = stack.Pop();

                    if (rightLeafParent.LeftLink == rightLeaf) rightLeafParent.RemoveLeftLink();
                    else if (rightLeafParent.RightLink == rightLeaf) rightLeafParent.RemoveRightLink();

                    rightLeaf.UpdateLeftLink(targetNode.LeftLink);
                    rightLeaf.UpdateRightLink(targetNode.RightLink);

                    if (targetParent.LeftLink == targetNode) targetParent.UpdateLeftLink(rightLeaf);
                    else if(targetParent.RightLink == targetNode) targetParent.UpdateRightLink(rightLeaf);

                    return;
                }
            }
        }

        public void PrintTree()
        {
            level = 0;
            Queue<Node> currentLevel = new Queue<Node>();
            Queue<Node> nextLevel = new Queue<Node>();
            currentLevel.Enqueue(Root);

            while (true)
            {
                if (currentLevel.Count == 0) break;

                Console.Write($"Line{level}: ");
                while (currentLevel.Count > 0)
                {
                    Node printNode = currentLevel.Dequeue();
                    if (printNode.LeftLink != null) nextLevel.Enqueue(printNode.LeftLink);
                    if (printNode.RightLink != null) nextLevel.Enqueue(printNode.RightLink);

                    Console.Write($"{printNode.Value} ");
                }

                Console.WriteLine(" ");
                Queue<Node> tempQueue = currentLevel;
                currentLevel = nextLevel;
                nextLevel = tempQueue;
                level++;
            }
        }
    }
}
