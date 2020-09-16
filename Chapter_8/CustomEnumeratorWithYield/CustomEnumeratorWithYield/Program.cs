using System;
using System.Collections;

namespace CustomEnumeratorWithYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the Yield Keyword *****\n");
            Garage carLot = new Garage();
            //No exception at this point without local function
            //IEnumerator carEnumerator = carLot.GetEnumerator();
            //try
            //{
            //    //Error at this time
            //    carEnumerator.MoveNext();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Exception occurred on MoveNext");
            //}
            try
            {
                //Error at this time
                var carEnumerator = carLot.GetEnumerator();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occurred on GetEnumerator");
            }

            //Get items using GetEnumerator().
            foreach (Car c in carLot)
            {
                Console.WriteLine("{0} is going {1} MPH",
                    c.PetName, c.CurrentSpeed);
            }

            Console.WriteLine();

            //Get items(in reverse!) using named iterator.
            foreach (Car c in carLot.GetTheCars(true))
            {
                Console.WriteLine("{0} is going {1} MPH",
                    c.PetName, c.CurrentSpeed);
            }
            Console.ReadLine();
        }
    }
}
