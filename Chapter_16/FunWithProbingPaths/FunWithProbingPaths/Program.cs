using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace FunWithProbingPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with Probing Paths ***");
            Console.WriteLine($"TRUSTED_PLATFORM_ASSEMBLIES: ");
            //Use ':' on non-Windows platforms
            var list = AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES").ToString().Split(';');
            foreach (var dir in list.Where(x=>!x.StartsWith(@"C:\Program Files")))
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine();
            Console.WriteLine($"PLATFORM_RESOURCE_ROOTS: {AppContext.GetData("PLATFORM_RESOURCE_ROOTS")}");
            Console.WriteLine();
            Console.WriteLine($"NATIVE_DLL_SEARCH_DIRECTORIES: {AppContext.GetData("NATIVE_DLL_SEARCH_DIRECTORIES")}");
            Console.WriteLine();
            Console.WriteLine($"APP_PATHS: {AppContext.GetData("APP_PATHS")}");
            Console.WriteLine();
            Console.WriteLine($"APP_NI_PATHS: {AppContext.GetData("APP_NI_PATHS")}");
            Console.WriteLine();

            Console.WriteLine("Load assembly in Probing Path");
            Console.WriteLine(Directory.GetCurrentDirectory());
            AssemblyLoadContext ctx = new AssemblyLoadContext("Test");

            AssemblyDependencyResolver resolver = new AssemblyDependencyResolver(Directory.GetCurrentDirectory());
            //var name = AssemblyLoadContext.GetAssemblyName("DependentAssembly.dll");
            
            //var foo = resolver.ResolveAssemblyToPath(new AssemblyName("DependentAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"));
            var child = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(),"ChildProject.dll"));
            foreach (var t in child.GetTypes())
            {
                try
                {
                    if (t.Name == "ChildClass")
                    {
                        var c = Activator.CreateInstance(t);
                        foreach (var m in t.GetMethods())
                        {
                            if (m.Name == "DoSomething")
                            {
                                m.Invoke(c,null);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            //var c = Activator.CreateInstance()
            Console.ReadLine();
        }
    }
}
