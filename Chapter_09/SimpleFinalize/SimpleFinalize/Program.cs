using System;

namespace SimpleFinalize
{
    class MyResourceWrapper
    {
        // Compile-time error!
        //protected override void Finalize(){ }

        // Clean up unmanaged resources here.
        // Beep when destroyed (testing purposes only!)
        ~MyResourceWrapper()
        {
            Console.Beep();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Finalizers *****\n");
            Console.WriteLine("Hit return to create the objects ");
            Console.WriteLine("then force the GC to invoke Finalize()");
            //Depending on the power of your system, you might need to increase these values
            CreateObjects(1_000_000);
            GC.AddMemoryPressure(2147483647);
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
        }

        private static void CreateObjects(int count)
        {
            MyResourceWrapper[] tonsOfObjects = new MyResourceWrapper[count];
            for (int i = 0; i < count; i++)
            {
                tonsOfObjects[i] = new MyResourceWrapper();
            }

            tonsOfObjects = null;
        }
    }
}
