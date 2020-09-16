using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomSerialization
{
    [Serializable]
    class StringData : ISerializable
    {
        private string _dataItemOne = "First data block";
        private string _dataItemTwo = "More data";

        public StringData() { }
        protected StringData(SerializationInfo si, StreamingContext ctx)
        {
            // Rehydrate member variables from stream.
            _dataItemOne = si?.GetString("First_Item")?.ToLower();
            _dataItemTwo = si?.GetString("dataItemTwo")?.ToLower();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            // Fill up the SerializationInfo object with the formatted data.
            info.AddValue("First_Item", _dataItemOne.ToUpper());
            info.AddValue("dataItemTwo", _dataItemTwo.ToUpper());
        }
    }

    [Serializable]
    class MoreData
    {
        private string _dataItemOne = "First data block";
        private string _dataItemTwo = "More data";

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            // Called during the serialization process.
            _dataItemOne = _dataItemOne.ToUpper();
            _dataItemTwo = _dataItemTwo.ToUpper();
        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Called once the deserialization process is complete.
            _dataItemOne = _dataItemOne.ToLower();
            _dataItemTwo = _dataItemTwo.ToLower();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Serialization *****");

            // Recall that this type implements ISerializable.
            StringData myData = new StringData();

            // Save to a local file in binary format.
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream("MyData.dat",
              FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, myData);
            }
            Console.ReadLine();
        }
    }
}
