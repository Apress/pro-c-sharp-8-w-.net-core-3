using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCSharpConsoleApp
{
    public class SportsCar : Car
    {
        public string GetPetName()
        {
            PetName = "Fred";
            return PetName;
        }
    }
}