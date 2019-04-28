using DesignPatterns.Library.StructuralPatterns.Adapter.Helpers;
using DesignPatterns.Library.StructuralPatterns.Adapter.Readers;
using System.Data;
using System.Linq;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Adapters
{
    public class TextfileAdapter : IDataSourceAdapter
    {
        private readonly IReader _reader;

        public TextfileAdapter(IReader reader)
        {
            _reader = reader;
        }

        public void Fill(DataSet dataSet)
        {
            _reader.Read();

            var irisTable = _reader.Resources
                .Cast<IrisModel>()
                .ToList()
                .ToDataTable();

            dataSet.Tables.Add(irisTable);
            dataSet.AcceptChanges();
        }
    }
}
