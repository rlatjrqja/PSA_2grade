using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleTreeLib_PM
{    
    public class SimpleBinaryTreeWithNode
    {
        // 트리 노드 링크관련 데이터 
        public TreeNode? Root { get; private set; }
        public int NodeCount { get; private set; }
        public int NodeLevel { get; private set; }
        public TreeNode? Next { get; private set; }

        // 기능
        public SimpleBinaryTreeWithNode()
        {
            NodeCount = 0;
            NodeLevel = 0;
            Root = null;
            Next = null;
        }
        // 데이터 입력
        public void Insert(char data)
        {
            if( NodeCount == 0 ) 
            {
                Root = new TreeNode(data);
                NodeCount++;
                NodeLevel++;
                Next = Root;
            }
            else
            {
                var temp = new TreeNode(data);
                NodeCount++;

                // 왼쪽이 비어있는가 ??
                if( Next.isEmptyLeftLink() )
                {
                    Next.UpdateLeftLink(temp);
                }
                else if (Next.isEmptyRightLink() )
                {
                    Next.UpdateRightLink(temp);
                    // Next Update
                    Next = FindNextPosition();
                }
            }
        }
        private TreeNode? FindNextPosition()
        {
            if (NodeCount == 0) return null;
            else
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(Root);

                do
                {
                    TreeNode temp = queue.Dequeue();
                    if( temp.isLeftLink() ) {  queue.Enqueue(temp.LeftLink); }
                    else { return temp; }
                    if (temp.isRightLink()) { queue.Enqueue(temp.RightLink); }
                    else { return temp; }

                }while(queue.Count > 0);
                return null;

            }
        }
        // 데이터 검색
        public bool FindData(char data) 
        {
            if (NodeCount == 0) return false;
            else
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(Root);

                do
                {
                    TreeNode temp = queue.Dequeue();
                    if (temp.Value == data)
                    {
                        return true;
                    }
                    else
                    {
                        if (temp.isLeftLink()) { queue.Enqueue(temp.LeftLink); }
                        if (temp.isRightLink()) { queue.Enqueue(temp.RightLink); }
                    }

                } while (queue.Count > 0);
                return false;

            }
        }

        // 데이터 삭제
        public void Remove(char data) 
        {
            TreeNode? FindParentNode = null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);

            do
            {
                TreeNode temp = queue.Dequeue();

                if (temp.LeftLink.Value == data || temp.LeftLink.Value == data)
                {
                    FindParentNode = temp;
                    break;
                }

                if (temp.isLeftLink()) { queue.Enqueue(temp.LeftLink); }
                if (temp.isRightLink()) { queue.Enqueue(temp.RightLink); }

            } while (queue.Count > 0);

            //리프 노드일 때
            //if (FindParentNode.LeftLink.Value == data) FindParentNode.RemoveLeftLink(FindParentNode.LeftLink);
            //if (FindParentNode.RightLink.Value == data) FindParentNode.RemoveRightLink(FindParentNode.RightLink);




            TreeNode? FindChildNode = null;
            queue.Clear();

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                TreeNode temp = queue.Dequeue();

                if (temp.LeftLink==null && temp.RightLink==null)
                {
                    FindChildNode = temp;
                    break;
                }
            }

            if(FindChildNode == null)
            {

            }
        }
        // 데이터 출력
        public void Print() { }
        public void PrintTree()
        {
            
        }
    }
}
