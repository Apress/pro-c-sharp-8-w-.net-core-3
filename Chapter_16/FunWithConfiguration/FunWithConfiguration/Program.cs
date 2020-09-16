using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FunWithConfiguration
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            Console.WriteLine($"My car's name is {config["CarName"]}");
            Console.ReadLine();
        }
    }
}
