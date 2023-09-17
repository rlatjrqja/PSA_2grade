using System.Text;
using System.Diagnostics;

namespace StringCompare
{
    class Ex2
    {
        public long TestCount;
        public long captureTime = 0;

        public Ex2(long testCount)
        {
            TestCount = testCount;
        }
        ~Ex2() { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //long TestCount = long.Parse(input);
            //long TestCount = 1_000_000_000;
            long captureTime1 = 0;
            long captureTime2 = 0;
            long captureTime3 = 0;
            String str2 = "";
            StringBuilder stb2 = new StringBuilder();


            Stopwatch sw = Stopwatch.StartNew();


            #region exam
            
            /*
            timeInit();
            
            for (int i = 0; i < TestCount; i++)
            {
                Console.Write(" TEST console" + i);
                if (i % 1000 == 0) 
                    Console.WriteLine($"[{i}]");
            }
            captureTime1 = timeRecord();


            timeInit();
            for (int i = 0; i < TestCount; i++)
            {
                str2 += (" TEST string" + i);
                if (i % 1000 == 0) 
                    Console.WriteLine($"[{i}][String.len{str2.Length}]");
            }
            captureTime2 = timeRecord();
            */

            timeInit();
            Ex2 type3 = new(1_000_000_000);
            int overCount = 0;
            int million = -1;

            for (int i = 0; i < type3.TestCount; i++)
            {
                try
                {
                    stb2.Append(" TEST builde" + i);
                }
                catch (Exception e)
                {
                    if(e.GetType() == typeof(OutOfMemoryException))
                    {
                        //StringBuilder stb2_2 = new StringBuilder();
                        //stb2_2.Append(stb2);
                        overCount++;
                        stb2.Clear();
                    }
                }
                if (i % 1_000_000 == 0)
                {
                    million++;
                    Console.WriteLine($"[{i}][builder.len{million}{stb2.Length % 1_000_000}]");
                }

            }
            type3.captureTime = timeRecord();

            //Console.WriteLine($"Console         Time[{captureTime1,10}]");
            //Console.WriteLine($"String          Time[{captureTime2,10}]");
            Console.WriteLine($"StringBuilder   Time[{type3.captureTime,10}]");
            //Console.WriteLine($"[String.len  {str2.Length,10}]");
            Console.WriteLine($"[builder.len {million}{stb2.Length % 1_000_000,10}]");


            #endregion

            //타이머 초기화 및 시작
            int timeInit()
            {
                sw.Reset();
                sw.Start();

                return 0;
            }

            //문자열 출력 후 타이머 기록
            long timeRecord()
            {
                Console.WriteLine(str2);
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
        }
    }
}