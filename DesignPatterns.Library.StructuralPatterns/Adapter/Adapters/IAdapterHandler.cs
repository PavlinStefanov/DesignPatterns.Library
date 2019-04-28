using System.Data;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Adapters
{
    public interface IAdapterHandler<in T1, in T2> where T1 : IDataSourceAdapter where T2 : DataSet
    {
        /// <summary>
        /// Method which allows to process single adapter
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="adapterSet"></param>
        void Handle(T1 adapter, T2 adapterSet);
    }
}
