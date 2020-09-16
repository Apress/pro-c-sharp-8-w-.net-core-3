using System;
using System.Collections.Generic;
using System.Text;

namespace CustomInterfaces
{
    class PointyTestClass : IPointy
    {
        public byte Points => throw new NotImplementedException();
    }
}
