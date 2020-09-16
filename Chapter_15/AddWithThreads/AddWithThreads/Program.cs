using System;
using System.Threading;

namespace AddWithThreads
{
    class AddParams
    {
        public int a, b;

        public AddParams(int numb1, int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }


    class Program
    {
        private static AutoResetEvent _waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
                Thread.CurrentThread.ManagedThreadId);

            // Make an AddParams object to pass to the secondary thread.
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            //set to background thread
            t.IsBackground = true;
            t.Start(ap);
            // Force a wait to let other thread finish.
            //Thread.Sleep(5);

            //Wait for the wait handle to complete
            //_waitHandle.WaitOne();
            //Console.ReadLine();
        }
        static void Add(object data)
        {
            if (data is AddParams ap)
            {
                //Add in sleep to show the background thread getting terminated
                Thread.Sleep(10);

                Console.WriteLine("ID of thread in Add(): {0}",
                    Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine("{0} + {1} is {2}",
                    ap.a, ap.b, ap.a + ap.b);

                //Add in sleep to illustrate background behavior
                // Tell other thread we are done.
                //_waitHandle.Set();

            }
        }

    }
}
