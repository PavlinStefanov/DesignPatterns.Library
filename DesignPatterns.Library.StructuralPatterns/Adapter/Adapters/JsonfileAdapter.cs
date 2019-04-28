using DesignPatterns.Library.StructuralPatterns.Adapter.Helpers;
using DesignPatterns.Library.StructuralPatterns.Adapter.Readers;
using System.Data;
using System.Linq;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Adapters
{
    public class JsonfileAdapter : IDataSourceAdapter
    {
        private readonly IReader _reader;

        public JsonfileAdapter(IReader reader)
        {
            _reader = reader;
        }

        public void Fill(DataSet dataSet)
        {
            _reader.Read();

            var categoryTable = _reader.Resources
                .Cast<Category>()
                .ToList()
                .ToDataTable();

            dataSet.Tables.Add(categoryTable);
            dataSet.AcceptChanges();
        }
    }
}
