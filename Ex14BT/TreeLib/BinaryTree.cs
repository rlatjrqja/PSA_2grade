using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLib
{
    public class BinaryTree
    {
        public Node? Root;
        public int count;
        public int level;

        public BinaryTree()
        {
            Root=null;
            count=0;
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
            Node? currentNode = null;
            Node? targetParent = null;
            Node? targetNode = null;
            Node? leafParent = null;
            Node? leafNode = null;

            //삭제할 데이터를 찾는다.
            //마지막으로 넣은 리프노드를 찾는다.
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);
            if(Root.Value == data)
            {
                targetNode = Root;

                while (queue.Count > 0)
                {
                    currentNode = queue.Dequeue();

                    if (currentNode.LeftLink != null) queue.Enqueue(currentNode.LeftLink);
                    if (currentNode.RightLink != null) queue.Enqueue(currentNode.RightLink);

                    if (currentNode.LeftLink == null && currentNode.RightLink == null)
                    {
                        leafNode = currentNode;
                    }
                }

                //리프노드와 그 부모의 연결을 끊는다. 
                queue.Clear();
                queue.Enqueue(Root);
                while (queue.Count > 0)
                {
                    leafParent = queue.Dequeue();
                    if (leafParent.LeftLink == leafNode)
                    {
                        leafParent.RemoveLeftLink();
                        break;
                    }
                    else if (leafParent.RightLink == leafNode)
                    {
                        leafParent.RemoveRightLink();
                        break;
                    }
                    else
                    {
                        if (leafParent.LeftLink != null) queue.Enqueue(leafParent.LeftLink);
                        if (leafParent.RightLink != null) queue.Enqueue(leafParent.RightLink);
                    }
                }


                //삭제할 데이터의 자식노드를 리프노드에 연결한다.
                leafNode.UpdateLeftLink(targetNode.LeftLink);
                leafNode.UpdateRightLink(targetNode.RightLink);

                Root = leafNode;
            }
            else
            {

                while(queue.Count > 0)
                {

                    currentNode = queue.Dequeue();

                    if(currentNode.LeftLink != null)queue.Enqueue(currentNode.LeftLink);
                    if (currentNode.RightLink != null) queue.Enqueue(currentNode.RightLink);

                    if (currentNode.LeftLink == null && currentNode.RightLink == null)
                    {
                        leafNode = currentNode;
                    }
                    if (currentNode.LeftLink != null && currentNode.LeftLink.Value == data)
                    {
                        targetParent = currentNode;
                        targetNode = currentNode.LeftLink;
                    }
                    if (currentNode.RightLink != null && currentNode.RightLink.Value == data)
                    {
                        targetParent = currentNode;
                        targetNode = currentNode.RightLink;
                    }
                }

                if (targetNode == null)
                {
                    Console.WriteLine("삭제하려는 값이 없습니다");
                    return;
                }

                //리프노드와 그 부모의 연결을 끊는다. 
                queue.Clear();
                queue.Enqueue(Root);
                while (queue.Count > 0)
                {
                    leafParent = queue.Dequeue();
                    if (leafParent.LeftLink == leafNode)
                    {
                        leafParent.RemoveLeftLink();
                        break;
                    }
                    else if (leafParent.RightLink == leafNode)
                    {
                        leafParent.RemoveRightLink();
                        break;
                    }
                    else
                    {
                        if (leafParent.LeftLink != null) queue.Enqueue(leafParent.LeftLink);
                        if (leafParent.RightLink != null) queue.Enqueue(leafParent.RightLink);
                    }
                }


                //삭제할 데이터의 자식노드를 리프노드에 연결한다.
                leafNode.UpdateLeftLink(targetNode.LeftLink);
                leafNode.UpdateRightLink(targetNode.RightLink);

                //삭제할 데이터의 부모와 리프를 연결한다.
                if (targetParent.LeftLink == targetNode) targetParent.UpdateLeftLink(leafNode);
                else if(targetParent.RightLink == targetNode) targetParent.UpdateRightLink(leafNode);

            }
            
        }

        public void PrintTree()
        {
            level=0;
            Queue<Node> currentLevel = new Queue<Node>();
            Queue<Node> nextLevel = new Queue<Node>();
            currentLevel.Enqueue(Root);

            while (true)
            {
                if(currentLevel.Count==0) break;

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
