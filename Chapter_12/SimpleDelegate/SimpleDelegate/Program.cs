using System;

namespace SimpleDelegate
{
    // This delegate can point to any method,
    // taking two integers and returning an integer.
    public delegate int BinaryOp(int x, int y);

    // This class contains methods BinaryOp will
    // point to.
    //public class SimpleMath
    //{
    //    public static int Add(int x, int y) => x + y;
    //    public static int Subtract(int x, int y) => x - y;
    //    public static int SquareNumber(int a) => a * a;
    //}
    public class SimpleMath
    {
        public int Add(int x, int y) => x + y;
        public int Subtract(int x, int y) => x - y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");

            // Create a BinaryOp delegate object that
            // "points to" SimpleMath.Add().
            //BinaryOp b = new BinaryOp(SimpleMath.Add);

            // Delegates can also point to instance methods as well.
            SimpleMath m = new SimpleMath();
            BinaryOp b = new BinaryOp(m.Add);
            DisplayDelegateInfo(b);
            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine("10 + 10 is {0}", b(10, 10));

            // Compiler error! Method does not match delegate pattern!
            //BinaryOp b2 = new BinaryOp(SimpleMath.SquareNumber);

            Console.ReadLine();
        }

        static void DisplayDelegateInfo( Delegate delObj )
        {
            // Print the names of each member in the
            // delegate's invocation list.
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
            }
        } 

    }
}
