using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiInterfaceHierarchy
{
    class Rectangle : IShape
    {
        public int GetNumberOfSides() => 4;

        public void Draw() => Console.WriteLine("Drawing...");

        public void Print() => Console.WriteLine("Printing...");
    }
}
