using DesignPatterns.Library.StructuralPatterns.Adapter.Helpers;
using DesignPatterns.Library.StructuralPatterns.Adapter.Readers;
using System.Data;
using System.Linq;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Adapters
{
    public class XmlfileAdapter : IDataSourceAdapter
    {
        private readonly IReader _reader;

        public XmlfileAdapter(IReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSet"></param>
        public void Fill(DataSet dataSet)
        {
            _reader.Read();

            var employeeTable = _reader.Resources
                .Cast<Employee>()
                .ToList()
                .ToDataTable();

            dataSet.Tables.Add(employeeTable);
            dataSet.AcceptChanges();
        }
    }
}
