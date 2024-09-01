using SimpleTreeLib_PM;
using SimpleGrapeLib;

namespace TreeTEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Test SimpleBinaryTree");
            SimpleBinaryTree stree = new SimpleBinaryTree(20);

            stree.Insert('A');
            stree.Insert('B');
            stree.Insert('C');
            stree.Insert('D');
            stree.Insert('E');
            stree.Insert('F');
            stree.Insert('G');
            stree.Insert('H');
            stree.Insert('I');
            stree.Insert('J');
            stree.Insert('K');
            stree.Insert('L');
            stree.Insert('M');

            stree.Insert('B');
            stree.Insert('C');
            stree.Insert('D');
            //stree.Insert('E');
            //stree.Insert('F');
            //stree.Insert('G');
            //stree.Insert('H');
            //stree.Insert('I');
            //stree.Insert('J');
            //stree.Insert('K');
            //stree.Insert('L');
            //stree.Insert('M');

            stree.Print();
            stree.PrintTree();
            //Console.ReadLine();*/

            Console.WriteLine();
            Console.WriteLine("Test SimpleBinaryTreeWithNode");
            var SBTNode = new SimpleBinaryTreeWithNode();
            SBTNode.Insert('A');
            SBTNode.Insert('B');
            SBTNode.Insert('C');
            SBTNode.Insert('D');
            SBTNode.Insert('E');
            SBTNode.Insert('F');
            SBTNode.Insert('G');
            SBTNode.Insert('H');
            SBTNode.Insert('I');
            SBTNode.Insert('J');
            SBTNode.Insert('K');
            SBTNode.Insert('L');
            SBTNode.Insert('M');

            SBTNode.Insert('B');
            SBTNode.Insert('C');
            SBTNode.Insert('D');
            SBTNode.Insert('E');
            SBTNode.Insert('F');
            SBTNode.Insert('G');
            SBTNode.Insert('H');
            SBTNode.Insert('I');
            SBTNode.Insert('J');
            SBTNode.Insert('K');
            SBTNode.Insert('L');
            SBTNode.Insert('M');

            SBTNode.PrintTree();
            bool abc = SBTNode.FindData('E');
            Console.WriteLine(abc);

            //Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Test SimpleBinarySearchTree");
            var SBST = new SimpleBinarySearchTree();

            SBST.Insert('I');
            SBST.Insert('J');
            SBST.Insert('K');
            SBST.Insert('A');
            SBST.Insert('W');

            SBST.Insert('F');
            SBST.Insert('G');
            SBST.Insert('H');
            SBST.Insert('B');
            SBST.Insert('C');

            SBST.Insert('D');
            SBST.Insert('L');
            SBST.Insert('M');
            SBST.Insert('Z');
            SBST.Insert('C');

            SBST.Insert('D');
            SBST.Insert('E');
            SBST.Insert('Q');
            SBST.Insert('S');
            SBST.Insert('R');

            SBST.Insert('K');
            SBST.Insert('L');
            SBST.Insert('M');

            // SBST.PrintTree();
            bool q = SBST.FindData('L');
            bool w = SBST.FindData('D');
            bool e = SBST.FindData('C');
            bool r = SBST.FindData('R');


            Console.WriteLine(q);
            Console.WriteLine(w);
            Console.WriteLine(e);
            Console.WriteLine(r);
        }
    }
}