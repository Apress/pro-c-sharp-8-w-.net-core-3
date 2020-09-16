using System.Collections.Generic;
using System.Data;

namespace AutoLot.DAL.BulkImport
{
    public interface IMyDataReader<T> : IDataReader
    {
        List<T> Records { get; set; }
    }
}