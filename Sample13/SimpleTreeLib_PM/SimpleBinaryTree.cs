namespace SimpleTreeLib_PM
{
    public class SimpleBinaryTree
    {
        // 데이터
        public char[] Node;
        public int NodeCount { get; private set; }
        public int MaxNode {  get; private set; }
        // 기능
        public SimpleBinaryTree() 
        {
            NodeCount = 0;
            MaxNode = 0;
        }
        // 데이터 입력
        public void Insert(char data)
        {
            if( NodeCount == 0 ) 
            {
                MaxNode = 1;
                Node = new char[MaxNode];
                Node[NodeCount++] = data;
            }
            else
            {
                // L=0    1                1
                // L=1   2 3               직전 갯수 * 2 +1
                // L=2 4 5 6 7             직전 갯수 * 2
                // 최대 갯수 1-> 3->7-> 15 -> 31 -> ...
                if (NodeCount == MaxNode)
                {
                    MaxNode = 2 * MaxNode + 1;
                }
                //Console.WriteLine($"MaxNode[{MaxNode}]");
                
                char[] temp = new char[MaxNode];
                if( Node != null ) Node.CopyTo(temp, 0);

                temp[NodeCount++] = data;
                Node = temp;

                //if (Node != null) Print();
            }
        }
        // 데이터 출력
        public void Print() 
        {
            Console.Write($"TotalCount[{NodeCount}]->");
            foreach(var data in Node)
            {
                Console.Write($"[{data}]");
            }
            Console.WriteLine();
        }
        public void PrintTree()
        {
            Console.WriteLine($"\t<< TotalCount[{NodeCount}]-Level[??] >>");

            for (int i = 0, j = 1, k = 0, level = 0; i < NodeCount; i++)
            {
                if (i == 0) { Console.Write($"\t[{level++}]->"); }
                // 자식 노드 2개씩 묶기위한 대괄호용
                if (k % 2 == 0) { Console.Write($"["); }
                // 데이터 출력
                Console.Write($"{Node[i]}");
                // 자식 노드 2개씩 묶기위한 대괄호용
                if (k++ % 2 == 1) { Console.Write($"]"); k = 0; }
                // 레벨 구별용 라인 출력
                if (i == j - 1)
                {
                    Console.WriteLine();
                    Console.Write($"\t[{level++}]->");
                    j = j * 2 + 1;
                    k = 0;
                }
            }
        }
    }
}