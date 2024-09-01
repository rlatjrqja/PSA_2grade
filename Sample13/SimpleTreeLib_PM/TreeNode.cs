using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTreeLib_PM
{
    public class TreeNode
    {
        public char Value {  get; private set; }
        public TreeNode? LeftLink { get; private set; }
        public TreeNode? RightLink { get; private set; }

        public TreeNode(char data)
        {
            Value = data;
            LeftLink = null;
            RightLink = null;
        }
        public void UpdateLeftLink(TreeNode node) {  LeftLink = node; }
        public void UpdateRightLink(TreeNode node) {  RightLink = node; }
        public void RemoveLeftLink(TreeNode node) { LeftLink = null; }
        public void RemoveRightLink(TreeNode node) { RightLink = null; }
        public bool isEmptyLeftLink() { return LeftLink == null; }
        public bool isEmptyRightLink() {  return RightLink == null; }
        public bool isLeftLink() { return LeftLink != null;}
        public bool isRightLink() { return RightLink != null;}

    }
}
