using System;
using System.Collections.Generic;
using System.Text;

namespace ComparableCar
{
    class Radio
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Jamming..." : "Quiet time...");
        }
    }
}
