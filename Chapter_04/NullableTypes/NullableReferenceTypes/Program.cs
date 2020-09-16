using System;

namespace NullableReferenceTypes
{
    public class TestClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string? nullableString = null;
            TestClass? myNullableClass = null;

            //Warning	CS8600	Converting null literal or possible null value to non-nullable type
            TestClass myNonNullableClass = myNullableClass;

            #nullable disable
            TestClass anotherNullableClass = null;
            //Warning	CS8632	The annotation for nullable reference types should only be used in code within a '#nullable' annotations 
            TestClass? badDefinition = null;
            //Warning	CS8632	The annotation for nullable reference types should only be used in code within a '#nullable' annotations 
            string? anotherNullableString = null;
            #nullable restore

            //Not a valid call
            //myNullableClass.HasValue

            Console.WriteLine("Hello World!");
        }

    }
}