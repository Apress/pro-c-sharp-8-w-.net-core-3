using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class Fork : IPointy
    {
        public byte Points => 4;
    }

    class PitchFork : IPointy
    {
        public byte Points => 3;
    }

    class Knife : IPointy
    {
        public byte Points => 1;
    }
}
