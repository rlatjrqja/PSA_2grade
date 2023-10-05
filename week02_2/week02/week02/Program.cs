using System.Text;
using System.Diagnostics;
using System;

namespace StringCompare
{
    class strM
    {
        protected long TestCount;
        protected long captureTime;
    }
    class strType1 : strM
    {
        public strType1(long testCount)
        {
            TestCount = testCount;
            for (int i = 0; i < TestCount; i++)
            {
                Console.Write(" TEST console" + i);
                if (i % 1000 == 0)
                    Console.WriteLine($"[{i}]");
            }
        }
    }
    class strType2 : strM
    {
        public String str = "";
        public strType2(long testCount)
        {
            TestCount = testCount;
            for (int i = 0; i < TestCount; i++)
            {
                str += (" TEST string" + i);
                if (i % 1000 == 0)
                    Console.WriteLine($"[{i}][String.len{str.Length}]");
            }
        }
    }
    class strBuilder : strM
    {
        public int million;
        public StringBuilder stb = new StringBuilder();

        public strBuilder(long testCount)
        {
            TestCount = testCount;

            for (long i = 0; i < TestCount; i++)
            {
                try
                {
                    stb.Append(" TEST Builder" + i);
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(OutOfMemoryException))
                    {
                        //StringBuilder stb2_2 = new StringBuilder();
                        //stb2_2.Append(stb2);
                        stb.Clear();
                    }
                }

                if (i % 1_000_00 == 0)
                {
                    million++;
                    //Console.WriteLine($"[{i}][builder.cap{stb.Capacity}][builder.len{stb.Length}]");
                    Console.WriteLine($"[{i}][builder.len{million,4}{string.Format("{0:D7}", stb.Length % 1_000_000)}]");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            long captureTime1 = 0;
            long captureTime2 = 0;
            long captureTime3 = 0;
            Stopwatch sw = Stopwatch.StartNew();


            #region EXAM

            timeInit();
            strType1 str1 = new strType1(1000);
            captureTime1 = timeRecord();

            timeInit();
            strType2 str2 = new strType2(1000);
            captureTime2 = timeRecord();

            timeInit();
            strBuilder str3 = new strBuilder(1_000_000_000);
            captureTime3 = timeRecord();


            Console.WriteLine($"Console         Time[{captureTime1,10}]");
            Console.WriteLine($"String          Time[{captureTime2,10}]");
            Console.WriteLine($"StringBuilder   Time[{captureTime3,10}]");
            Console.WriteLine($"[String.len  {str2.str.Length,20}]");
            Console.WriteLine($"[builder.cap {str3.stb.Capacity,20}][builder.len {str3.stb.Length,20}]");
            //Console.WriteLine($"[builder.len{str3.million,4}{string.Format("{0:D7}", str3.stb.Length % 1_000_000)}]");


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
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
        }
    }
}