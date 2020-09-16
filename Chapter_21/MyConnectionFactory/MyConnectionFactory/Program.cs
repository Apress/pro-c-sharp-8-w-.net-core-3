using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Data.SqlClient;

namespace MyConnectionFactory
{
    //OleDb is Windows only and is not supported in .NET Core
    enum DataProviderEnum
    {
        SqlServer,
#if PC
        OleDb, 
#endif
        Odbc, 
        None
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Very Simple Connection Factory *****\n");
            Setup(DataProviderEnum.SqlServer);
#if PC
            Setup(DataProviderEnum.OleDb); //Not supported on MacOS
#endif
            Setup(DataProviderEnum.Odbc);
            Setup(DataProviderEnum.None);
            Console.ReadLine();
        }

        private static void Setup(DataProviderEnum provider)
        {
            // Get a specific connection.
            IDbConnection myConnection = GetConnection(provider);
            Console.WriteLine($"Your connection is a {myConnection?.GetType().Name ?? "unrecognized type"}");
            // Open, use and close connection...
        }

        // This method returns a specific connection object
        // based on the value of a DataProvider enum.
        static IDbConnection GetConnection(DataProviderEnum dataProvider) =>
            dataProvider switch
            {
                DataProviderEnum.SqlServer => new SqlConnection(),
#if PC
                //Not support on MacOS
                DataProviderEnum.OleDb => new OleDbConnection(),
#endif
                DataProviderEnum.Odbc => new OdbcConnection(),
                _ => null,
            };
    }
}
