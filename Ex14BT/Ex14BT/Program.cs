using TreeLib;

namespace Ex14BT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*BinaryTree BT = new BinaryTree();
            BT.Insert('A');
            BT.Insert('B');
            BT.Insert('C');
            BT.Insert('D');
            BT.Insert('E');
            BT.Insert('F');
            BT.Insert('G');
            BT.Insert('H');
            BT.Insert('I');
            BT.Insert('J');
            BT.Insert('K');
            BT.Insert('L');
            BT.Insert('M');
            BT.Insert('N');

            BT.PrintTree();
            BT.Remove('C');
            BT.Remove('A');
            BT.PrintTree();*/

            /*BinarySearchTree BST = new BinarySearchTree();
            BST.Insert('A');
            BST.Insert('C');
            BST.Insert('B');
            BST.PrintTree();*/

            BinaryTreeDFS BTD = new BinaryTreeDFS();
            BTD.Insert('A');
            BTD.Insert('B');
            BTD.Insert('C');
            BTD.Insert('D');
            BTD.Insert('E');
            BTD.Insert('F');
            BTD.Insert('G');
            BTD.Insert('H');
            BTD.Insert('I');
            BTD.Insert('J');
            BTD.Insert('K');
            BTD.Insert('L');
            BTD.Insert('M');
            BTD.Insert('N');

            BTD.PrintTree();
            BTD.Remove('J');
            BTD.Remove('C');
            BTD.PrintTree();
        }
    }
}