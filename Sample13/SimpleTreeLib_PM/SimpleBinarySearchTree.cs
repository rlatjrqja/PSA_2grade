using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleTreeLib_PM
{
    public class SimpleBinarySearchTree
    {
        public TreeNode? Root { get; private set; }
        public int NodeCount { get; private set; }
        public int NodeLevel { get; private set; }
        public TreeNode? Next { get; private set; }

        private Queue<TreeNode> queue;

        public SimpleBinarySearchTree()
        {
            Root=null;
            NodeCount=0;
            NodeLevel=0;
            Next=null;
            queue = new Queue<TreeNode>();
        }

        public void Insert(char data)
        {
            if(NodeCount==0)
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
                Next = Root;

                while(true)
                {
                    if (temp.Value < Next.Value)
                    {
                        if (Next.isEmptyLeftLink())
                        {
                            temp.UpdateLeftLink(temp);
                            break;
                        }
                        else Next = Next.LeftLink;
                    }
                    else if (temp.Value >= Next.Value)
                    {
                        if (Next.isEmptyRightLink())
                        {
                            temp.UpdateRightLink(temp);
                            break;
                        }
                        else Next = Next.RightLink;
                    }
                }
            }
        }

        public bool FindData(char data) 
        {
            var temp = new TreeNode(data);
            var NextNode = Root;
            bool checkFind = false;

            while(true) 
            {
                if(temp.Value < NextNode.Value) temp = NextNode.LeftLink;
                else if (temp.Value > NextNode.Value) temp = NextNode.RightLink;
                else if(temp.Value==NextNode.Value)
                {
                    checkFind = true;
                    break;
                }

                if (NextNode == null) break;
            }

            return checkFind;
        }
    }
}
