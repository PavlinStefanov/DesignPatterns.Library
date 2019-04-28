using System.Data;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Adapters
{
    public interface IDataSourceAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSet"></param>
        void Fill(DataSet dataSet);
    }
}
