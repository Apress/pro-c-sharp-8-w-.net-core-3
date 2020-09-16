using System;
using System.Collections;
using System.Collections.Generic;

namespace CilTypesConsumer
{
    public struct MyStruct
    {

    }

    public enum MyEnum
    {

    }
    class Program
    {
        public static void MyMethod(int inputInt,
            ref int refInt, ArrayList ar, out int outputInt)
        {
            outputInt = 0; // Just to satisfy the C# compiler...
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var c = new MyNamespace.MyBaseClass("foo",12);
        }
        void SomeMethod()
        {
            List<int> myInts = new List<int>();
            Dictionary<string, int> d = new Dictionary<string, int>();
            List<List<int>> myIntsOfInts = new List<List<int>>();
        }
        public static void MyLocalVariables()
        {
            string myStr = "CIL code is fun!";
            int myInt = 33;
            object myObj = new object();
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public int Add2(int a, int b)
        {
            return a + b;
        }
        public static void CountToTen()
        {
            for(int i = 0; i < 10; i++)
            {
            }
        }

    }
}
