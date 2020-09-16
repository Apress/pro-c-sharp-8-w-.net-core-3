using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SimpleSerialize
{
    [Serializable]
    public class Radio
    {
        public bool HasTweeters;
        public bool HasSubWoofers;
        public double[] StationPresets;

        [NonSerialized]
        public string RadioId = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio TheRadio = new Radio();
        public bool IsHatchBack;
    }

    [Serializable]
    [XmlRoot(Namespace = "http://www.MyCompany.com")]
    public class JamesBondCar : Car
    {
        [XmlAttribute]
        public bool CanFly;
        [XmlAttribute]
        public bool CanSubmerge;

        public JamesBondCar(bool skyWorthy, bool seaWorthy)
        {
            CanFly = skyWorthy;
            CanSubmerge = seaWorthy;
        }
        // The XmlSerializer demands a default constructor!
        public JamesBondCar() { }
    }

    [Serializable]
    public class Person
    {
        // A public field.
        public bool IsAlive = true;

        // A private field.
        private int PersonAge = 21;

        // Public property/private data.
        private string _fName = string.Empty;
        public string FirstName
        {
            get { return _fName; }
            set { _fName = value; }
        }
    }

    class Program
    {
        // Be sure to import the System.Runtime.Serialization.Formatters.Binary
        // and System.IO namespaces.
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Serialization *****\n");

            // Make a JamesBondCar and set state.
            JamesBondCar jbc = new JamesBondCar 
            {
                CanFly = true,
                CanSubmerge = false,
                TheRadio =
                {
                    StationPresets = new double[] {89.3, 105.1, 97.1}, 
                    HasTweeters = true
                }
            };

            Person p = new Person
            {
                FirstName = "James",
                IsAlive = true
            };
            // Now save the car to a specific file in a binary format.
            SaveAsBinaryFormat(jbc, "CarData.dat");
            Console.WriteLine("=> Saved car in binary format!");

            SaveAsBinaryFormat(p, "PersonData.dat");
            Console.WriteLine("=> Saved person in binary format!");
            
            JamesBondCar carFromDisk = LoadFromBinaryFile<JamesBondCar>("CarData.dat");
            Console.WriteLine($"Can this car fly? : {carFromDisk.CanFly}");

            Person personFromDisk = LoadFromBinaryFile<Person>("PersonData.dat");
            Console.WriteLine($"Is {personFromDisk.FirstName} alive? : {personFromDisk.IsAlive}");


            // XML
            SaveAsXmlFormat(jbc, "CarData.xml");
            Console.WriteLine("=> Saved car in XML format!");

            SaveAsXmlFormat(p, "PersonData.xml");
            Console.WriteLine("=> Saved person in XML format!");

            SaveListOfCarsAsXml();

            SaveListOfCarsAsBinary();
            Console.ReadLine();
        }

        static T LoadFromBinaryFile<T>(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            T dataFromDisk = default;
            // Read the JamesBondCar from the binary file.
            using (Stream fStream = File.OpenRead(fileName))
            {
                dataFromDisk = (T)binFormat.Deserialize(fStream);
            }
            return dataFromDisk;
        } 

        static void SaveAsBinaryFormat<T>(T objGraph, string fileName)
        {
            // Save object to a file in binary.
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fileName,
                  FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
        } 

        static void SaveAsXmlFormat<T>(T objGraph, string fileName)
        {
            // Save object to a file in XML format.
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));

            using (Stream fStream = new FileStream(fileName,
              FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
        }
        static void SaveListOfCarsAsXml()
        {
            // Now persist a List<T> of JamesBondCars.
            List<JamesBondCar> myCars = new List<JamesBondCar>
            {
                new JamesBondCar(true, true),
                new JamesBondCar(true, false),
                new JamesBondCar(false, true),
                new JamesBondCar(false, false)
            };

            using (Stream fStream = new FileStream("CarCollection.xml",
              FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
                xmlFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Saved list of cars!");
        }

        static void SaveListOfCarsAsBinary()
        {
            // Now persist a List<T> of JamesBondCars.
            List<JamesBondCar> myCars = new List<JamesBondCar>
            {
                new JamesBondCar(true, true),
                new JamesBondCar(true, false),
                new JamesBondCar(false, true),
                new JamesBondCar(false, false)
            };

            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("AllMyCars.dat",
              FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Saved list of cars in binary!");
        }
    }
}
