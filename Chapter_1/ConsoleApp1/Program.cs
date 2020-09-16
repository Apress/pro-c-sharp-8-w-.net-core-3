using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc c = new Calc();
            uint ans = c.Add(10, 85);
            Console.WriteLine("10 + 84 is {0}",ans);
            //Wait for user to press the Enter key before shutting down
            Console.ReadLine();
        }
    }

    [CLSCompliant(true)]
    public class Calc
    {
        public uint Add(uint addend1, uint addend2)
        {
            return addend1 + addend2;
        }
    }
}
