using System;
using System.Runtime.InteropServices;
//[assembly: CLSCompliant(true)]

namespace Calc.Cs
{
    class Program
    {
        //[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        //private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
        static void Main(string[] args)
        {
            Calc c = new Calc();
            int ans = c.Add(10, 84);
            Console.WriteLine("10 + 84 is {0}",ans);
            //Wait for user to press the Enter key before shutting down
            //MessageBox(IntPtr.Zero, "Command-line message box", "Attention!", 0);
            Console.ReadLine();
        }
    }

    //[CLSCompliant(true)]
    public class Calc
    {
        //public ulong AddULong(ulong addend1, ulong addend2)
        //{
        //    return addend1 + addend2;
        //}
        public int Add(int addend1, int addend2)
        {
            return addend1 + addend2;
        }
    }
}