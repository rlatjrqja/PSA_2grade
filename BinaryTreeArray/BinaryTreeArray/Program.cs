namespace BinaryTreeArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree BTA = new BinaryTree(7);
            BTA.Insert('A');
            BTA.Insert('B');
            BTA.Insert('C');
            BTA.Insert('D');
            BTA.Insert('E');
            BTA.Insert('F');
            BTA.Insert('G');
            BTA.PrintTree();
            //퍼펙트 출력 예상

            BTA.Remove('F');
            BTA.Insert('H');
            BTA.Insert('I');
            BTA.PrintTree();
        }
    }

    class BinaryTree
    {
        char?[] BTA=null;

        public BinaryTree(int size)
        {
            BTA = new char?[size];
        }

        public void Insert(char data)
        {
            for(int i = 0;i<BTA.Length;i++) 
            {
                if (BTA[i] == null)
                {
                    BTA[i] = data;
                    return;
                }
            }
            Console.WriteLine("트리가 가득 찼습니다.");

            //트리 확장 기능 추가
            char?[] temp = BTA;
            BTA = new char?[BTA.Length * 2];
            for(int i=0;i<temp.Length;i++)
            {
                BTA[i] = temp[i];
            }
            Insert(data);
        }

        public void PrintTree()
        {
            int count = 0;
            int goNextLV=0;
            foreach(var item in BTA)
            {
                Console.Write(item);
                if(count == goNextLV)
                {
                    Console.Write("\n");
                    goNextLV = count * 2 + 2;
                }
                count++;
            }
        }

        public void Remove(char data) 
        {
            for(int i=0;i<BTA.Length;i++)
            {
                if (BTA[i] == data)
                {
                    BTA[i] = null;
                    return;
                }
            }
        }
    }
}