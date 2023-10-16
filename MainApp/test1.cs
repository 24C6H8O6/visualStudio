using System;

namespace Enum
{
    class Test1
    {
        enum DialogResult {YES, NO, CANCEL, CONFIRM, OK}

        static void Main(string[] args)
        {
            Console.WriteLine((int)DialogResult.YES);
            Console.WriteLine((int)DialogResult.NO);
            Console.WriteLine((int)DialogResult.CANCEL);
            Console.WriteLine((int)DialogResult.CONFIRM);
            Console.WriteLine((int)DialogResult.OK);
            Console.Write("abc");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("def");
        }
    }
}