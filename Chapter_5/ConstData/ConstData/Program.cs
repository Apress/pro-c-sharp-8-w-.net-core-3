using System;

namespace ConstData
{
    class MyMathClass
    {
        public const double PI = 3.14;
        static void LocalConstStringVariable()
        {
            // A local constant data point can be directly accessed.
            const string fixedStr = "Fixed string Data";
            Console.WriteLine(fixedStr);

            // Error!
            // fixedStr = "This will not work!";
        }

    }
    class MyMathClass2
    {
        public static readonly double PI;

        static MyMathClass2()
        {
            PI = 3.14;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Const *****\n");
            Console.WriteLine("The value of PI is: {0}", MyMathClass.PI);
            // Error! Can't change a constant!
            // MyMathClass.PI = 3.1444;

            Console.WriteLine("The value of PI is: {0}", MyMathClass2.PI);

            Console.ReadLine();
        }
    }
}
