using System;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread myThread = new Thread(Func);
            myThread.Start(7);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("쓰레드1 : " + i);
                Thread.Sleep(100);
            }
            Console.WriteLine("쓰레드1 종료");
        }
        private static void Func(object obj)
        {
            int num = (int)obj;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("기본1 : "+ i);
                Thread.Sleep(100);
            }
        }
    }
}