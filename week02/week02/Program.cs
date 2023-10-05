using System.Text;
using System.Diagnostics;
using System;

namespace StringCompare
{
    class Ex2
    {
        public long TestCount;
        public long captureTime = 0;
        String str2 = "";
        StringBuilder stb2 = new StringBuilder();

        public int overCount = 0;
        public int million = -1;

        public Ex2(long testCount)
        {
            TestCount = testCount;
        }

        public void repeat(int a)
        {
            for (int i = 0; i < TestCount; i++)
            {
                if (a == 1) Console.Write(" TEST console" + i);
                if (a == 2) str2 += (" TEST string" + i);
                if (a == 3)
                {
                    try
                    {
                        stb2.Append(" TEST builder" + i);
                    }
                    catch (Exception e)
                    {
                        if (e.GetType() == typeof(OutOfMemoryException))
                        {
                            //StringBuilder stb2_2 = new StringBuilder();
                            //stb2_2.Append(stb2);
                            overCount++;
                            //stb2 = stb[overCount];
                            stb2.Clear();

                            //stb2.EnsureCapacity(stb2.Length * 2);
                        }
                    }

                    if (i % 1_000_000 == 0)
                    {
                        million++;
                        Console.WriteLine($"[{i}][builder.len{million,4}{string.Format("{0:D7}", stb2.Length % 1_000_000)}]");
                    }
                }

                    if (i % 1000 == 0)
                    Console.WriteLine($"[{i}]");
            }
        }

        ~Ex2() { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            String str2 = "";
            StringBuilder[] stb = new StringBuilder[10];
            //StringBuilder stb2 = stb[0];
            StringBuilder stb2 = new StringBuilder();
            

            Stopwatch sw = Stopwatch.StartNew();


            #region exam
            
            timeInit();
            Ex2 type1 = new(1_000);
            //type1.repeat(1);
            /*for (int i = 0; i < type1.TestCount; i++)
            {
                Console.Write(" TEST console" + i);
                if (i % 1000 == 0) 
                    Console.WriteLine($"[{i}]");
            }*/
            type1.captureTime = timeRecord();
            

            timeInit();
            Ex2 type2 = new(1_000_000);
            //type2.repeat(2);
            /*for (int i = 0; i < type2.TestCount; i++)
            {
                str2 += (" TEST string" + i);
                if (i % 1000 == 0) 
                    Console.WriteLine($"[{i}][String.len{str2.Length}]");
            }*/
            type2.captureTime = timeRecord();
            

            timeInit();
            Ex2 type3 = new(1_000_000_000);
            type2.repeat(3);
            int overCount = 0;
            int million = -1;

            for (int i = 0; i < type3.TestCount; i++)
            {
                try
                {
                    stb2.Append(" TEST builder" + i);
                }
                catch (Exception e)
                {
                    if(e.GetType() == typeof(OutOfMemoryException))
                    {
                        //StringBuilder stb2_2 = new StringBuilder();
                        //stb2_2.Append(stb2);
                        overCount++;
                        //stb2 = stb[overCount];
                        stb2.Clear();

                        //stb2.EnsureCapacity(stb2.Length * 2);
                    }
                }
                
                if (i % 1_000_000 == 0)
                {
                    million++;
                    Console.WriteLine($"[{i}][builder.len{million,4}{string.Format("{0:D7}", stb2.Length % 1_000_000)}]");
                }

            }
            type3.captureTime = timeRecord();

            Console.WriteLine($"Console         Time[{type1.captureTime,10}]");
            Console.WriteLine($"String          Time[{type2.captureTime,10}]");
            Console.WriteLine($"StringBuilder   Time[{type3.captureTime,7}]");
            Console.WriteLine($"[String.len  {str2.Length,10}]");
            Console.WriteLine($"[builder.len{type3.million,4}{string.Format("{0:D7}", stb2.Length % 1_000_000)}]");


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

            int stb_append(StringBuilder stb,int i)
            {
                stb.Append(" TEST builder" + i);

                return 0;
            }
        }
    }
}