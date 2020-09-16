using System;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car c1 = new Car("SlugBug", 100, 10);

            // Register event handlers.
            //c1.AboutToBlow += CarIsAlmostDoomed;
            //c1.AboutToBlow += CarAboutToBlow;

            //Car.CarEngineHandler d = CarExploded;
            //EventHandler<CarEventArgs> d = CarExploded;
            //c1.Exploded += d;

            //Console.WriteLine("***** Speeding up *****");
            //for (int i = 0; i < 6; i++)
            //{
            //    c1.Accelerate(20);
            //}

            // Remove CarExploded method
            // from invocation list.
            //c1.Exploded -= d;

            int aboutToBlowCounter = 0;
            // Register event handlers as anonymous methods.
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };

            c1.AboutToBlow += delegate(object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Message from Car: {0}", e.msg);
            };

            c1.Exploded += delegate(object sender, CarEventArgs e)
            {
                Console.WriteLine("Fatal Message from Car: {0}", e.msg);
            };

            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.WriteLine("AboutToBlow event was fired {0} times.",
                aboutToBlowCounter);

            Console.ReadLine();
        }

        //public static void CarAboutToBlow(string msg)
        //{
        //    Console.WriteLine(msg);
        //}
        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            //Console.WriteLine($"{sender} says: {e.msg}");
            // Just to be safe, perform a
            // runtime check before casting.
            if (sender is Car c)
            {
                Console.WriteLine($"Critical Message from {c.PetName}: {e.msg}");
            }
        }

        //public static void CarIsAlmostDoomed(string msg)
        //{
        //    Console.WriteLine("=> Critical Message from Car: {0}", msg);
        //}
        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            Console.WriteLine($"=> Critical Message from Car: {e.msg}");
        }

        //public static void CarExploded(string msg)
        //{
        //    Console.WriteLine(msg);
        //}
        public static void CarExploded(object sender,CarEventArgs e)
        {
            Console.WriteLine(e.msg);
        }
        public static void HookIntoEvents()
        {
            Car newCar = new Car();
            newCar.AboutToBlow += NewCarOnAboutToBlow;
        }

        //private static void NewCarOnAboutToBlow(string msgforcaller)
        //{
        //    throw new NotImplementedException();
        //}
        private static void NewCarOnAboutToBlow(object sender, CarEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
